using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fireball : MonoBehaviour
{
    public float speed=10f;
    public int damage=20;
    public int manaCost=10;
    public int lifeTime=2;
    public Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        rb.velocity = transform.right * speed;
        Destroy(gameObject, lifeTime);
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
            enemyHealth.damageEnemy(damage);
        }
        Destroy(gameObject);
    }
}
