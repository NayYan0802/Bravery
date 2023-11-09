using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagicDelay : MonoBehaviour
{
    public GameObject fireball;
    public GameObject iceball;
    public GameObject thunderball;
    public bool success;
    private GameObject Witch;

    // Start is called before the first frame update
    void Start()
    {
        Witch = GameObject.Find("Wizard");
        success = true;
        switch (Witch.GetComponent<twoAnimationController>().skinSum) {
            case 0:
                Invoke("Fireball", 1.8f);
                break;
            case 1:
                Invoke("Thunderball", 1.8f);
                break;
            case 2:
                Invoke("Iceball", 1.8f);
                break;
            default:
                break;
        }
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

    void Fireball()
    {
        if (success)
        {
            Instantiate(fireball, this.transform.position+Vector3.up*0.3f, Quaternion.identity);
            Destroy(this.gameObject);
        }
    }
    void Iceball()
    {
        if (success)
        {
            Instantiate(iceball, this.transform.position + Vector3.up * 0.3f, Quaternion.identity);
            Destroy(this.gameObject);
        }
    }
    void Thunderball()
    {
        if (success)
        {
            Instantiate(thunderball, this.transform.position + Vector3.up * 0.3f, Quaternion.identity);
            Destroy(this.gameObject);
        }
    }
}
