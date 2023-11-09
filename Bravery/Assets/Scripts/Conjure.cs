using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Conjure : MonoBehaviour
{
    private Ray RayMouse;
    public Camera Cam;
    public float MaxLength;
    public GameObject[] Prefabs;
    public GameObject MagicBar;
    public LayerMask groundLayer;
    public LayerMask knifeLayer;

    //0»ð1À×2±ù
    public float[] cd;
    public float[] cdCount;
    public bool[] cdok;
    public GameObject[] cdSlider;


    public bool isConjuring;

    int skinSum;

    // Start is called before the first frame update
    void Start()
    {
        isConjuring = false;
    }

    // Update is called once per frame
    void Update()
    {
        skinSum = this.gameObject.GetComponent<twoAnimationController>().skinSum;
        RaycastHit hit;
        var mousePos = Input.mousePosition;
        RayMouse = Cam.ScreenPointToRay(mousePos);
        //´óÕÐ
        if (!isConjuring && Physics.Raycast(RayMouse.origin, RayMouse.direction, out hit, MaxLength, knifeLayer) && Input.GetMouseButtonDown(1)&&cdok[skinSum])
        {
            Transform enemy = hit.transform.parent;
            isConjuring = true;
            Instantiate(Prefabs[skinSum+3], hit.point, Quaternion.Euler(90, 0, 0),enemy);
            MagicBar.GetComponent<Slider>().value = 0;
            MagicBar.SetActive(true);
            cdok[skinSum] = false;
            cdSlider[skinSum].GetComponent<Slider>().value = cdSlider[skinSum].GetComponent<Slider>().maxValue;
        }
        if (!isConjuring && Physics.Raycast(RayMouse.origin, RayMouse.direction, out hit, MaxLength, groundLayer) && Input.GetMouseButtonDown(1) && cdok[skinSum])
        {
            Vector3 position = hit.point;
            position.y += 0.3f;
            isConjuring = true;
            Instantiate(Prefabs[skinSum], position, Quaternion.Euler(90, 0, 0));
            MagicBar.GetComponent<Slider>().value = 0;
            MagicBar.SetActive(true);
            cdok[skinSum] = false;
            cdSlider[skinSum].GetComponent<Slider>().value = cdSlider[skinSum].GetComponent<Slider>().maxValue;
        }        
        if (isConjuring)
        {
            MagicBar.GetComponent<Slider>().value+= Time.deltaTime;
            if(Input.GetKeyDown(KeyCode.W)|| Input.GetKeyDown(KeyCode.A)|| Input.GetKeyDown(KeyCode.S)|| Input.GetKeyDown(KeyCode.D))
            {
                isConjuring = false;
                MagicBar.SetActive(false);
            }
            if (MagicBar.GetComponent<Slider>().value == 2f)
            {
                isConjuring = false;
                MagicBar.SetActive(false);
            }
        }
        cdCal();
    }

    private void cdCal()
    {
        for (int i = 0; i < 3; i++)
        {
            //¼¼ÄÜÀäÈ´
            if (!cdok[i])
            {
                cdCount[i] += Time.deltaTime;
                cdSlider[i].GetComponent<Slider>().value -= Time.deltaTime;
                //cd¶ÁÍê
                if (cdCount[i] > cd[i])
                {
                    cdCount[i] = 0;
                    cdok[i] = true;
                }
            }
        }
    }
}
