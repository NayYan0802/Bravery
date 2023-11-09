using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cometDMG : MonoBehaviour
{
    private GameObject[] Enemys;
    GameObject boss;
        
    public void Explosion()
    {
        boss = GameObject.Find("Dragon");
        Enemys = GameObject.FindGameObjectsWithTag("Enemy");
        for (int i = 0; i < Enemys.Length; i++)
        {
            if (Vector3.Distance(Enemys[i].transform.position, transform.position) < 6 && (Enemys[i].gameObject.layer == LayerMask.NameToLayer("EnemyLEI") || Enemys[i].gameObject.layer == LayerMask.NameToLayer("Enemy")))
            {
                Enemys[i].GetComponent<EnemyAniControll>().TakeDamage(50);
            }
        }
        if (Vector3.Distance(boss.transform.position, transform.position) < 6)
        {
            boss.GetComponent<EnemyAniControll>().TakeDamage(50);
        }
    }

}
