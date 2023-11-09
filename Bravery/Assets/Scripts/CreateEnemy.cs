using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateEnemy : MonoBehaviour
{
    public float IniTime;
    private float time;
    public GameObject Bat;
    public GameObject[] rock;
    private GameObject[] Enemy;
    public GameObject bow;
    public GameObject wizard;

    void Start()
    {
        //time = IniTime;
        time = 0;
    }

    // Update is called once per frame
    void Update()
    {
        //if (time < 0)
        //{
        //    time = IniTime;
        //    Instantiate(Bat, new Vector3(-9, 0, 2.5f), Quaternion.identity, null);
        //}
        //time -= Time.deltaTime;
        time += Time.deltaTime;
        Enemy = GameObject.FindGameObjectsWithTag("Enemy");
        if (Enemy.Length < 1 || time > IniTime)
        {
            Instantiate(rock[Random.Range(0,3)],this.transform.position,Quaternion.identity);
            Instantiate(Bat, bow.transform.position - Vector3.forward + Vector3.forward * 9, Quaternion.identity);
            Instantiate(Bat, bow.transform.position - Vector3.left + Vector3.forward * 9, Quaternion.identity);
            Instantiate(Bat, bow.transform.position + Vector3.forward + Vector3.forward * 9, Quaternion.identity);
            Instantiate(Bat, bow.transform.position + Vector3.left + Vector3.forward * 9, Quaternion.identity);
            Instantiate(Bat, wizard.transform.position - Vector3.forward + Vector3.forward * 9, Quaternion.identity);
            Instantiate(Bat, wizard.transform.position - Vector3.left + Vector3.forward * 9, Quaternion.identity);
            Instantiate(Bat, wizard.transform.position + Vector3.forward + Vector3.forward * 9, Quaternion.identity);
            Instantiate(Bat, wizard.transform.position + Vector3.left + Vector3.forward * 9, Quaternion.identity);
            time = 0;
        }
    }
}
