using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dragonFireDMG : MonoBehaviour
{
    GameObject wizard;
    GameObject bow;
    
    float bowTime;
    float wizardTime;

    private void Start()
    {
        wizard = GameObject.Find("Wizard");
        bow = GameObject.Find("Bow");
        bowTime = wizardTime = 0;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.name == "Wizard")
        {
            wizard.GetComponent<twoAnimationController>().wizardHealth -= 1;
        }
        if (other.name == "Bow")
        {
            bow.GetComponent<twoAnimationControllerGamepad>().bowHealth -= 1;
        }
    }

    //private void OnTriggerStay(Collider other)
    //{
    //    if (other.name == "Wizard")
    //    {
    //        wizardTime += Time.deltaTime;
    //    }
    //    if (other.name == "Bow")
    //    {
    //        bowTime += Time.deltaTime;
    //    }
    //}

    //private void Update()
    //{
    //    if (wizardTime >= 1)
    //    {
    //        wizard.GetComponent<twoAnimationController>().wizardHealth -= 1;
    //        wizardTime = 0;
    //    }
    //    if (bowTime >= 1)
    //    {
    //        bow.GetComponent<twoAnimationControllerGamepad>().bowHealth -= 1;
    //        bowTime = 0;
    //    }
    //}
}
