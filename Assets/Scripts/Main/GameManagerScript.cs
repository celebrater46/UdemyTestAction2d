using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManagerScript : MonoBehaviour
{
    public GameObject sampleObj;
    public Text titleText; // Getting text component out of this object
    
    // Start is called before the first frame update
    void Start()
    {
        sampleObj.SetActive(false); // disappear
        // Destroy(sampleObj); // delete (not disappear)

        titleText.text = "Hello Hoge."; // Change the text from out of text object
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
