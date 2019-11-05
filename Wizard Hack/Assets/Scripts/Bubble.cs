using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bubble : MonoBehaviour
{
    public float speed = 3f;
    public int manaCost = 10;
    public float lifeTime = 3f;
    public Rigidbody2D rb;
    public Animator animator;
    public bool goingUp;
    public float topLevel;
    public float bottomLevel;
    public bool isPopped = false;

    // Start is called before the first frame update
    void Start()
    {
        topLevel = transform.position.y + 1;
        bottomLevel = transform.position.y - 1;
        rb.velocity = new Vector3(1,1,0);
        goingUp = true;
        Invoke("popBubble", lifeTime);
    }

    // Update is called once per frame
    void Update()
    {
        if(transform.position.y>topLevel || transform.position.y < bottomLevel)
        {
            changeDirection();
        }
    }

    void changeDirection()
    {
        if (goingUp)
        {
            rb.velocity = new Vector3(1, -1, 0);
            goingUp = false;
        }
        else
        {
            rb.velocity = new Vector3(1, 1, 0);
            goingUp = true;
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        EnemyHealth enemyHealth = collision.GetComponent<EnemyHealth>();
        if (enemyHealth != null && enemyHealth.isDead)
        {
            return;
        }
        if (enemyHealth != null)
        {
            popBubble();
        }

    }

    void popBubble()
    {
        isPopped = true;
        animator.SetBool("popped", true);
        Destroy(gameObject, 1);
    }

}
