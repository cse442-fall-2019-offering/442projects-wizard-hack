using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartMenu : MonoBehaviour
{

    public GameObject Instructions;
    public GameObject Menu;
   public void PlayGame()
    {

    }

    public void QuitGame()
    {
        Debug.Log("Quit");
        Application.Quit();
    }


    public void LoadInstructions(int level)
    {
        Instructions.SetActive(true);
        Menu.SetActive(false);
        //Application.LoadLevel(level);
        
    }

    public void BackToMain()
    {
        Instructions.SetActive(false);
        Menu.SetActive(true);
    }
}
