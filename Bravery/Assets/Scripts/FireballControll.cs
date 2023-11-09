using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireballControll : MonoBehaviour
{
    public float lifeTime;
    private float time;

    // Start is called before the first frame update
    void Start()
    {
        time = lifeTime;
    }

    // Update is called once per frame
    void Update()
    {
        time -= Time.deltaTime;
        if (time < 0)
        {
            Destroy(this.gameObject);
        }
    }
}
