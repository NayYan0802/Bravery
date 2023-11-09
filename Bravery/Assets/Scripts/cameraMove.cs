using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraMove : MonoBehaviour
{

    public Transform player;
    private Vector3 pos;
   

    // Start is called before the first frame update
    void Start()
    {
        pos = this.transform.position - player.position;
    }

    // Update is called once per frame
    void Update()
    {
        this.transform.position = player.position + pos;
    }
}
