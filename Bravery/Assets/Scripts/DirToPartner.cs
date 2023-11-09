using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DirToPartner : MonoBehaviour
{
    public GameObject Partner;
    Vector3 rotation;

    void Update()
    {
        this.transform.LookAt(Partner.transform,Vector3.up);
        rotation = this.transform.rotation.eulerAngles;
        rotation.x = 90;
        this.transform.rotation =Quaternion.Euler(rotation);
    }
}
