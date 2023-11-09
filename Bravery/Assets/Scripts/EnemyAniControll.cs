using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BehaviorDesigner.Runtime;

public class EnemyAniControll : MonoBehaviour
{
    public int maxHealth;
    public float currentHealth;

    public HealthBar healthBar1;
    public HealthBar healthBar2;

    private bool isHitten;


    void Start()
    {
        currentHealth = maxHealth;
        healthBar1.SetMaxHealth(maxHealth);
        healthBar2.SetMaxHealth(maxHealth);
        isHitten = false;
    }

    // Update is called once per frame
    void Update()
    {        
        if (currentHealth < 1)
        {
            this.GetComponent<Animator>().SetTrigger("Die");
            this.GetComponent<BehaviorTree>().DisableBehavior();
            //Invoke("Die", 1f);
            Die();
        }
    }

    public void Hitten(int hurt)
    {       
        if (currentHealth-hurt<1)
        {
            this.GetComponent<Animator>().SetTrigger("Die");
            this.GetComponent<BehaviorTree>().DisableBehavior();
            //Invoke("Die", 1f);
            Die();
        }
        else if(!isHitten)
        {
            this.GetComponent<Animator>().SetTrigger("Take Damage");
            TakeDamage(hurt);
            isHitten = true;
            Invoke("NoHit",1);
        }
    }

    public void TakeDamage(float damage)
    {
        currentHealth -= damage;
        healthBar1.SetHealth(currentHealth);
        healthBar2.SetHealth(currentHealth);
    }

    void Die()
    {
        Destroy(this.gameObject);
    }

    void NoHit()
    {
        isHitten = false;
    }
}
