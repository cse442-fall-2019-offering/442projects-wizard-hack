using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fireball : MonoBehaviour
{
    public float speed=10f;
    public int damage;
    public int manaCost=10;
    public int lifeTime=2;
    public Rigidbody2D rb;
    private PlayerHealth playerHealth;

    // Start is called before the first frame update
    void Start()
    {
        rb.velocity = transform.right * speed;
        Destroy(gameObject, lifeTime);
        playerHealth = FindObjectOfType(typeof(PlayerHealth)) as PlayerHealth;
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if(playerHealth.strength)
        {
            damage = 50;
        } else {
            damage = 20;
        }
        EnemyHealth enemyHealth = collision.GetComponent<EnemyHealth>();
        if (enemyHealth != null && enemyHealth.isDead)
        {
            return;
        }
        if (enemyHealth != null)
        {
            enemyHealth.damageEnemy(damage);
            Destroy(gameObject);
        }
        
    }
}
