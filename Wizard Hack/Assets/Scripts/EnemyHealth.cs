using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{

    public int initialHealth = 100;
    public int enemyCurrentHealth;
    // Start is called before the first frame update
    void Start()
    {
        /* enemy initial health should be 100 when starting */
        enemyCurrentHealth = initialHealth;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void damageEnemy(int damageAmount)
    {
        enemyCurrentHealth -= damageAmount;
    }
}
