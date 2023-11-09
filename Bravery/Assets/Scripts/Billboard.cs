using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Billboard : MonoBehaviour
{

    public Transform cam;

    private void Start()
    {
        //cam = Camera.main.transform;
        if (this.name == "Canvas0")
        {
            cam = GameObject.Find("Camera0").transform;
        }
        if (this.name == "Canvas1")
        {
            cam = GameObject.Find("Camera1").transform;
        }
        //this.gameObject.SetActive(false);// 这一条测试的时候用，把血条去掉
    }

    void LateUpdate()
    {
        transform.LookAt(transform.position+cam.forward);
    }
}
