using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagicShooting : MonoBehaviour
{
    public Transform firePoint;
    public Fireball fireball;
    PlayerHealth playerHealth;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            playerHealth = gameObject.GetComponent<PlayerHealth>();            
            if (playerHealth.playerCurrentMana >= fireball.manaCost)
            {
                shoot(fireball.manaCost);
            }
        }
    }

    void shoot(float manaCost)
    {
        //playerHealth.useMana(manaCost);
        Instantiate(fireball, firePoint.position, firePoint.rotation);    
    }
}
