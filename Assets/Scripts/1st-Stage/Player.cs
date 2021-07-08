using System.Collections;
using System.Collections.Generic;
using UnityEditor.UIElements;
using UnityEngine;

public class Player : MonoBehaviour
{
    public LayerMask groundLayer;
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
    private float jumpPower = 400;
    
    // Start is called before the first frame update
    void Start()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        float x = Input.GetAxis("Horizontal");
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
        if (IsGround() && Input.GetKeyDown("space")) // once and when on ground
        {
            Jump();
        }
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
                speed = 8;
                // animator.SetBool("isRunning", true);
                transform.localScale = new Vector3(1, 1, 1); // Not Vector2
                break;
            case DIRECTION_TYPE.LEFT:
                speed = -8;
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
        return Physics2D.Linecast(leftStartPoint, endPoint, groundLayer)
            || Physics2D.Linecast(rightStartPoint, endPoint, groundLayer);
    }
}
