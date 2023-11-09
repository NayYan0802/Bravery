using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SuperArrowThunder : MonoBehaviour
{
    //private GameObject[] Enemys;

    //private void Update()
    //{        
    //    Enemys = GameObject.FindGameObjectsWithTag("Enemy");
    //    for (int i = 0; i < Enemys.Length; i++)
    //    {
    //        if (Vector3.Distance(Enemys[i].transform.position, transform.position) < 6)
    //        {
    //            Enemys[i].GetComponent<Rigidbody>().AddForce((this.transform.position - Enemys[i].transform.position).normalized * 5, ForceMode.Force);
    //        }
    //    }
    //}
    private void OnTriggerEnter(Collider other)
    {
        if (other.name == "Gem_Blue")
        {
            other.GetComponent<GemControll>().TakeDamage(30);
        }
    }
}
