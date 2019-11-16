using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GateControl : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(FindObjectOfType<LevelController>().enemyKillCount >= FindObjectOfType<LevelController>().enemyCountTotal - 1)
        {
            Destroy(gameObject);
                 
        }
    }
}
