using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

/*
 * This class is used to pause or resume the game
 * included methods: Start, Update, pause, resume, GotoMainScene, GotoHomeScene
 */
public class Pause_ResumeScript : MonoBehaviour
{

    public GameObject lo_pauseMenu;

    /*
     * input: void
     * output: void
     * returns the the main game
     */
    public void GotoMainScene()
    {
        SceneManager.LoadScene("Map_Level");
    }
    /*
     * input: void
     * output: void
     * returns to the start screen
     */
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
    /*
     * input: void
     * output: void
     * pauses game and brings up pause menu
     */

    public void pause()
    {
        Time.timeScale = 0f;
        lo_pauseMenu.SetActive(true);
    }
    /*
     * input: void
     * output:void
     * resumes the game
     */
    public void resume()
    {
        Time.timeScale = 1f;
        lo_pauseMenu.SetActive(false);
    }
}
