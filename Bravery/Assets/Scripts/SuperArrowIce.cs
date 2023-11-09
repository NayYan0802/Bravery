using BehaviorDesigner.Runtime;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SuperArrowIce : MonoBehaviour
{
    //private GameObject[] Enemys;


    //private void Update()
    //{
    //    Enemys = GameObject.FindGameObjectsWithTag("Enemy");
    //    for (int i = 0; i < Enemys.Length; i++)
    //    {
    //        if (Vector3.Distance(Enemys[i].transform.position, transform.position) < 6)
    //        {
    //            Enemys[i].GetComponent<BehaviorTree>().SetVariableValue("speed", 1f);
    //        }
    //        if (Vector3.Distance(Enemys[i].transform.position, transform.position) > 6)
    //        {
    //            Enemys[i].GetComponent<BehaviorTree>().SetVariableValue("speed", 2f);
    //        }
    //    }
    //}
    private void OnTriggerEnter(Collider other)
    {
        if (other.name == "Gem_Red")
        {
            other.GetComponent<GemControll>().TakeDamage(30);
        }
    }
}
