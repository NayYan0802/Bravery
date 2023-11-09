using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireKnife : MonoBehaviour
{
    public bool success;
    private GameObject Witch;
    public GameObject Fire;

    // Start is called before the first frame update
    void Start()
    {
        Witch = GameObject.Find("Wizard");
        success = true;
        Invoke("FireFall", 1.99f);
    }

    // Update is called once per frame
    void Update()
    {
        if (!Witch.GetComponent<Conjure>().isConjuring)
        {
            success = false;
            Destroy(this.gameObject);
        }
    }

    void FireFall()
    {
        Instantiate(Fire, this.transform.position + Vector3.up * 0.3f, Quaternion.identity);
        Destroy(this.gameObject);
    }
}
