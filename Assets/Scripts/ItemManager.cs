using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemManager : MonoBehaviour
{
    private GameManagerScript1st gameManagerScript1st;
    // Start is called before the first frame update
    void Start()
    {
        // gameManagerScript1st = GameObject.Find("GameManagerScript1st").GetComponent<GameManagerScript1st>(); // Search at Hierarchy
        // ^ GameObject.Find search only Object Name In HIERARCHY. Not a script name
        gameManagerScript1st = GameObject.Find("GameManager").GetComponent<GameManagerScript1st>(); // Search at Hierarchy
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void GetItem()
    {
        gameManagerScript1st.AddScore(100);
        Destroy(this.gameObject);
    }
}
