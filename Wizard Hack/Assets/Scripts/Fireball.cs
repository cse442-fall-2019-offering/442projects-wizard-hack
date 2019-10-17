using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fireball : MonoBehaviour
{

    public float speed = 20f;
    public int damage = 20;
    public Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
       // rb.velocity = transform.right * speed;
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        EnemyHealth enemyHealth = collision.GetComponent<EnemyHealth>();
        if(enemyHealth!=null)
        {
            enemyHealth.damageEnemy(damage);   
        }
        Destroy(gameObject);
    }
}
