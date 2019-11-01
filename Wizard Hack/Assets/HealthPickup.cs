using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPickup : MonoBehaviour
{
	public int replenishAmount;
	public GameObject my_player;
    PlayerHealth ph;
    // Start is called before the first frame update
    void Start()
    {
        ph = my_player.GetComponent<PlayerHealth>();
        // player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log("ph: "+ph.playerCurrentHealth);
    }

    void replenishHealth(){
    	ph.healPlayer(replenishAmount);
    }


}
