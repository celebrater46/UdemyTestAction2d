using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
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
    
    // Start is called before the first frame update
    void Start()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        direction = DIRECTION_TYPE.LEFT;
    }

    private void Update()
    {
        if (!IsGround())
        {
            ChangeDirection();
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
                speed = 3;
                // animator.SetBool("isRunning", true);
                transform.localScale = new Vector3(1, 1, 1); // Not Vector2
                break;
            case DIRECTION_TYPE.LEFT:
                speed = -3;
                // animator.SetBool("isRunning", true);
                transform.localScale = new Vector3(-1, 1, 1);
                break;
        }
        
        // Change Player's moving speed
        rigidbody2D.velocity = new Vector2(speed, rigidbody2D.velocity.y);
    }
    
    private bool IsGround()
    {
        // Vector3 leftStartPoint = transform.position - Vector3.right * 0.2f;
        // Vector3 rightStartPoint = transform.position + Vector3.right * 0.2f;
        // Vector3 endPoint = transform.position - Vector3.up * 0.1f;
        Vector3 startVec = transform.position + transform.right * 0.5f * transform.localScale.x;
        Vector3 endVec = startVec - transform.up;
        
        // Debug.DrawLine(leftStartPoint, endPoint);
        // Debug.DrawLine(rightStartPoint, endPoint);
        Debug.DrawLine(startVec, endVec);
        // return true;
        // return Physics2D.Linecast(leftStartPoint, endPoint, groundLayer)
        //        || Physics2D.Linecast(rightStartPoint, endPoint, groundLayer);
        return Physics2D.Linecast(startVec, endVec, groundLayer);
    }

    private void ChangeDirection()
    {
        if (direction == DIRECTION_TYPE.RIGHT)
        {
            direction = DIRECTION_TYPE.LEFT;
        }
        else if(direction == DIRECTION_TYPE.LEFT)
        {
            direction = DIRECTION_TYPE.RIGHT;
        }
        // Debug.Log(transform.name + ": " + IsGround());
    }

    public void DestroyEnemy()
    {
        Destroy(this.gameObject);
    }
}
