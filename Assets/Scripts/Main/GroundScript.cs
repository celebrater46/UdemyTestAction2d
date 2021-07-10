using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundScript : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log(other.name); // Sphere, Player (Not Ground, the name is the object that collide with this ground)
        if (other.gameObject.tag == "PlayerSphere")
        {
            Debug.Log("Hello PlayerSphere!!");
        }
        // throw new NotImplementedException();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
