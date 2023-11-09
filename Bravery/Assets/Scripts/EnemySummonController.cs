using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySummonController : MonoBehaviour
{
    public int steps;

    GameObject[] enemy;

    public Transform[] BatPoint;
    public Transform[] RockPoint;
    public GameObject[] Rock;
    public GameObject Bat;
    public GameObject trigger3;
    public GameObject portal;

    private void Start()
    {
        steps = 0;
    }

    private void Update()
    {
        switch (steps)
        {
            case 0:
                break;
            case 1:
                enemy = GameObject.FindGameObjectsWithTag("Enemy");
                if (enemy.Length < 1)
                {
                    steps = 2;
                    Instantiate(Bat, BatPoint[0].position - Vector3.forward, Quaternion.identity);
                    Instantiate(Bat, BatPoint[0].position - Vector3.left, Quaternion.identity);
                    Instantiate(Bat, BatPoint[0].position + Vector3.forward, Quaternion.identity);
                    Instantiate(Bat, BatPoint[0].position + Vector3.left, Quaternion.identity);
                    Instantiate(Bat, BatPoint[1].position - Vector3.forward, Quaternion.identity);
                    Instantiate(Bat, BatPoint[1].position - Vector3.left, Quaternion.identity);
                    Instantiate(Bat, BatPoint[1].position + Vector3.forward, Quaternion.identity);
                    Instantiate(Bat, BatPoint[1].position + Vector3.left, Quaternion.identity);
                    Instantiate(Rock[Random.Range(0, 3)], RockPoint[0].position, Quaternion.identity);                    
                }
                break;
            case 2:
                enemy = GameObject.FindGameObjectsWithTag("Enemy");
                if (enemy.Length < 1)
                {
                    trigger3.SetActive(true);
                }
                break;
            case 3:
                enemy = GameObject.FindGameObjectsWithTag("Enemy");
                if (enemy.Length < 1)
                {
                    portal.SetActive(true);
                }
                break;
            default:
                break;
        }
    }
}
