using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{

    public int initialHealth = 100;
    public int playerCurrentHealth;
    public int initialMana = 100;
    public int playerCurrentMana;
    public Slider playerHealthSlider;
    public Slider playerManaSlider;
    public Image damageImage;

    bool playerDead;
    bool playerDamaged;
    // Start is called before the first frame update
    void Start()
    {
        /* the current health of the player should be the initial value when starting game*/
        playerCurrentHealth = initialHealth;
        playerCurrentMana = initialMana;
    }

    // Update is called once per frame
    void Update()
    {
        if(initialHealth <= 0)
        {
            SceneManager.LoadScene("Game_Over");
        }
    }


    public void damagePlayer(int damageAmount)
    {
        playerCurrentHealth -= damageAmount;
        playerHealthSlider.value = playerCurrentHealth;
    }

    public void healPlayer(int healingAmount)
    {
        playerCurrentHealth += healingAmount;
        playerHealthSlider.value = playerCurrentHealth;
    }

    public void useMana(int usedAmount)
    {
        playerCurrentMana -= usedAmount;
        playerManaSlider.value = playerCurrentMana;
    }

    public void gainMana(int gainAmount)
    {
        playerCurrentMana += gainAmount;
        playerManaSlider.value = playerCurrentMana;
    }

}
