using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Pause_ResumeScript : MonoBehaviour
{

    public GameObject pauseMenu;

    public void GotoMainScene()
    {
        SceneManager.LoadScene("Map_Level");
    }

    public void GotoHomeScene(){
        //Application.LoadLevel("Start_Menu");
        SceneManager.LoadScene("Start_Menu");
    }

  /*  public void GotoMenuScene()
    {
       
    }*/

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
      
    	
        
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
}
