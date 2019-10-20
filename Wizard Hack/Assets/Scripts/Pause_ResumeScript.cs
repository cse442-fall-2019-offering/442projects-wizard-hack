using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Pause_ResumeScript : MonoBehaviour
{
	
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
      if(Input.GetKeyDown(KeyCode.P)){

       		SceneManager.LoadScene("dummy buttons");

    	}
    	
        
    }
}
