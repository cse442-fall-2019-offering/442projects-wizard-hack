using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHealth : MonoBehaviour
{

    public int initialHealth = 100;
    public int enemyCurrentHealth;
    public Slider enemyHealthSlider;
    // Start is called before the first frame update
    void Start()
    {
        /* enemy initial health should be 100 when starting */
        enemyCurrentHealth = initialHealth;
    }

    public void damageEnemy(int damageAmount)
    {
        enemyCurrentHealth -= damageAmount;
        enemyHealthSlider.value -= enemyCurrentHealth;
    }



}
