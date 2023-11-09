using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class twoAnimationController : MonoBehaviour
{
    Animator animator;
    float velocityZ = 0.0f;
    float velocityX = 0.0f;
    public float acceleration=2.0f;
    Ray RayMouse;
    public Camera Cam;
    public LayerMask layer;
    private Vector3 forceDirection = Vector3.zero;
    Rigidbody rb;
    private float movementForce = 1f;
    private float maxSpeed = 4f;

    PlayerInput1 input;
    InputAction move;

    float AniAngle;
    Vector3 AniDir;

    public GameObject[] skins;
    public int skinSum;

    public GameObject bullet;
    private bool canShoot;

    public int wizardHealth;
    public GameObject[] Heart;

    public GameObject IceAttack; 
    public GameObject ThunderAttack;

    public AudioSource Sound_FireBall;

    private void Awake()
    {
        rb = this.GetComponent<Rigidbody>();
        input = new PlayerInput1();
    }

    private void OnEnable()
    {
        //input.CharacterControlsKeyboard.Jump.started += DoJump;
        move = input.CharacterControlsKeyboard.Movement;
        input.CharacterControlsKeyboard.Enable();
    }

    private void OnDisable()
    {
        //input.CharacterControlsKeyboard.Jump.started -= DoJump;
        input.CharacterControlsKeyboard.Disable();
    }

    void Start()
    {
        wizardHealth = 7;
        animator = this.GetComponent<Animator>();
        AniDir = Vector3.zero;
        skinSum = 0;
        canShoot = true;
    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit hit;
        var mousePos = Input.mousePosition;
        RayMouse = Cam.ScreenPointToRay(mousePos);
        if (Physics.Raycast(RayMouse.origin, RayMouse.direction, out hit, 100,layer))
        {
            Debug.DrawRay(hit.point,Vector3.up*10,Color.red);
            this.transform.forward = new Vector3(hit.point.x, this.transform.position.y, hit.point.z) - this.transform.position;
            //this.transform.rotation = Quaternion.LookRotation(new Vector3(hit.point.x,this.transform.position.y, hit.point.z),Vector3.up);
        }

        if (Input.GetKeyDown(KeyCode.Z))
        {
            skinSum++;
            if (skinSum > 2)
            {
                skinSum %= 3;
            }
            skins[0].SetActive(false);
            skins[1].SetActive(false);
            skins[2].SetActive(false);
            skins[skinSum].SetActive(true);
        }

        AnimatorStateInfo info = animator.GetCurrentAnimatorStateInfo(0);

        switch (skinSum)
        {
            //Fire
            case 0:
                if (animator.GetCurrentAnimatorStateInfo(0).IsName("Attack01") && info.normalizedTime>=0.6f&&canShoot)
                {
                    Instantiate(bullet,this.transform.position+transform.up+transform.forward*2+transform.right*0.6f,this.transform.rotation);
                    Sound_FireBall.Play();
                    canShoot = false;
                }
                if (animator.GetCurrentAnimatorStateInfo(0).IsName("Attack01") && info.normalizedTime <0.5f)
                {            
                    canShoot = true;
                }
                if (Input.GetMouseButtonDown(0))
                {
                    animator.SetTrigger("Attack");
                }
                break;
            //Thunder
            case 1:
                if (Input.GetMouseButtonDown(0))
                {
                    animator.SetBool("IsAttacking", true);
                    ThunderAttack.SetActive(true);
                }
                if (Input.GetMouseButtonUp(0))
                {
                    animator.SetBool("IsAttacking", false);
                    ThunderAttack.SetActive(false);
                }
                break;
            //Ice
            case 2:
                if (Input.GetMouseButtonDown(0))
                {
                    animator.SetBool("IsAttacking", true);
                    IceAttack.SetActive(true);
                }
                if (Input.GetMouseButtonUp(0))
                {
                    animator.SetBool("IsAttacking", false);
                    IceAttack.SetActive(false);
                }
                break;
            default:
                break;
        }

        SetHealth();
    }

    private void SetHealth()
    {
        if (wizardHealth < 1)
        {
            SceneManager.LoadScene("Fail");
        }
        for(int i = wizardHealth-1; i < 6; i++)
        {
            if (i < 5)
            {
                Heart[i + 1].SetActive(false);
            }
        }
    }

    void FixedUpdate()
    {
        forceDirection += move.ReadValue<Vector2>().x * GetCameraRight(Cam) * movementForce;
        forceDirection += move.ReadValue<Vector2>().y * GetCameraForward(Cam) * movementForce;
        rb.AddForce(forceDirection, ForceMode.Impulse);

        //Debug.Log("forceDirection"+forceDirection);
        

        AniAngle = Vector3.Angle(this.transform.forward.normalized, forceDirection.normalized);
        Vector3 normal = Vector3.Cross(this.transform.forward.normalized, forceDirection.normalized);//叉乘求出法线向量 
        AniAngle *= Mathf.Sign(Vector3.Dot(normal, Vector3.up));
        //Debug.Log("AniAngle" + AniAngle);
        AniDir = new Vector3(Mathf.Sin(AniAngle* Mathf.Deg2Rad),0, Mathf.Cos(AniAngle* Mathf.Deg2Rad));
        if (!Input.GetKey(KeyCode.W)&& !Input.GetKey(KeyCode.S)&& !Input.GetKey(KeyCode.A)&& !Input.GetKey(KeyCode.D))
        {
            AniDir = Vector3.zero;
        }
        //AniDir += Mathf.Cos(AniAngle) * GetCameraRight(Cam).normalized;
        //AniDir += Mathf.Sin(AniAngle) * GetCameraForward(Cam).normalized;
        //Debug.Log("AniDir" + AniDir);
        animator.SetFloat("VelocityX",AniDir.x);
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
}
