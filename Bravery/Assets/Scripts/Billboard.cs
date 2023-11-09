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
        //this.gameObject.SetActive(false);// ��һ�����Ե�ʱ���ã���Ѫ��ȥ��
    }

    void LateUpdate()
    {
        transform.LookAt(transform.position+cam.forward);
    }
}
