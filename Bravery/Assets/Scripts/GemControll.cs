using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GemControll : MonoBehaviour
{
    public int maxHealth;
    public float currentHealth;

    public int damage;

    public HealthBar healthBar;

    private GameObject[] Players;

    void Start()
    {
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
        Players = GameObject.FindGameObjectsWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        if (currentHealth < 1)
        {   
            Die();
        }
    }

    public void Hitten(int hurt)
    {
        if (currentHealth - hurt < 1)
        {            
            Die();
        }
        else
        {            
            TakeDamage(hurt);
        }
    }

    public void TakeDamage(float damage)
    {
        currentHealth -= damage;
        healthBar.SetHealth(currentHealth);
    }

    void Die()
    {
        this.gameObject.SetActive(false);
    }   
}
