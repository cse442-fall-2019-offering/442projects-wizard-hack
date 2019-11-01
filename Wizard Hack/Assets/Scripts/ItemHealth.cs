using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemHealth : MonoBehaviour
{
    private Transform player;
    private Transform item;
    private float distanceToPlayer;
    public GameObject my_player;
    PlayerHealth ph;



    // Start is called before the first frame update
    void Start()
    {
        ph = my_player.GetComponent<PlayerHealth>();
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        distanceToPlayer = Vector2.Distance(this.transform.position, player.position);
        Debug.Log("itemPos: "+this.transform.position);
        Debug.Log("playaPos: "+player.position);
        // if (distanceToPlayer<=1){
        // 	// gameObject.active = false;
        //  //    Debug.Log("yoooo");
        // }
    }
}
