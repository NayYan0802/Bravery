using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{  
    PlayerInput1 input;
    InputAction move;
    InputAction TurnToShoot;

    Rigidbody rb;
    [SerializeField]
    private float movementForce = 1f;
    [SerializeField]
    private float jumpForce = 5f;
    [SerializeField]
    private float maxSpeed = 4f;
    private Vector3 forceDirection = Vector3.zero;

    [SerializeField]
    private Camera playerCamera;

    public GameObject FirePoint;
    public GameObject[] Prefabs;

    Vector2 shootDir;
    private int Prefab = 0;
    private float fireCountdown = 0f;
    bool isShooting;
    public bool isAttacking;

    private Animator animator;

    private GameObject[] Enemys;

    //记录攻击招式，用来触发不同魔法
    //1是重劈
    //2是冲撞
    public int AttackStatus;


    private void Awake()
    {
        AttackStatus=0;
        //Enemys = GameObject.FindGameObjectsWithTag("Enemy");
        isAttacking = false;
        animator = this.GetComponent<Animator>();
        rb = this.GetComponent<Rigidbody>();
        input = new PlayerInput1();
        input.CharacterControls.ShootDirection.performed += ctx =>
        {
            shootDir = ctx.ReadValue<Vector2>();
            if (shootDir.magnitude != 0) FirePoint.transform.rotation = Quaternion.LookRotation(new Vector3(shootDir.x,0,shootDir.y),Vector3.up);
        };
        input.CharacterControls.Attack.performed += ctx =>
        {
            animator.SetTrigger("attack");
            HitOnce();
        };
        input.CharacterControls.Heavy.performed += ctx =>
          {
              animator.SetTrigger("heavy");
              AttackStatus = 1;
              HitOnce();
          };
        input.CharacterControls.Middle.performed += ctx =>
        {
            animator.SetTrigger("crouch");
            AttackStatus = 2;
            HitOnce();
            rb.AddForce(this.transform.forward*1000,ForceMode.Acceleration);            
        };
    }


    private void OnEnable()
    {        
        TurnToShoot = input.CharacterControls.ShootDirection;
        move = input.CharacterControls.Movement;
        input.CharacterControls.Enable();
    }


    private void OnDisable()
    {
        input.CharacterControls.Disable();
    }

    private void Update()
    {
        Enemys = GameObject.FindGameObjectsWithTag("Enemy");
    }

    private void FixedUpdate()
    {
        if (isShooting && fireCountdown <= 0f)
        {
            Instantiate(Prefabs[Prefab], FirePoint.transform.position, FirePoint.transform.rotation);
            fireCountdown = 0;
            fireCountdown += 0.1f;
        }
        fireCountdown -= Time.deltaTime;

        forceDirection += move.ReadValue<Vector2>().x * GetCameraRight(playerCamera) * movementForce;
        forceDirection += move.ReadValue<Vector2>().y * GetCameraForward(playerCamera) * movementForce;

        rb.AddForce(forceDirection, ForceMode.Impulse);
        forceDirection = Vector3.zero;

        if (rb.velocity.y < 0f)
            rb.velocity += Vector3.down * Physics.gravity.y * Time.fixedDeltaTime;

        Vector3 horizontalVelocity = rb.velocity;
        horizontalVelocity.y = 0;
        if (horizontalVelocity.sqrMagnitude > maxSpeed * maxSpeed)
            rb.velocity = horizontalVelocity.normalized * maxSpeed + Vector3.up * rb.velocity.y;

        LookAt();
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

    private void DoShoot(InputAction.CallbackContext obj)
    {
        Instantiate(Prefabs[Prefab], FirePoint.transform.position, FirePoint.transform.rotation);
    }

    private void DoJump(InputAction.CallbackContext obj)
    {
        if (IsGrounded())
        {
            forceDirection += Vector3.up * jumpForce;
        }
    }

    private bool IsGrounded()
    {
        Ray ray = new Ray(this.transform.position + Vector3.up * 0.25f, Vector3.down);
        if (Physics.Raycast(ray, out RaycastHit hit, 0.2f))
            return true;
        else
            return false;
    }

    void HitOnce()
    {
        isAttacking = true;
        for (int i = 0; i < Enemys.Length; i++)
        {
            if (Enemys[i] != null && Vector3.Distance(transform.position, Enemys[i].transform.position) < 3 && Vector3.Angle(transform.forward, Enemys[i].transform.position - transform.position) < 60)
            {
                Enemys[i].GetComponent<EnemyAniControll>().Hitten(10);
            }
        }
        //Invoke("ResetAttackStatus",1);
    }

    void ResetAttackStatus()
    {
        AttackStatus = 0;
    }
}
