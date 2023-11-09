using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SuperArrowMagic : MonoBehaviour
{
    public GameObject fire;
    public GameObject ice;
    public GameObject thunder;
    bool HUO = false;
    bool LEI = false;
    bool BING = false;
    public int dmg;

    private void OnTriggerEnter(Collider other)
    {
        switch (other.tag)
        {
            case "ThunderBall":
                LEI = true;
                thunder.SetActive(true);
                break;
            case "IceBall":
                BING = true;
                ice.SetActive(true);
                break;
            case "FireBall":
                HUO = true;
                fire.SetActive(true);
                break;
            default:
                break;
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "EnemyHUO"&&HUO)
            collision.gameObject.GetComponent<EnemyAniControll>().Hitten(dmg);
        if (collision.gameObject.tag == "EnemyLEI" && LEI)
            collision.gameObject.GetComponent<EnemyAniControll>().Hitten(dmg);
        if (collision.gameObject.tag == "EnemyBING" && BING)
            collision.gameObject.GetComponent<EnemyAniControll>().Hitten(dmg);
    }
}
