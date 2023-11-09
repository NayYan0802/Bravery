using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SuperArrowFire : MonoBehaviour
{
    //private GameObject[] Enemys;

    //private void Update()
    //{
    //    Enemys = GameObject.FindGameObjectsWithTag("Enemy");
    //    for (int i = 0; i < Enemys.Length; i++)
    //    {
    //        if (Vector3.Distance(Enemys[i].transform.position, transform.position) < 6)
    //        {
    //            Enemys[i].GetComponent<EnemyAniControll>().TakeDamage(0.05f);
    //        }
    //    }
    //}

    private void OnTriggerEnter(Collider other)
    {
        if (other.name== "Gem_Green")
        {
            other.GetComponent<GemControll>().TakeDamage(30);
        }
    }
}
