using BehaviorDesigner.Runtime;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagicDamage : MonoBehaviour
{

    public GameObject wizard;
    private GameObject[] Enemys;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Enemys = GameObject.FindGameObjectsWithTag("Enemy");
        //Debug.Log(Enemys.Length);
    }

    private void OnTriggerStay(Collider other)
    {        
        switch (wizard.GetComponent<twoAnimationController>().skinSum)
        {
            case 1:
                if (other.gameObject.layer == LayerMask.NameToLayer("EnemyBING") || other.gameObject.layer == LayerMask.NameToLayer("Enemy")&& other.GetComponent<EnemyAniControll>())
                {
                    other.GetComponent<EnemyAniControll>().TakeDamage(Time.deltaTime);
                }
                if (other.name=="Dragon")
                {
                    other.GetComponent<DragonControll>().TakeDamage(Time.deltaTime);
                }
                break;
            case 2:
                if (other.gameObject.layer == LayerMask.NameToLayer("EnemyHUO")|| other.gameObject.layer == LayerMask.NameToLayer("Enemy")&& other.GetComponent<EnemyAniControll>())
                {                    
                    other.GetComponent<EnemyAniControll>().TakeDamage(Time.deltaTime*0.5f);
                    other.GetComponent<EnemyMagicControll>().enterIceTime += Time.deltaTime;
                }
                if (other.name == "Dragon")
                {
                    other.GetComponent<DragonControll>().TakeDamage(Time.deltaTime*0.5f);
                    other.GetComponent<EnemyMagicControll>().enterIceTime += Time.deltaTime;
                }
                break;
            default:
                break;
        }
    }
}
