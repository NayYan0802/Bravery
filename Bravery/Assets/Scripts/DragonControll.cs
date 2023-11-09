using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.SceneManagement;

public class DragonControll : MonoBehaviour
{
    const int dst = 3;
    public GameObject bow;
    public GameObject wizard;
    public int status;
    public int step;
    public float time;

    Animator animator;

    public GameObject Egg;
    public GameObject BigEgg;
    public GameObject Monster;
    public GameObject[] MonsterStone;
    public GameObject Fire;
    public HealthBar bossHealthBar;
    public float bossHealth;
    public GameObject shield;

    bool isShield;

    public PlayableDirector TurnAround;

    private GameObject[] Enemy;
    private Vector3[] EnemyPos = new Vector3[8];
    private Vector3 EggPos;

    bool FirstWave;
    bool SecondWave;
    bool ThirdWave;

    public GameObject[] Gem;

    AudioSource wings;


    void Start()
    {
        wings = GameObject.Find("DragonFlapWings").GetComponent<AudioSource>();
        bossHealth = 1000;
        isShield = true;
        animator = this.GetComponent<Animator>();
        time = -0.5f;
        status = 1;
        step = 1;
        animator.SetTrigger("Fly Idle");
        FirstWave = true;
        SecondWave = true;
        wings.Play();
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(step);
        Enemy = GameObject.FindGameObjectsWithTag("Enemy");
        time += Time.deltaTime;
        switch (status)
        {
            case 1:
                Status1();
                break;
            case 2:
                Status2();
                break;
            case 3:
                Status3();
                break;
            case 4:
                Status4();
                break;
            default:
                break;
        }

        int gemSum = 0;

        for (int i = 0; i < 3; i++)
        {
            if(Gem[i].GetComponent<GemControll>().currentHealth < 0)
            {
                gemSum++;
            }
        }

        if (gemSum==1&&FirstWave)
        {
            Invoke("Egging",1);
            Invoke("BigEgging",1);
            Invoke("Monstering",3);
            Invoke("BigMonstering",3);
            FirstWave = false;

        }
        if (gemSum==2&&SecondWave)
        {
            Invoke("Egging",1); 
            Invoke("BigEgging", 1);
            Invoke("Monstering", 3);
            Invoke("BigMonstering", 3);
            SecondWave = false;
        }

        if (gemSum==3&&ThirdWave)
        {
            if (animator.GetCurrentAnimatorStateInfo(0).IsName("FlyFireBreathAttack-Middle"))
            {
                animator.SetTrigger("Stun");
                Fire.SetActive(false);
            } else if (animator.GetCurrentAnimatorStateInfo(0).IsName("FlyIdle")) 
            {
                animator.SetTrigger("Fly Idle");
            }
            else
            {
                Debug.Log("woshishabi");
            }

            TurnAround.Stop();

            shield.SetActive(false);
            isShield = false;
            bossHealthBar.gameObject.SetActive(true);
            status = 4;
            step = 20;
            time = 0;
            ThirdWave = false;
            return;
        }

        if (bossHealth < 0)
        {
            SceneManager.LoadScene("Success");
        }

        //if(Vector3.Distance(transform.position,bow.transform.position)> Vector3.Distance(transform.position, wizard.transform.position))
        //{
        //    this.transform.LookAt(wizard.transform,Vector3.up);
        //}
        //else
        //{
        //    this.transform.LookAt(bow.transform, Vector3.up);
        //}
    }


    private void Status1()
    {
        if (time > 1&&step==1)
        {
            animator.SetTrigger("Fly Cast Spell");
            this.GetComponent<AudioSource>().Play();
            step = 2;
        }
        if (time > 2 && step == 2)
        {
            Egging();
            step = 3;
        }
        if (time > 4f && step == 3)
        {
            Monstering();
            step = 4;
        }
        if (time > 9 && step == 4)
        {
            wings.Stop();
            animator.SetTrigger("Fly Fire Breath Attack");
            //Fire.SetActive(true);
            step = 5;
        }
        if (time > 9.77f && step == 5)
        {
            TurnAround.Play();
            Fire.SetActive(true);
            step = 6;
        }
        if (time > 14.77f && step == 6)
        {
            animator.SetTrigger("Fly Fire Breath Attack");
            Fire.SetActive(false);
            wings.Play();
            step = 7;
            time = 0;
            status = 2;
            return;
        }
    }

    private void Status2()
    {
        if (time > 1 && step == 7)
        {
            animator.SetTrigger("Fly Cast Spell");
            this.GetComponent<AudioSource>().Play();
            step = 8;
        }
        if (time > 2 && step == 8)
        {
            Egging();
            step = 9;
        }
        if (time > 4 && step == 9)
        {
            Monstering();
            step = 10;
        }
        if (time > 12 && step == 10)
        {
            Debug.Log(Enemy.Length);
            if (Enemy.Length == 0)
            {
                time = 0;
                step = 14;
                status = 3;
                return;
            }else if(Enemy.Length >= 1)
            {
                step = 11;
                status = 2;
                return;
            }            
        }
        if (time > 12 && step == 11)
        {
            animator.SetTrigger("Fly Fire Breath Attack");
            wings.Stop();
            step = 12;
        }
        if (time > 12.77f && step == 12)
        {
            TurnAround.Play();
            Fire.SetActive(true);
            step = 13;
        }
        if (time > 17.77f && step == 13)
        {
            animator.SetTrigger("Fly Fire Breath Attack");
            wings.Play();
            Fire.SetActive(false);
            step = 7;
            time = 0;
        }
    }

    private void Status3()
    {
        if (time > 1.5f && step == 14)
        {
            animator.SetTrigger("Fly Cast Spell");
            Gem[0].GetComponent<GemControll>().currentHealth = 100;
            Gem[1].GetComponent<GemControll>().currentHealth = 100;
            Gem[2].GetComponent<GemControll>().currentHealth = 100;
            Gem[0].GetComponent<GemControll>().healthBar.SetHealth(100);
            Gem[1].GetComponent<GemControll>().healthBar.SetHealth(100);
            Gem[2].GetComponent<GemControll>().healthBar.SetHealth(100);
            Gem[0].SetActive(true);
            Gem[1].SetActive(true);
            Gem[2].SetActive(true);
            shield.SetActive(true);
            FirstWave = SecondWave = ThirdWave = true;
            isShield = true;
            step = 15;
        }
        if (time > 2 && step == 15)
        {
            Instantiate(BigEgg,(bow.transform.position+wizard.transform.position)*0.5f,Quaternion.identity);
            EggPos = (bow.transform.position + wizard.transform.position) * 0.5f;
            step = 16;
        }
        if (time > 4 && step == 16)
        {
            Instantiate(MonsterStone[UnityEngine.Random.Range(0,3)], EggPos, Quaternion.identity);
            step = 17;
        }
        if (time > 9 && step == 17)
        {
            animator.SetTrigger("Fly Fire Breath Attack");
            wings.Stop();
            //Fire.SetActive(true);
            step = 18;
        }
        if (time > 9.77f && step == 18)
        {
            TurnAround.Play();
            Fire.SetActive(true);
            step = 19;
        }
        if (time > 14.77f && step == 19)
        {
            animator.SetTrigger("Fly Fire Breath Attack");
            wings.Play();
            Fire.SetActive(false);
            step = 17;
            time = 7;            
        }
    }

    private void Status4()
    {
        if (time > 1 && step == 20)
        {
            if (animator.GetCurrentAnimatorStateInfo(0).IsName("FlyIdle"))
            {
                animator.SetTrigger("Fly Idle");
                Fire.SetActive(false);
            }
            step = 21;
        }
        if (time > 10 && step == 21)
        {
            animator.SetTrigger("Fly Idle");
            time = 0;
            step = 14;
            status = 3;
            return;
        }
    }

    public void Hitten(int hurt)
    {
        if (bossHealth - hurt < 1)
        {
            this.GetComponent<Animator>().SetTrigger("Die");
            //Invoke("Die", 1f);
            Die();
        }
    }

    public void TakeDamage(float damage)
    {
        if (!isShield)
        {
            bossHealth -= damage;
            bossHealthBar.SetHealth(bossHealth);
        }
    }

    void Die()
    {
        Destroy(this.gameObject);
    }

    void Egging()
    {
        EnemyPos[0]= bow.transform.position - Vector3.forward;
        EnemyPos[1]= bow.transform.position - Vector3.left;
        EnemyPos[2]= bow.transform.position + Vector3.forward;
        EnemyPos[3]= bow.transform.position + Vector3.left;
        EnemyPos[4]= wizard.transform.position - Vector3.forward;
        EnemyPos[5]= wizard.transform.position - Vector3.left;
        EnemyPos[6]= wizard.transform.position + Vector3.forward;
        EnemyPos[7]= wizard.transform.position + Vector3.left;
        Instantiate(Egg, bow.transform.position - Vector3.forward, Quaternion.identity);
        Instantiate(Egg, bow.transform.position - Vector3.left, Quaternion.identity);
        Instantiate(Egg, bow.transform.position + Vector3.forward, Quaternion.identity);
        Instantiate(Egg, bow.transform.position + Vector3.left, Quaternion.identity);
        Instantiate(Egg, wizard.transform.position - Vector3.forward, Quaternion.identity);
        Instantiate(Egg, wizard.transform.position - Vector3.left, Quaternion.identity);
        Instantiate(Egg, wizard.transform.position + Vector3.forward, Quaternion.identity);
        Instantiate(Egg, wizard.transform.position + Vector3.left, Quaternion.identity);
    }

    void Monstering()
    {
        Instantiate(Monster, EnemyPos[0], Quaternion.identity);
        Instantiate(Monster, EnemyPos[1], Quaternion.identity);
        Instantiate(Monster, EnemyPos[2], Quaternion.identity);
        Instantiate(Monster, EnemyPos[3], Quaternion.identity);
        Instantiate(Monster, EnemyPos[4], Quaternion.identity);
        Instantiate(Monster, EnemyPos[5], Quaternion.identity);
        Instantiate(Monster, EnemyPos[6], Quaternion.identity);
        Instantiate(Monster, EnemyPos[7], Quaternion.identity);
    }

    void BigEgging()
    {
        Instantiate(BigEgg, (bow.transform.position + wizard.transform.position) * 0.5f, Quaternion.identity);
        EggPos = (bow.transform.position + wizard.transform.position) * 0.5f;
    }

    void BigMonstering()
    {
        Instantiate(MonsterStone[UnityEngine.Random.Range(0, 3)], EggPos, Quaternion.identity);
    }
    
}
