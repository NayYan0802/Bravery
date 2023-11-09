using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyBatControll : MonoBehaviour
{
    GameObject wizard;
    GameObject bow;
    bool isHitting;
    Animator animator;

    private void Start()
    {
        wizard = GameObject.Find("Wizard");
        bow = GameObject.Find("Bow");
        isHitting = false;
        animator = this.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        AnimatorStateInfo info = animator.GetCurrentAnimatorStateInfo(0);

        if (info.IsName("BiteAttack") && info.normalizedTime < 0.5f && isHitting)
        {

            isHitting = false;
        }
        if (info.IsName("BiteAttack") && info.normalizedTime > 0.5f && !isHitting)
        {
            if (Vector3.Distance(wizard.transform.position, this.transform.position) < 2.5f && Vector3.Angle(this.transform.forward, wizard.transform.position - this.transform.position) < 50)
            {
                wizard.GetComponent<twoAnimationController>().wizardHealth -= 1;
            }
            if (Vector3.Distance(bow.transform.position, this.transform.position) < 2.5f && Vector3.Angle(this.transform.forward, bow.transform.position - this.transform.position) < 50)
            {
                bow.GetComponent<twoAnimationControllerGamepad>().bowHealth -= 1;
            }
            isHitting = true;
        }    


        if (Vector3.Distance(wizard.transform.position, this.transform.position) < 2.5f && Vector3.Angle(this.transform.forward, wizard.transform.position - this.transform.position) < 50)
        {
            animator.SetTrigger("Bite Attack");
        }
        if (Vector3.Distance(bow.transform.position, this.transform.position) < 2.5f && Vector3.Angle(this.transform.forward, bow.transform.position - this.transform.position) < 50)
        {
            animator.SetTrigger("Bite Attack");
        }
    }
}
