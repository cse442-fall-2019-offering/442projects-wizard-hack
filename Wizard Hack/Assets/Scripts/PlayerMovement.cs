using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * this class allows the player to move and shoot fireballs
 * methods: Update, updateFirePointandAnimatorFacing, fixedUpdate
 */
public class PlayerMovement : MonoBehaviour
{
    public float lf_moveSpeed = 5f;
    public Rigidbody2D lo_rb;
    public Animator lo_animator;

    Vector2 lo_movement;


    // Update is called once per frame
    /*
     * input: none
     * output:
     * updates the position of the player
     */
    void Update()
    {
        lo_movement.x=Input.GetAxisRaw("Horizontal");
        lo_movement.y= Input.GetAxisRaw("Vertical");

        lo_animator.SetFloat("Horizontal", lo_movement.x);
        lo_animator.SetFloat("Vertical", lo_movement.y);
        lo_animator.SetFloat("Speed", lo_movement.sqrMagnitude);

        updateFirePointandAnimatorFacing();
    }
    /*
     * input: none
     * output: none
     * updates the direction of the players fireball
     */
    void updateFirePointandAnimatorFacing()
    {
        if (Input.GetKeyDown("up"))
        {
            lo_animator.SetInteger("Facing", 0);
            MagicShooting magicShooting = gameObject.GetComponent<MagicShooting>();
            Quaternion quaternion = Quaternion.Euler(0, 0, 90);
            magicShooting.lo_firePoint.SetPositionAndRotation(magicShooting.lo_firePoint.position, quaternion);
        }
        if (Input.GetKeyDown("right"))
        {
            lo_animator.SetInteger("Facing", 1);
            MagicShooting magicShooting = gameObject.GetComponent<MagicShooting>();
            Quaternion quaternion = Quaternion.Euler(0, 0, 0);
            magicShooting.lo_firePoint.SetPositionAndRotation(magicShooting.lo_firePoint.position, quaternion);
        }
        if (Input.GetKeyDown("down"))
        {
            lo_animator.SetInteger("Facing", 2);
            MagicShooting magicShooting = gameObject.GetComponent<MagicShooting>();
            Quaternion quaternion = Quaternion.Euler(0, 0, -90);
            magicShooting.lo_firePoint.SetPositionAndRotation(magicShooting.lo_firePoint.position, quaternion);
        }
        if (Input.GetKeyDown("left"))
        {
            lo_animator.SetInteger("Facing", 3);
            MagicShooting magicShooting = gameObject.GetComponent<MagicShooting>();
            Quaternion quaternion = Quaternion.Euler(0, 0, 180);
            magicShooting.lo_firePoint.SetPositionAndRotation(magicShooting.lo_firePoint.position, quaternion);
        }
    }

    /*
     * input: none
     * output: none
     * move the player's collider
     */

    void FixedUpdate(){
        lo_rb.MovePosition(lo_rb.position + lo_movement * lf_moveSpeed * Time.fixedDeltaTime); 
    }
}
