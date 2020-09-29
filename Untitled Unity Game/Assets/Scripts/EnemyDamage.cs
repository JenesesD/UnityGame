using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyDamage : MonoBehaviour
{
    public float health;
    public float maxHealth;

    public GameObject healthBar;
    public Slider healthBarSlider;

    void Start()
    {
        // Sets up enemy health
        health = maxHealth;
    }

    public void CalculateDamageReceived(float damage)
    {
        healthBar.SetActive(true);
        // Calculates the incoming damage, and checks if the enemy is dead or not
        health -= damage;
        CheckIfEnemyIsDead();
        healthBarSlider.value = CalculateHealthPercentage();

    }

    public void CheckIfEnemyIsDead()
    {
        if (health <= 0)
        {
            // Destroys the specified game object
            // Destroy is inherited from UnityEngine.Object base class
            Destroy(gameObject);
        }
    }

    public void CheckForOverheal()
    {
        // Checks if the specific enemies health is above the given maxHealth
        // Possible healing enemies for future implementing
        if(health > maxHealth)
        {
            health = maxHealth;
        }
    }

    private float CalculateHealthPercentage()
    {
        return (health / maxHealth);
    }
}
