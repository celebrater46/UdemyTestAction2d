using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManagerScript1st : MonoBehaviour
{
    public GameObject gameOverText;
    public GameObject goalText;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void GameOver()
    {
        gameOverText.SetActive(true);
    }

    public void Goal()
    {
        goalText.SetActive(true);
    }
}
