using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * This class is used for spells
 * included methods: Update, shoot
 */
public class MagicShooting : MonoBehaviour
{
    public Transform lo_firePoint;
    public Fireball lo_fireball;
    PlayerHealth lo_playerHealth;

    // Update is called once per frame
    /*
     * input: none
     * output: node 
     * shoots the fire ball if the q key has been pressed and the player has enough mana
     */
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            lo_playerHealth = gameObject.GetComponent<PlayerHealth>();            
            if (lo_playerHealth.lf_playerCurrentMana >= lo_fireball.manaCost)
            {
                shoot(lo_fireball.manaCost);
            }
        }
    }
    /*
     * input: manaCost: (float) how much mana is needed for 1 fireball
     * output: none
     * depletes the player's mana and fires the fireball
     */
    void shoot(float manaCost)
    {
        lo_playerHealth.useMana(manaCost);
        Instantiate(lo_fireball, lo_firePoint.position, lo_firePoint.rotation);    
    }
}
