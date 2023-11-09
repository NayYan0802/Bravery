using System;
using System.Collections;
using System.Collections.Generic;
//using UnityEditor.Animations;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class twoAnimationControllerGamepad : MonoBehaviour
{
    Animator animator;
    float velocityZ = 0.0f;
    float velocityX = 0.0f;
    public float acceleration = 2.0f;
    Ray RayMouse;
    public Camera Cam;
    public LayerMask layer;
    private Vector3 forceDirection = Vector3.zero;
    Rigidbody rb;
    private float movementForce = 1f;
    private float maxSpeed = 4f;

    PlayerInput1 input;
    InputAction move;
    InputAction FaceDir;

    float AniAngle;
    Vector3 AniDir;

    private GameObject[] Enemys;

    public GameObject[] bowSkins;
    public GameObject[] swordSkins;
    //public AnimatorController[] animatorControllers;
    public GameObject arrow;
    public GameObject superArrow;
    public GameObject knife;

    //0»¬²ù 1ÖØÅü 2·Éµ¶
    public float[] cd;
    public float[] cdCount;
    public bool[] cdok;
    public GameObject[] cdSlider;

    //0ÊÇ¹­¼ý£¬1ÊÇ½£¶Ü
    private int skinSum;
    private bool canShoot;

    public int AttackStatus;
    private bool startShoot=false;

    public int bowHealth;
    public GameObject[] Heart;

    private void Awake()
    {
        AttackStatus = 0;
        canShoot = true;
        rb = this.GetComponent<Rigidbody>();
        input = new PlayerInput1();
        input.CharacterControls.Attack.performed += ctx =>
        {
            if (skinSum == 1)
            {
                HitOnce(5);
                GameObject.Find("FighterAttack").GetComponent<AudioSource>().Play();
                animator.SetTrigger("Attack");
            }else if (skinSum == 0)
            {
                animator.SetTrigger("BowAttack");
            }
            
        };
        input.CharacterControls.Knife.performed += ctx =>
        {
            if (cdok[2])
            {
                if (skinSum == 1)
                {
                    HitOnce(10);
                    animator.SetTrigger("Knife");                
                    cdok[2] = false;
                    cdSlider[2].GetComponent<Slider>().value = cdSlider[2].GetComponent<Slider>().maxValue;
                }
            }
        };
        input.CharacterControls.Attack1.performed += ctx =>
        {
            if (skinSum == 0)
            {
                Debug.Log("start");
                GameObject.Find("PullBow").GetComponent<AudioSource>().Play();
                animator.SetTrigger("StartShooting");
                startShoot = true;
            }
        };
        input.CharacterControls.Attack1.canceled += ctx =>
        {
            Debug.Log("stop");
            if (startShoot)
            {
                animator.SetTrigger("StopShooting");
                startShoot = false;
                Instantiate(superArrow, this.transform.position + transform.up + transform.forward, this.transform.rotation);
                GameObject.Find("ReleaseBow").GetComponent<AudioSource>().Play();
            }
        };
        input.CharacterControls.Heavy.performed += ctx =>
        {
            if (cdok[1])
            {
                //Debug.Log("1");
                if (skinSum == 1)
                {
                    HitOnce(15);
                    animator.SetTrigger("Heavy");
                    AttackStatus = 1;
                    cdok[1] = false;
                    cdSlider[1].GetComponent<Slider>().value = cdSlider[1].GetComponent<Slider>().maxValue;
                }
            }
        };
        input.CharacterControls.Middle.performed += ctx =>
        {
            if (cdok[0])
            {
                //Debug.Log("2");
                if (skinSum == 1)
                {
                    HitOnce(10);
                    animator.SetTrigger("Middle");
                    AttackStatus = 2;
                    rb.AddForce(this.transform.forward * 1000, ForceMode.Acceleration);
                    cdok[0] = false;
                    cdSlider[0].GetComponent<Slider>().value = cdSlider[0].GetComponent<Slider>().maxValue;
                }
            }
        };
    }

    private void OnEnable()
    {
        input.CharacterControls.ChangeSkin.performed += ctx =>
        {
            skinSum++;
            if (skinSum > 1)
            {
                skinSum %= 2;
            }
            //animator.runtimeAnimatorController = animatorControllers[skinSum];
            animator.SetTrigger("Switch");
            for (int i = 0; i < bowSkins.Length; i++)
            {
                bowSkins[i].SetActive(false);
            }
            for (int i = 0; i < swordSkins.Length; i++)
            {
                swordSkins[i].SetActive(false);
            }
            switch (skinSum)
            {
                case 0:
                    for (int i = 0; i < bowSkins.Length; i++)
                    {
                        bowSkins[i].SetActive(true);
                    }
                    break;
                case 1:
                    for (int i = 0; i < swordSkins.Length; i++)
                    {
                        swordSkins[i].SetActive(true);
                    }
                    break;
                default:
                    break;
            }
        };
        FaceDir= input.CharacterControls.ShootDirection;
        move = input.CharacterControls.Movement;
        input.CharacterControls.Enable();
    }


    private void OnDisable()
    {
        //input.CharacterControlsKeyboard.Jump.started -= DoJump;
        input.CharacterControls.Disable();
    }

    void Start()
    {
        bowHealth=7;
        animator = this.GetComponent<Animator>();
        AniDir = Vector3.zero;
        skinSum = 0;
        ChangeSkin();
    }

    // Update is called once per frame
    void Update()
    {
        Enemys = GameObject.FindGameObjectsWithTag("Enemy");

        AnimatorStateInfo info = animator.GetCurrentAnimatorStateInfo(1);
        if (info.IsName("Attack01ForRunWalkBow") && info.normalizedTime >= 0.6f && canShoot)
        {
            Debug.Log("111");
            Instantiate(arrow, this.transform.position + transform.up + transform.forward, this.transform.rotation);
            GameObject.Find("ReleaseBow").GetComponent<AudioSource>().Play();
            canShoot = false;
        }
        if (info.IsName("Attack01ForRunWalkBow") && info.normalizedTime < 0.5f)
        {
            canShoot = true;
        }
        info = animator.GetCurrentAnimatorStateInfo(0);
        if (info.IsName("Combo01_SwordShield") && info.normalizedTime <1 && canShoot)
        {
            Instantiate(knife, this.transform.position + transform.up + transform.forward*3, this.transform.rotation);
            canShoot = false;
        }       
        if (info.IsName("Combo01_SwordShield") && info.normalizedTime>1)
        {           
            canShoot = true;
        }

        cdCal();
        SetHealth();
    }

    private void SetHealth()
    {
        if (bowHealth < 1)
        {
            SceneManager.LoadScene("Fail");
        }
        for (int i = bowHealth-1; i < 6; i++)
        {
            if (i < 5)
            {
                Heart[i+1].SetActive(false);
            }
        }
    }


    private void cdCal()
    {
        for(int i = 0; i < 3; i++)
        {
            //¼¼ÄÜÀäÈ´
            if (!cdok[i])
            {
                cdCount[i] += Time.deltaTime;
                cdSlider[i].GetComponent<Slider>().value-= Time.deltaTime;
                //cd¶ÁÍê
                if (cdCount[i] > cd[i])
                {
                    cdCount[i] = 0;
                    cdok[i] = true;
                }
            }
        }
    }

    void FixedUpdate()
    {
        forceDirection += move.ReadValue<Vector2>().x * GetCameraRight(Cam) * movementForce;
        forceDirection += move.ReadValue<Vector2>().y * GetCameraForward(Cam) * movementForce;
        rb.AddForce(forceDirection, ForceMode.Impulse);

        //Debug.Log("forceDirection" + forceDirection);


        AniAngle = Vector3.Angle(this.transform.forward.normalized, forceDirection.normalized);
        Vector3 normal = Vector3.Cross(this.transform.forward.normalized, forceDirection.normalized);//The cross product is the normal vector
        AniAngle *= Mathf.Sign(Vector3.Dot(normal, Vector3.up));
        AniDir = new Vector3(Mathf.Sin(AniAngle * Mathf.Deg2Rad), 0, Mathf.Cos(AniAngle * Mathf.Deg2Rad));
        if (move.ReadValue<Vector2>().magnitude<0.1f)
        {
            AniDir = Vector3.zero;
        }
        if (FaceDir.ReadValue<Vector2>().magnitude >= 0.1f)
        {
            this.transform.forward = new Vector3(FaceDir.ReadValue<Vector2>().x, 0, FaceDir.ReadValue<Vector2>().y);
        }
        if (FaceDir.ReadValue<Vector2>().magnitude < 0.1f)
        {
            LookAt();
        }
        animator.SetFloat("VelocityX", AniDir.x);
        animator.SetFloat("VelocityZ", AniDir.z);

        AniDir = Vector3.zero;
        forceDirection = Vector3.zero;
        if (rb.velocity.y < 0f)
            rb.velocity += Vector3.down * Physics.gravity.y * Time.fixedDeltaTime;

        Vector3 horizontalVelocity = rb.velocity;
        horizontalVelocity.y = 0;
        if (horizontalVelocity.sqrMagnitude > maxSpeed * maxSpeed)
            rb.velocity = horizontalVelocity.normalized * maxSpeed + Vector3.up * rb.velocity.y;

        
    }

    private void LookAt()
    {
        Vector3 direction = rb.velocity;
        direction.y = 0;

        if (move.ReadValue<Vector2>().sqrMagnitude > 0.1f && direction.sqrMagnitude > 0.1f)
            this.rb.rotation = Quaternion.LookRotation(direction, Vector3.up);
        else
            rb.angularVelocity = Vector3.zero;
    }

    void HitOnce(int damage)
    {
        for (int i = 0; i < Enemys.Length; i++)
        {
            if (Enemys[i] != null && Vector3.Distance(transform.position, Enemys[i].transform.position) < 1.5f && Vector3.Angle(transform.forward, Enemys[i].transform.position - transform.position) < 60)
            {
                Enemys[i].GetComponent<EnemyAniControll>().Hitten(damage);
            }
        }
    }

    private Vector3 GetCameraForward(Camera playerCamera)
    {
        Vector3 forward = playerCamera.transform.forward;
        forward.y = 0;
        return forward.normalized;
    }

    private Vector3 GetCameraRight(Camera playerCamera)
    {
        Vector3 right = playerCamera.transform.right;
        right.y = 0;
        return right.normalized;
    }

    void ChangeSkin()
    {
        skinSum++;
        if (skinSum > 1)
        {
            skinSum %= 2;
        }
        //animator.runtimeAnimatorController = animatorControllers[skinSum];
        animator.SetTrigger("Switch");
        for (int i = 0; i < bowSkins.Length; i++)
        {
            bowSkins[i].SetActive(false);
        }
        for (int i = 0; i < swordSkins.Length; i++)
        {
            swordSkins[i].SetActive(false);
        }
        switch (skinSum)
        {
            case 0:
                for (int i = 0; i < bowSkins.Length; i++)
                {
                    bowSkins[i].SetActive(true);
                }
                break;
            case 1:
                for (int i = 0; i < swordSkins.Length; i++)
                {
                    swordSkins[i].SetActive(true);
                }
                break;
            default:
                break;
        }
    }
}
