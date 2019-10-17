using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagicShooting : MonoBehaviour
{
    public Transform firePoint;
    public GameObject magicPrefab;
    PlayerHealth playerHealth;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            playerHealth = gameObject.GetComponent<PlayerHealth>();
            
            if (playerHealth.playerCurrentMana >= 15)
            {
                shoot(15f);
            }
        }
    }

    void shoot(float manaCost)
    {
        playerHealth.useMana(manaCost);
        Instantiate(magicPrefab, firePoint.position, firePoint.rotation);
    }
}
