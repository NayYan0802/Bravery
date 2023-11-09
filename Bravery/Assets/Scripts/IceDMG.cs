using BehaviorDesigner.Runtime;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IceDMG : MonoBehaviour
{
    GameObject[] enemy;
    int sum=0;
    int sum2=0;

    private void OnTriggerStay(Collider other)
    {
        if ((other.gameObject.layer == LayerMask.NameToLayer("EnemyHUO") || other.gameObject.layer == LayerMask.NameToLayer("Enemy")) && other.tag == "Enemy")
        {
            other.GetComponent<EnemyMagicControll>().enterSuperIceTime += Time.deltaTime;
            other.GetComponent<EnemyAniControll>().TakeDamage(Time.deltaTime * 20);
            other.GetComponent<Animator>().enabled = false;
            other.GetComponent<BehaviorTree>().enabled = false;            
        }
        if (other.name=="Dragon")
        {
            other.GetComponent<EnemyMagicControll>().enterSuperIceTime += Time.deltaTime;
            other.GetComponent<DragonControll>().TakeDamage(Time.deltaTime * 20);
            other.GetComponent<Animator>().enabled = false;
        }
    }

    private void Start()
    {
        this.GetComponent<AudioSource>().Play();
        Invoke("DestroySelf",10);
    }

    private void DestroySelf()
    {
        Destroy(this.gameObject);
    }
}
