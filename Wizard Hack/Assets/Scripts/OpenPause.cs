using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class OpenPause : MonoBehaviour
{

	public void goToPause(){
		        SceneManager.LoadScene("dummybuttons");

	}
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
    	if(Input.GetKeyDown(KeyCode.P)){

       		SceneManager.LoadScene("dummybuttons");

    	}
        
    }
}
