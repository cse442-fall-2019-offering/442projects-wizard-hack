using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/*
 * This class is used to pull up the end game screen
 * Included methods: GoToHome, Start, Update
 */

public class Return_Home : MonoBehaviour
{

    
    /*
     * input: none
     * output: none
     * loads the game over screen
     */
    public void GoToHome(){
         SceneManager.LoadScene("Game_Over_Screen");
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
