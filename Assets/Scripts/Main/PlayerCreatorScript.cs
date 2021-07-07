using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCreatorScript : MonoBehaviour
{
    // public GameObject playerPrefab;
    [SerializeField] GameObject playerPrefab; // Same above
    // Start is called before the first frame update
    void Start()
    {
        Instantiate(playerPrefab); // create a same object from prefab
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
