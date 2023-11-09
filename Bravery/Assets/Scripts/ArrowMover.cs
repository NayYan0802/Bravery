using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowMover : MonoBehaviour
{
    public float speed = 15f;
    public float hitOffset = 0f;
    public bool UseFirePointRotation;
    public Vector3 rotationOffset = new Vector3(0, 0, 0);
    //public GameObject hit;
    //public GameObject flash;
    private Rigidbody rb;
    public int dmg;
    

    void Start()
    {
        rb = GetComponent<Rigidbody>();        
        Destroy(gameObject, 5);
    }

    void FixedUpdate()
    {
        if (speed != 0)
        {
            rb.velocity = transform.forward * speed;
            //transform.position += transform.forward * (speed * Time.deltaTime);         
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Enemy"|| collision.gameObject.tag == "EnemyHUO"|| collision.gameObject.tag == "EnemyLEI"|| collision.gameObject.tag == "EnemyBING")
            collision.gameObject.GetComponent<EnemyAniControll>().Hitten(dmg);

        if (collision.gameObject.tag == "BOSS")
            collision.gameObject.GetComponent<DragonControll>().TakeDamage(dmg);
        //switch (collision.gameObject.tag)
        //{
        //    case "Enemy":
        //        collision.gameObject.GetComponent<EnemyAniControll>().Hitten(dmg);
        //        break;
        //    default:
        //        break;
        //}
        //Lock all axes movement and rotation
        rb.constraints = RigidbodyConstraints.FreezeAll;
        speed = 0;        

        ContactPoint contact = collision.contacts[0];
        Quaternion rot = Quaternion.FromToRotation(Vector3.up, contact.normal);
        Vector3 pos = contact.point + contact.normal * hitOffset;

        this.gameObject.transform.SetParent(collision.gameObject.transform);
        if (this.gameObject.layer == 8)
        {
            Invoke("SelfDestroy", 6);
        }
        else
        {
            Invoke("SelfDestroy", 1);
        }        
        //Destroy(gameObject);
    }

    void SelfDestroy()
    {
        Destroy(gameObject);
    }
}
