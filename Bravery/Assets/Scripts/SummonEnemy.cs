using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SummonEnemy : MonoBehaviour
{
    public Transform[] BatPoint;
    public Transform[] RockPoint;
    public GameObject Bat;
    private Vector3[] EnemyPos = new Vector3[8];
    public GameObject[] rock;
    public int step;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            if (BatPoint != null)
            {
                SummonBat();
            }
            if (RockPoint != null)
            {
                if (this.gameObject.name=="Trigger3")
                {
                    for (int i = 0; i < RockPoint.Length; i++)
                    {
                        Instantiate(rock[i], RockPoint[i].position, Quaternion.identity);
                    }
                }
                else
                {
                    for (int i = 0; i < RockPoint.Length; i++)
                    {
                        Instantiate(rock[Random.Range(0, 3)], RockPoint[i].position, Quaternion.identity);
                    }
                }
            }
        }
        GameObject.Find("GameEventController").GetComponent<EnemySummonController>().steps = step;
        this.GetComponent<BoxCollider>().enabled = false;
    }

    void SummonBat()
    {
        for (int i = 0; i < BatPoint.Length; i++)
        {
            EnemyPos[0] = BatPoint[i].position - Vector3.forward;
            EnemyPos[1] = BatPoint[i].position - Vector3.left;
            EnemyPos[2] = BatPoint[i].position + Vector3.forward;
            EnemyPos[3] = BatPoint[i].position + Vector3.left;
            Instantiate(Bat, BatPoint[i].position - Vector3.forward, Quaternion.identity);
            Instantiate(Bat, BatPoint[i].position - Vector3.left, Quaternion.identity);
            Instantiate(Bat, BatPoint[i].position + Vector3.forward, Quaternion.identity);
            Instantiate(Bat, BatPoint[i].position + Vector3.left, Quaternion.identity);
        }
    }
}
