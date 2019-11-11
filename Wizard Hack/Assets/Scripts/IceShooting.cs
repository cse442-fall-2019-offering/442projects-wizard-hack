using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IceShooting : MonoBehaviour
{
    public Transform firePoint;
    public Ice icePrefab;
    PlayerHealth playerHealth;

   



    // Update is called once per frame
    void Update() {
    	 if(Input.GetKeyDown(KeyCode.W)) {
    	 	playerHealth = gameObject.GetComponent<PlayerHealth>();
        	if(playerHealth.playerCurrentMana >= icePrefab.manaCost){
        		shootIce();
        	}
        }
    }

    void shootIce(){

    	playerHealth.useMana(icePrefab.manaCost);
    	Instantiate(icePrefab, firePoint.position, firePoint.rotation);
    }
}
