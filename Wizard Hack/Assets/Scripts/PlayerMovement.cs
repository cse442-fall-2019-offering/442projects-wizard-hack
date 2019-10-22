using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f;
    public Rigidbody2D rb;
    public Animator animator;

    Vector2 movement;


    // Update is called once per frame
    void Update()
    {
        movement.x=Input.GetAxisRaw("Horizontal");
        movement.y= Input.GetAxisRaw("Vertical");

        animator.SetFloat("Horizontal", movement.x);
        animator.SetFloat("Vertical", movement.y);
        animator.SetFloat("Speed", movement.sqrMagnitude);

        updateFirePointandAnimatorFacing();
    }

    void updateFirePointandAnimatorFacing()
    {
        if (Input.GetKeyDown("up"))
        {
            animator.SetInteger("Facing", 0);
            MagicShooting magicShooting = gameObject.GetComponent<MagicShooting>();
            Quaternion quaternion = Quaternion.Euler(0, 0, 90);
            magicShooting.firePoint.SetPositionAndRotation(magicShooting.firePoint.position, quaternion);
        }
        if (Input.GetKeyDown("right"))
        {
            animator.SetInteger("Facing", 1);
            MagicShooting magicShooting = gameObject.GetComponent<MagicShooting>();
            Quaternion quaternion = Quaternion.Euler(0, 0, 0);
            magicShooting.firePoint.SetPositionAndRotation(magicShooting.firePoint.position, quaternion);
        }
        if (Input.GetKeyDown("down"))
        {
            animator.SetInteger("Facing", 2);
            MagicShooting magicShooting = gameObject.GetComponent<MagicShooting>();
            Quaternion quaternion = Quaternion.Euler(0, 0, -90);
            magicShooting.firePoint.SetPositionAndRotation(magicShooting.firePoint.position, quaternion);
        }
        if (Input.GetKeyDown("left"))
        {
            animator.SetInteger("Facing", 3);
            MagicShooting magicShooting = gameObject.GetComponent<MagicShooting>();
            Quaternion quaternion = Quaternion.Euler(0, 0, 180);
            magicShooting.firePoint.SetPositionAndRotation(magicShooting.firePoint.position, quaternion);
        }
    }

    void FixedUpdate(){
        rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime); 
    }
}
