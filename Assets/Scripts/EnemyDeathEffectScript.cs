using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDeathEffectScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void FinishAnimation()
    {
        Destroy(this.gameObject);
    }
}
