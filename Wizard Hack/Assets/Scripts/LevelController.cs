using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelController : MonoBehaviour
{
    public int enemyCount;

    // Start is called before the first frame update
    void Start()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
        enemyCount = enemies.Length;
        Debug.Log("Enemy Count Start:" + enemies.Length);
    }

    public void enemyDead()
    {
        enemyCount--;
        Debug.Log("Enemy Count :" + enemyCount);
        if (enemyCount <= 0)
        {
            victory();
        }
        
    }

    void victory()
    {
        Debug.Log("VICTORY!!!");
    }
}
