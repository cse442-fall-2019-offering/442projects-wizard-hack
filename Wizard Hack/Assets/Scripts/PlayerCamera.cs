using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/*
 * This class allows the camera to follow the player
 * included methods: FixedUpdate
 */
public class PlayerCamera : MonoBehaviour
{
    public Transform lo_PlayerMovement;

    // Update is called once per frame
    /*
     * input: none
     * output: none
     * updates camera such that it follows the player
     */
    void FixedUpdate()
    {
        transform.position = new Vector3(lo_PlayerMovement.position.x, lo_PlayerMovement.position.y, transform.position.z);
    }
}
