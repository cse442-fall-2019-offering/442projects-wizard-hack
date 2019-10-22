using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/*
 * this class is used to bring up the pause menu
 * included methods: goToPause, Start, Update
 */

public class OpenPause : MonoBehaviour
{
    /*
     * input: void
     * output: void 
     * loads the pause sceene
     */
	public void goToPause(){
		        SceneManager.LoadScene("dummybuttons");

	}
    // Start is called before the first frame update
    void Start()
    {
        
    }
    /*
     * input: void
     * output: void
     * loads the pause scene if the P key has been pressed in the current frame
     */
    // Update is called once per frame
    void Update()
    {
    	if(Input.GetKeyDown(KeyCode.P)){

       		SceneManager.LoadScene("dummybuttons");

    	}
        
    }
}
