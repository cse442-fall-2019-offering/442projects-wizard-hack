using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;
/*
 * This class is used to keep track of the player's health and mana
 * included methods: Start, Update, damagePlayer, healPlayer, useMana, gainMana
 */
public class PlayerHealth : MonoBehaviour
{

    public int li_initialHealth = 100;
    public int li_playerCurrentHealth;
    public float lf_initialMana = 100;
    public float lf_playerCurrentMana;
    public float lf_manaRegenRate = .1f;
    public Slider lo_playerHealthSlider;
    public Slider lo_playerManaSlider;
    public Image lo_damageImage;

    bool lb_playerDead;
    bool lb_playerDamaged;
    // Start is called before the first frame update
    /*
     * input: void
     * output: void
     * initialized the player's health and mana
     */
    void Start()
    {
        /* the current health of the player should be the initial value when starting game*/
        li_playerCurrentHealth = li_initialHealth;
        lf_playerCurrentMana = lf_initialMana;
    }

    // Update is called once per frame
    /*
     * input: void
     * output: void
     * alters the player's health and mana each frame; ends game if player is dead
     */
    void Update()
    {
        
        if (lf_playerCurrentMana + lf_manaRegenRate > lf_initialMana)
        {
            lf_playerCurrentMana = lf_initialMana;
        }
        else if (lf_playerCurrentMana < lf_initialMana)
        {
            gainMana(lf_manaRegenRate);
        }
        if(li_playerCurrentHealth <= 0)
        {
  
            SceneManager.LoadScene("Game_Over_Screen");
        }
    }

    /*
     * input: damageAmount: (int) how much damage the player has taken this frame
     * output: void
     * updates the players health for the current frame
     */

    public void damagePlayer(int damageAmount)
    {
        li_playerCurrentHealth -= damageAmount;
        lo_playerHealthSlider.value = li_playerCurrentHealth;
    }


    /*
     * input: healingAmount: (int) how much damage the player healed this frame
     * output: void
     * updates the player's health for this frame
     */
    public void healPlayer(int healingAmount)
    {
        li_playerCurrentHealth += healingAmount;
        lo_playerHealthSlider.value = li_playerCurrentHealth;
    }

    /*
     * input: usedAmount: (float) how much mana the player used this frame
     * output: void
     * depletes the player's mana for this frame
     */
    public void useMana(float usedAmount)
    {
        lf_playerCurrentMana -= usedAmount;
        lo_playerManaSlider.value = lf_playerCurrentMana;
    }

    /*
     * input: gainAmount: (float) how much mana the player gained this frame
     * output: void
     * increases the player's mana for this frame
     */

    public void gainMana(float gainAmount)
    {
        if (lf_playerCurrentMana < lf_initialMana)
        {
            lf_playerCurrentMana += gainAmount;
        }
        
        lo_playerManaSlider.value = lf_playerCurrentMana;
    }

}
