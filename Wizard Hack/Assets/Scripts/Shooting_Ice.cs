using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting_Ice : MonoBehaviour
{
   public Transform firePoint;
    public Ice ice;
    PlayerHealth playerHealth;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.W))
        {
            playerHealth = gameObject.GetComponent<PlayerHealth>();
            if (playerHealth.playerCurrentMana >= ice.manaCost)
            {
                shoot(ice.manaCost);
            }
        }
    }

    void shoot(float manaCost)
    {
        playerHealth.useMana(manaCost);
        Instantiate(ice, firePoint.position, firePoint.rotation);
    }
}
