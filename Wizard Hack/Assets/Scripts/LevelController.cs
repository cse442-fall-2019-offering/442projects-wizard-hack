using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class LevelController : MonoBehaviour
{
    public int enemyCountTotal;
    public int enemyKillCount=0;
    public GameObject victoryCanvas;
    public GameObject pauseMenu;
    public GameObject enemyCountText;
    public static GameObject[] enemies;

    // Start is called before the first frame update
    void Start()
    {
        victoryCanvas.SetActive(false);
        enemies = GameObject.FindGameObjectsWithTag("Enemy");
        enemyCountTotal = enemies.Length;
        updateEnemyCountText();
        Debug.Log("Enemy Count Start:" + enemyCountTotal);
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
        enemyKillCount++;
        updateEnemyCountText();
        Debug.Log("Enemy Kill Count :" + enemyKillCount);
        if (enemyKillCount >= enemyCountTotal)
        {
            Invoke("victory",1.5f);
        }
        
    }

    public void updateEnemyCountText()
    {
        enemyCountText.GetComponent<UnityEngine.UI.Text>().text = "Enemy Kill Count: " + enemyKillCount + "/" + enemyCountTotal;
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

    public static void NotifyEnemiesAboutBubble(Bubble bubble)
    {
        foreach(GameObject enemy in enemies){
            if (enemy != null && !enemy.GetComponent<EnemyHealth>().isDead)
            {
                enemy.GetComponent<EnemyChase>().addNewBubble(bubble);
            }
        }
    }

    public static void NotifyEnemiesBubblePopped(Bubble bubble)
    {
        foreach (GameObject enemy in enemies)
        {
            if (enemy != null && !enemy.GetComponent<EnemyHealth>().isDead)
            {
                enemy.GetComponent<EnemyChase>().removePoppedBubble(bubble);
            }
        }
    }
}
