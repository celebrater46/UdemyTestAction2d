using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.UIElements;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    public LayerMask groundLayer;
    public GameManagerScript1st gameManagerScript1st;
    
    public enum DIRECTION_TYPE
    {
        STOP,
        RIGHT,
        LEFT,
    }

    private DIRECTION_TYPE direction = DIRECTION_TYPE.STOP;

    private Rigidbody2D rigidbody2D;
    private Animator animator;
    private float speed = 0;
    private float jumpPower = 900;
    private string jumpKey = "space";
    private string jumpKey2 = "joystick button 0";
    
    // Start is called before the first frame update
    void Start()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        // gameManager = GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        float x = Input.GetAxis("Horizontal");
        float y = Input.GetAxis("Vertical");
        if (x == 0)
        {
            // Stopping
            animator.SetBool("isRunning", false);
            direction = DIRECTION_TYPE.STOP;
            // animator.SetFloat("Speed", 0);
        } else if (x > 0)
        {
            // To Right
            animator.SetBool("isRunning", true);
            direction = DIRECTION_TYPE.RIGHT;
            // animator.SetFloat("Speed", x);
        } else if (x < 0)
        {
            // To Left
            animator.SetBool("isRunning", true);
            direction = DIRECTION_TYPE.LEFT;
            // animator.SetFloat("Speed", x);
        }
        
        // if (Input.GetKey("space")) // Adding force many times
        // if (Input.GetKeyDown("space")) // once
        // if (IsGround() && Input.GetKeyDown("space")) // once and when on ground
        if (IsGround()) // once and when on ground
        {
            if (Input.GetKeyDown(jumpKey) || Input.GetKeyDown(jumpKey2))
            // if (Input.GetKeyDown(jumpKey) || y > 0)
            {
                Jump();
            }
            else
            {
                animator.SetBool("isJumping", false);
            }
        }
        
        if (Input.anyKeyDown)
        {
            ShowKeyCode();
        }
        Debug.Log(transform.name + ": " + IsGround());
    }

    private void FixedUpdate()
    {
        switch (direction)
        {
            case DIRECTION_TYPE.STOP:
                speed = 0;
                // animator.SetBool("isRunning", false);
                break;
            case DIRECTION_TYPE.RIGHT:
                speed = 5;
                // animator.SetBool("isRunning", true);
                transform.localScale = new Vector3(1, 1, 1); // Not Vector2
                break;
            case DIRECTION_TYPE.LEFT:
                speed = -5;
                // animator.SetBool("isRunning", true);
                transform.localScale = new Vector3(-1, 1, 1);
                break;
        }
        
        // Change Player's moving speed
        rigidbody2D.velocity = new Vector2(speed, rigidbody2D.velocity.y);
    }

    private void Jump()
    {
        // Add force upward
        rigidbody2D.AddForce(Vector2.up * jumpPower);
        animator.SetBool("isJumping", true);
    }

    private bool IsGround()
    {
        // Create Start point and End point of the arrow
        Vector3 leftStartPoint = transform.position - Vector3.right * 0.2f;
        Vector3 rightStartPoint = transform.position + Vector3.right * 0.2f;
        Vector3 endPoint = transform.position - Vector3.up * 0.1f;
        
        // Display the arrows to debug
        Debug.DrawLine(leftStartPoint, endPoint);
        Debug.DrawLine(rightStartPoint, endPoint);
    
        // V Linecast means judgement of collision (start, end, target)
        // V return true if follow conditions
        // return true; // Test
        return Physics2D.Linecast(leftStartPoint, endPoint, groundLayer)
            || Physics2D.Linecast(rightStartPoint, endPoint, groundLayer);
    }

    // When the player strikes against something
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "GameOver")
        {
            Debug.Log("Game Over...");
            gameManagerScript1st.GameOver();
            // Restart();
            Invoke("Restart", 1.5f); // Exec function() 1.5s later 
        }
        else if(other.gameObject.tag == "Goal")
        {
            Debug.Log("Goal!!");
            gameManagerScript1st.Goal();
            // Restart();
            Invoke("Restart", 1.5f);
        } 
        else if (other.gameObject.tag == "Item")
        {
            // Getting Item
            Debug.Log("You got an item!");
            // other.gameObject.GetComponent<ItemManager>().GetItem; // <- Compile Error Occurred: Only assignment, call, increment, decrement, await expression, and new object expressions can be used as a statement. To sum up, FUNCTION NEEDS "()"!! STUPID.
            other.gameObject.GetComponent<ItemManager>().GetItem();
        }
        else if (other.gameObject.tag == "Enemy")
        {
            // Getting Enemy
            EnemyManager enemy = other.gameObject.GetComponent<EnemyManager>();
            
            if (this.transform.position.y + 0.2f > enemy.transform.position.y)
            {
                // On Enemy
                rigidbody2D.velocity = new Vector2(rigidbody2D.velocity.x, 0); // stop falling of the player when tread the enemy
                Jump();
                enemy.DestroyEnemy();
            }
            else
            {
                // Destroy(this.gameObject); // If destroy this object, Restart will not work.
                this.gameObject.SetActive(false); // disappear
                gameManagerScript1st.GameOver();
                Invoke("Restart", 1.5f);
            }
        }
        // throw new NotImplementedException();
    }

    void Restart()
    {
        Scene currentScene = SceneManager.GetActiveScene();
        // SceneManager.LoadScene(currentScene);
        SceneManager.LoadScene(currentScene.name);
    }

    private void ShowKeyCode()
    {
        // 入力されたキー名
        // string keyStr = Input.inputString;
        // Debug.Log(keyStr);
            
        foreach(KeyCode code in Enum.GetValues(typeof(KeyCode)))
        {
            if (Input.GetKeyDown(code))
            {
                // 入力されたキー名を表示
                Debug.Log(code.ToString());
            }
        }
    }
}
