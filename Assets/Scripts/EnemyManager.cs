using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
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
    
    // Start is called before the first frame update
    void Start()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        direction = DIRECTION_TYPE.LEFT;
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
}
