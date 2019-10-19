using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class LevelController : MonoBehaviour
{
    public int enemyCount;
    public GameObject victoryCanvas; 

    // Start is called before the first frame update
    void Start()
    {
        victoryCanvas.SetActive(false);
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
            Invoke("victory",1.5f);
        }
        
    }

    void victory()
    {
        victoryCanvas.SetActive(true);
        Time.timeScale = 0f;
        Debug.Log("VICTORY!!!");
    }
}
