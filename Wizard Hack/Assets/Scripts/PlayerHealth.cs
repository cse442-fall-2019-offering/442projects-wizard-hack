using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{

    public bool strength;
    public bool defense;
    public int initialHealth = 100;
    public int playerCurrentHealth;
    public float initialMana = 100;
    public float playerCurrentMana;
    public float manaRegenRate = .1f;
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
        strength = false;
        defense = false;
    }

    public bool getStrength()
    {
        return strength;
    }

    // Update is called once per frame
    void Update()
    {
        
        if (playerCurrentMana + manaRegenRate > initialMana)
        {
            playerCurrentMana = initialMana;
        }
        else if (playerCurrentMana < initialMana)
        {
            gainMana(manaRegenRate);
        }
        if(playerCurrentHealth <= 0)
        {
            SceneManager.LoadScene("Game_Over_Screen");
        }
        // Debug.Log("Text: " + strength);
    }


    public void damagePlayer(int damageAmount)
    {
        playerCurrentHealth -= damageAmount;
        playerHealthSlider.value = playerCurrentHealth;
    }

    public void healPlayer(int healingAmount)
    {
        playerCurrentHealth += healingAmount;
        if (playerCurrentHealth>100)
        {
            playerCurrentHealth = 100;
        }
        playerHealthSlider.value = playerCurrentHealth;
    }

    public void useMana(float usedAmount)
    {
        playerCurrentMana -= usedAmount;
        playerManaSlider.value = playerCurrentMana;
    }

    public void gainMana(float gainAmount)
    {
        playerCurrentMana += gainAmount;
        if (playerCurrentMana>100)
        {
            playerCurrentMana = 100;
        }
        playerManaSlider.value = playerCurrentMana;
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if(col.CompareTag("itemHealth"))
        {
            Destroy(col.gameObject);
            healPlayer(40);
        }
        else if(col.CompareTag("itemMana"))
        {
            Destroy(col.gameObject);
            gainMana(40);
        }
        else if(col.CompareTag("itemStrength"))
        {
            Destroy(col.gameObject);
            addStrength();
        }
    }

    public void addStrength()
    {
        strength = true;
        Invoke ("turnFalse", 5);
        
    }
    void turnFalse()
    {
        strength = false;
    }

}
