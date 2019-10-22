using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Return_Home : MonoBehaviour
{

    public int c;

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
