using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ice : MonoBehaviour
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

    // Update is called once per frame
    void OnTriggerEnter2D(Collider2D collision)
    {
        
        EnemyHealth enemyHealth = collision.GetComponent<EnemyHealth>();
        EnemyChase enemyChase =  collision.GetComponent<EnemyChase>();
          if (enemyHealth != null && enemyHealth.isDead)
        {
            return;
        }
        if (enemyHealth != null)
        {
           float s = enemyChase.speed;
           enemyChase.speed=s-(s/3);
          /* while(enemyChase.speed < s){
            enemyChase.speed+=1;
           }*/
         
           // enemyHealth.damageEnemy(damage);
            Destroy(gameObject);
            //enemyChase.speed=s;
        }
    }
}
