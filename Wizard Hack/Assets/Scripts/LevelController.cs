using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class LevelController : MonoBehaviour
{
    public int enemyCount;
    public GameObject victoryCanvas;
    public GameObject pauseMenu;

    // Start is called before the first frame update
    void Start()
    {
        victoryCanvas.SetActive(false);
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
        enemyCount = enemies.Length;
        Debug.Log("Enemy Count Start:" + enemies.Length);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            pause();
        }
    }

    public void pause()
    {
        Time.timeScale = 0f;
        pauseMenu.SetActive(true);
    }

    public void resume()
    {
        Time.timeScale = 1f;
        pauseMenu.SetActive(false);
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

    public void mainMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("Start_Menu");
    }
}
