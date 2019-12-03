using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagicShooting : MonoBehaviour
{
    public Transform firePoint;
    public Fireball fireball;
    public Bubble bubble;
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

        if (Input.GetKeyDown(KeyCode.R))
        {
            playerHealth = gameObject.GetComponent<PlayerHealth>();
            if (playerHealth.playerCurrentMana >= bubble.manaCost)
            {
                blowBubble(bubble.manaCost);
            }
        }
    }

    void shoot(float manaCost)
    {
        playerHealth.useMana(manaCost);
        Instantiate(fireball, firePoint.position, firePoint.rotation);    
    }

    void blowBubble(float manaCost)
    {
        playerHealth.useMana(manaCost);
        Bubble bub = Instantiate(bubble, firePoint.position, firePoint.rotation);
        LevelController.NotifyEnemiesAboutBubble(bub);
    }
}
