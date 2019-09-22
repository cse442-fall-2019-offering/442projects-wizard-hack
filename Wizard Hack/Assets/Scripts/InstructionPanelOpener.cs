using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstructionPanelOpener : MonoBehaviour
{

	public GameObject Panel;

	public void openInstructionPanel(){
		if(Panel != null){
			bool isActive = Panel.activeSelf;
			Panel.SetActive(!isActive);
		}
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
