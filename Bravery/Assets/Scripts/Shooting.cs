using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Runtime.Serialization.Formatters;
using System;

public class Shooting : MonoBehaviour
{
    public GameObject FirePoint;
    public Camera Cam;
    public float MaxLength;
    public GameObject[] Prefabs;

    private Ray RayMouse;
    private Vector3 direction;
    private Quaternion rotation;

    [Header("GUI")]
    private float windowDpi;
    private int Prefab;
    private GameObject Instance;
    private float hSliderValue = 0.2f;
    private float fireCountdown = 0f;

    //Double-click protection
    private float buttonSaver = 0f;

    //For Camera shake 
    //public Animation camAnim;

    void Start()
    {
        if (Screen.dpi < 1) windowDpi = 1;
        if (Screen.dpi < 200) windowDpi = 1;
        else windowDpi = Screen.dpi / 200f;
        Counter(0);
    }

    void Update()
    {
        //Single shoot
        if (Input.GetMouseButtonDown(1))
        {
            Instantiate(Prefabs[Prefab], FirePoint.transform.position, FirePoint.transform.rotation);
        }

        //Fast shooting
        //if (Input.GetMouseButton(1) && fireCountdown <= 0f)
        //{
        //    Instantiate(Prefabs[Prefab], FirePoint.transform.position, FirePoint.transform.rotation);
        //    fireCountdown = 0;
        //    fireCountdown += hSliderValue;
        //}
        //fireCountdown -= Time.deltaTime;

        //To change projectiles
        if ((Input.GetKey(KeyCode.Z)) && buttonSaver >= 0.4f)// left button
        {
            buttonSaver = 0f;
            Counter(-1);
        }
        if ((Input.GetKey(KeyCode.X)) && buttonSaver >= 0.4f)// right button
        {
            buttonSaver = 0f;
            Counter(+1);
        }
        buttonSaver += Time.deltaTime;

        //To rotate fire point
        if (Cam != null)
        {
            RaycastHit hit;
            var mousePos = Input.mousePosition;
            RayMouse = Cam.ScreenPointToRay(mousePos);
            if (Physics.Raycast(RayMouse.origin, RayMouse.direction, out hit, MaxLength))
            {
                RotateToMouseDirection(FirePoint, hit.point);
            }
        }
        else
        {
            Debug.Log("No camera");
        }
    }

    void Counter(int count)
    {
        Prefab += count;
        if (Prefab > Prefabs.Length - 1)
        {
            Prefab = 0;
        }
        else if (Prefab < 0)
        {
            Prefab = Prefabs.Length - 1;
        }
    }

    //To rotate fire point
    void RotateToMouseDirection(GameObject obj, Vector3 destination)
    {
        direction = destination - obj.transform.position;
        direction.y = 0;
        rotation = Quaternion.LookRotation(direction);
        obj.transform.rotation = Quaternion.Lerp(obj.transform.rotation, rotation, 1);
    }
}
