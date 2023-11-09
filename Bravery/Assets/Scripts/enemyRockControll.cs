using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyRockControll : MonoBehaviour
{
    GameObject wizard;
    GameObject bow;
    public bool isHitting;
    public bool isHittingS;
    public bool isHittingL;
    Animator animator;

    private void Start()
    {
        wizard = GameObject.Find("Wizard");
        bow = GameObject.Find("Bow");
        isHitting =isHittingS =isHittingL = false;
        animator = this.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        AnimatorStateInfo info = animator.GetCurrentAnimatorStateInfo(0);
        
        if (info.IsName("LeftPunchAttack") && info.normalizedTime <0.5f&&isHitting)
        {
            
            //isHitting = false;
        }
        if (info.IsName("Idle") && info.normalizedTime >=0.99f&&isHitting)
        {
            isHitting = false;
        }
        
        if (info.IsName("LeftPunchAttack") && info.normalizedTime >0.9f&&isHittingL)
        {
            Debug.Log("2");
            Debug.Log("S" + isHittingS);
            Debug.Log("L" + isHittingL);
            Debug.Log(isHitting);
            wizard.GetComponent<twoAnimationController>().wizardHealth -= 1;
            isHittingL = false;
        }
        
        if (info.IsName("SpinAttack") && info.normalizedTime <0.5f&&isHitting)
        {
            
            //isHitting = false;
        }
        if (info.IsName("Idle") && info.normalizedTime >=0.99f&&isHitting)
        {           
            isHitting = false;
        }
        if (info.IsName("SpinAttack") && info.normalizedTime >0.9f&&isHittingS)
        {
            Debug.Log("1");
            Debug.Log("S"+isHittingS);
            Debug.Log("L"+isHittingL);
            Debug.Log(isHitting);
            wizard.GetComponent<twoAnimationController>().wizardHealth -= 1;
            bow.GetComponent<twoAnimationControllerGamepad>().bowHealth -= 1;
            isHittingS = false;
        }


        if (Vector3.Distance(wizard.transform.position, this.transform.position) < 4f&& Vector3.Distance(bow.transform.position, this.transform.position) < 3f&&!isHitting&&!isHittingS&&!isHittingL)
        {
            animator.SetTrigger("Spin Attack Once");
            isHitting = true;
            isHittingS = true;
        }
        else if (Vector3.Distance(wizard.transform.position, this.transform.position) < 4f&&Vector3.Angle(this.transform.forward,wizard.transform.position-this.transform.position)<50 && !isHitting && !isHittingS && !isHittingL)
        {
            animator.SetTrigger("Left Punch Attack");
            isHitting = true;
            isHittingL = true;
        }
    }
}
