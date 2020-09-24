 using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThirdPersonMovement : MonoBehaviour
{

    CharacterController controller;
    public Animator Anim;
    public float moveSpeed = 2;
    float curSpeed;
    float speedSmoothVel;
    float speedSmoothTime = .1f;
    float rotSpeed = .1f;
    float gravity = 3;
    int comboChain;
    float ComboReset;


    Transform MainCam;

    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponent<CharacterController>();
        MainCam = Camera.main.transform;
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        attack();
    }

    private void Move()
    {
        Vector2 movementInput = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        Vector3 forward = MainCam.up;
        Vector3 right = MainCam.right;

        forward.y = 0;
        right.y = 0;

        forward.Normalize();
        right.Normalize();

        Vector3 desiredMoveDir = (forward * movementInput.y + right * movementInput.x).normalized;
        Vector3 gravityVector = Vector3.zero;

        if (!controller.isGrounded)
        {
            gravityVector.y -= gravity;
        }

        if (Anim.GetCurrentAnimatorStateInfo(0).IsName("BasicSlash") || Anim.GetCurrentAnimatorStateInfo(0).IsName("BasicSlash2") || Anim.GetCurrentAnimatorStateInfo(0).IsName("BasicSlash3"))
        {
            desiredMoveDir = Vector3.zero;
        }

        if (desiredMoveDir != Vector3.zero)
        {
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(desiredMoveDir), rotSpeed);
            Anim.SetBool("isWalking", true);
        }
        else
        {
            Anim.SetBool("isWalking", false);
        }

        float targetSpeed = moveSpeed * movementInput.magnitude;
        curSpeed = Mathf.SmoothDamp(curSpeed, targetSpeed, ref speedSmoothVel, speedSmoothTime);

        controller.Move(desiredMoveDir * curSpeed * Time.deltaTime);
        controller.Move(gravityVector * Time.deltaTime);
    }

    void attack()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            if(comboChain == 0)
            {
                comboChain += 1;
                ComboReset = 0;
                Anim.SetBool("IsinCombo", true);
                Anim.SetTrigger("Attack");
               
            }
            if (Anim.GetCurrentAnimatorStateInfo(0).IsName("BasicSlash"))
            {
                comboChain += 1;
                ComboReset = 0;
                Anim.SetBool("IsinCombo", true);
                Anim.SetTrigger("Attack2");
            }
            if (Anim.GetCurrentAnimatorStateInfo(0).IsName("BasicSlash2"))
            {
                comboChain += 1;
                ComboReset = 0;
                Anim.SetBool("IsinCombo", true);
                Anim.SetTrigger("Attack3");
            }

        }
        if(comboChain > 0)
        {
            ComboReset += Time.deltaTime;
            if(ComboReset >= 1f)
            {
                comboChain = 0;
                Anim.SetBool("IsinCombo", false);
            }
        }
    }
}
