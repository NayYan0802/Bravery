using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightningDMG : MonoBehaviour
{
    GameObject enemy;
    GameObject boss;
    GameObject bossTakeDMG;
    AudioSource ThunderSound;

    private void Start()
    {
        ThunderSound = GameObject.Find("ThunderSound").GetComponent<AudioSource>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if ((other.gameObject.layer == LayerMask.NameToLayer("EnemyBING") || other.gameObject.layer == LayerMask.NameToLayer("Enemy"))&&other.tag=="Enemy")
        {
            Invoke("Boom",0.8f);
            enemy = other.gameObject;
            //other.GetComponent<EnemyAniControll>().TakeDamage(500);
        }
        if (other.transform.parent.name=="Dragon")
        {
            Invoke("BossBoom", 0.8f);
            //other.GetComponent<EnemyAniControll>().TakeDamage(500);
        }
    }

    void Boom()
    {
        ThunderSound.Play();
        enemy.GetComponent<EnemyAniControll>().TakeDamage(500);
        Destroy(this.gameObject);
    }

    void BossBoom()
    {
        ThunderSound.Play();
        bossTakeDMG = GameObject.Find("DragonTakeDamage");
        boss = GameObject.Find("Dragon");
        boss.GetComponent<DragonControll>().TakeDamage(500);
        boss.GetComponent<Animator>().SetTrigger("Take Damage");
        bossTakeDMG.GetComponent<AudioSource>().Play();
        Destroy(this.gameObject);
    }
}
