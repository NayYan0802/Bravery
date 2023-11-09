using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class yunjin : MonoBehaviour
{
    Vector3 pos;
    //public Transform center;
    public float speed;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //this.transform.RotateAround(center.position, Vector3.up, Time.deltaTime * speed);
        pos = this.transform.position;
        pos.z += Time.deltaTime * speed;
        this.transform.position = pos;
    }
}
