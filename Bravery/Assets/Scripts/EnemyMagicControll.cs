using BehaviorDesigner.Runtime;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMagicControll : MonoBehaviour
{
    public float enterIceTime;
    public float enterSuperIceTime;

    // Start is called before the first frame update
    void Start()
    {
        enterIceTime = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (enterIceTime > 2f)
        {
            this.GetComponent<Animator>().enabled = false;
            if(this.GetComponent<BehaviorTree>())
                this.GetComponent<BehaviorTree>().enabled = false;
            Invoke("restartFromIce", 2);
        }
        if (enterSuperIceTime > 10f)
        {
            this.GetComponent<Animator>().enabled = true;
            if (this.GetComponent<BehaviorTree>())
                this.GetComponent<BehaviorTree>().enabled = true;
        }
    }

    void restartFromIce()
    {
        enterIceTime = 0;
        this.GetComponent<Animator>().enabled = true;
        if (this.GetComponent<BehaviorTree>())
            this.GetComponent<BehaviorTree>().enabled = true;
    }
}
