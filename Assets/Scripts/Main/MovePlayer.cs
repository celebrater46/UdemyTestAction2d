using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePlayer : MonoBehaviour
{
    // Transform tf;
    Rigidbody rb;
    // Start is called before the first frame update
    void Start()
    {
        // tf = GetComponent<Transform>();
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        // tf.position += new Vector3(0.1f, 0, 0);
        
        // Even if not doing Getcomponent, can move objects by transform.position. Because MonoBehaviour has such method.
        // transform.position += new Vector3(0.1f, 0, 0); // Moving Method 1 (Changing Position)
        // rb.velocity = new Vector3(1f, 0, 0); // Moving Method 2 (Changing Speed)
        // rb.AddForce(new Vector3(0, 3, 0)); // Moving Method 3 (Adding Force)
    }
}
