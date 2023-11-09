using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BehaviorDesigner.Runtime;

public class MagicTriggerIce : MonoBehaviour
{
    public GameObject[] Prefabs;

    private GameObject[] Enemys;

    private GameObject[] Gem;
    public AudioSource Explode;
    public AudioSource HeavyAttack;

    private void Update()
    {
        Enemys = GameObject.FindGameObjectsWithTag("Enemy");
        Gem = GameObject.FindGameObjectsWithTag("Gem");
        for (int i = 0; i < Enemys.Length; i++)
        {
            if (Vector3.Distance(Enemys[i].transform.position, transform.position) < 6)
            {
                Enemys[i].GetComponent<BehaviorTree>().SetVariableValue("speed",1f);
            }
            if (Vector3.Distance(Enemys[i].transform.position, transform.position) > 6)
            {
                Enemys[i].GetComponent<BehaviorTree>().SetVariableValue("speed", 2f);
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player" && other.GetComponent<twoAnimationControllerGamepad>())
        {
            other.GetComponent<twoAnimationControllerGamepad>().AttackStatus = 0;
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if ((other.gameObject.tag == "Enemy"|| other.gameObject.tag == "EnemyHUO") && other.GetComponent<EnemyMagicControll>())
        {
            other.GetComponent<EnemyMagicControll>().enterIceTime += Time.deltaTime;
        }
        if (other.gameObject.tag == "Player" && other.GetComponent<twoAnimationControllerGamepad>())
        {
            switch (other.GetComponent<twoAnimationControllerGamepad>().AttackStatus)
            {
                case 1:
                    Instantiate(Prefabs[0], this.gameObject.transform.position, other.transform.rotation);
                    Instantiate(HeavyAttack);
                    for (int i = 0; i < Enemys.Length; i++)
                    {
                        if ((Vector3.Distance(Enemys[i].transform.position, transform.position) < 2) || ((Vector3.Distance(Enemys[i].transform.position, transform.position) < 25 && 
                            Vector3.Angle(other.transform.forward, Enemys[i].transform.position - other.transform.position) < 30)) && (Enemys[i].gameObject.layer == LayerMask.NameToLayer("EnemyHUO") || 
                            Enemys[i].gameObject.layer == LayerMask.NameToLayer("Enemy")))
                        {
                            Enemys[i].GetComponent<EnemyAniControll>().TakeDamage(120 - 10 * Vector3.Distance(Enemys[i].transform.position, transform.position));
                            Enemys[i].GetComponent<Animator>().SetTrigger("Take Damage");
                        }
                    }
                    for (int i = 0; i < Gem.Length; i++)
                    {
                        //濘親梨親鳶親濘
                        if (Vector3.Distance(Gem[i].transform.position, transform.position) < 25 && Vector3.Angle(other.transform.forward, Gem[i].transform.position - other.transform.position) < 30 && 
                            Gem[i].gameObject.layer == LayerMask.NameToLayer("EnemyHUO"))
                        {
                            Gem[i].GetComponent<GemControll>().TakeDamage(120 - 10 * Vector3.Distance(Gem[i].transform.position, transform.position));
                        }
                    }
                    Destroy(this.gameObject);
                    break;
                case 2:
                    this.gameObject.GetComponent<Rigidbody>().AddExplosionForce(20, transform.position - other.transform.forward, 10);
                    Invoke("Explosion", 1);
                    break;
                default:
                    break;
            }
        }
    }

    void Explosion()
    {
        Instantiate(Prefabs[1], this.gameObject.transform.position, Quaternion.identity);
        Instantiate(Explode);
        for (int i = 0; i < Enemys.Length; i++)
        {
            if (Vector3.Distance(Enemys[i].transform.position, transform.position) < 6 && (Enemys[i].gameObject.layer == LayerMask.NameToLayer("EnemyHUO") || Enemys[i].gameObject.layer == LayerMask.NameToLayer("Enemy")))
            {
                Enemys[i].GetComponent<EnemyAniControll>().TakeDamage(80 - 10 * Vector3.Distance(Enemys[i].transform.position, transform.position));
                Enemys[i].GetComponent<Animator>().SetTrigger("Take Damage");
            }
        }
        for (int i = 0; i < Gem.Length; i++)
        {
            //濘親梨親鳶親濘
            if (Vector3.Distance(Gem[i].transform.position, transform.position) < 6 && Gem[i].gameObject.layer == LayerMask.NameToLayer("EnemyHUO"))
            {
                Gem[i].GetComponent<GemControll>().TakeDamage(80 - 10 * Vector3.Distance(Gem[i].transform.position, transform.position));
            }
        }
        Destroy(this.gameObject);
    }
}
