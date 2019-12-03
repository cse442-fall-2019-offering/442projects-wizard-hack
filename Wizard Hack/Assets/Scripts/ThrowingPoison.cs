using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThrowingPoison : MonoBehaviour
{
    public Transform PoisonPoint;
    public Poison poison;
    PlayerHealth playerHealth;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            playerHealth = gameObject.GetComponent<PlayerHealth>();
            if (playerHealth.playerCurrentMana >= poison.manaCost)
            {
                shoot(poison.manaCost);
            }
        }
    }

    void shoot(float manaCost)
    {
        playerHealth.useMana(manaCost);
        Instantiate(poison, PoisonPoint.position, PoisonPoint.rotation);
    }
}
