using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    public static PlayerStats playerStats;
    public GameObject player;
    public float health;
    public float maxHealth;

    void Awake()
    {
        if (playerStats != null)
        {
            Destroy(playerStats);
        }
        else
        {
            playerStats = this;
        }
        DontDestroyOnLoad(this);
    }

    void Start()
    {
        // Sets up player health
        health = maxHealth;
    }

    public void HealCharacter(float heal)
    {
        health += heal;
        CheckForOverheal();
    }

    public void CalculateDamageReceived(float damage)
    {
        // Calculates the incoming damage, and checks if the player is dead or not
        health -= damage;
        CheckIfPlayerIsDead();
    }

    public void CheckIfPlayerIsDead()
    {
        if (health <= 0)
        {
            // Destroys the player game object
            // Destroy is inherited from UnityEngine.Object base class
            Destroy(player);
        }
    }

    public void CheckForOverheal()
    {
        // Checks if the players health is above the given maxHealth
        // Possible healing items/consumables for future implementing
        if (health > maxHealth)
        {
            health = maxHealth;
        }
    }
}
