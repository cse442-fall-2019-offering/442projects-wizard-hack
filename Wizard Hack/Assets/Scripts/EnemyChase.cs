using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyChase : MonoBehaviour
{
	public float speed;
	public float distanceToStartAttack;

	private Transform player;
	private float x;
	private float y;
	private float z;
    // Start is called before the first frame update
    void Start()
    {
        x = 5;
        y = 5;
        z = 5;
        transform.localScale = new Vector3(x, y, z);
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
    	float distanceToPlayer = Vector2.Distance(transform.position, player.position);
        if(distanceToPlayer < distanceToStartAttack && distanceToPlayer > 1) {
	    	// ** LOOK AT PLAYER **
	        Vector3 distanceVector = player.position - transform.position;
	        // Debug.Log(direction[0]);
	        if (distanceVector[0]>=0){
	        	transform.localScale = new Vector3(x, y, z);
	        } else {
	        	transform.localScale = new Vector3(-x, y, z);
	        }
	        // ** End **

        	// ** CHASE PLAYER **

            	transform.position = Vector2.MoveTowards(transform.position, player.position, speed*Time.deltaTime);

        }
        // ** End **
    }


   	void moveEnemy(Vector2 a){

   	}
}
