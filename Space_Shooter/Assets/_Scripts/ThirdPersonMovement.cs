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
    public float rotSpeed = .1f;
    float gravity = 3;
    int comboChain;
    bool heavyAtk;

    Transform MainCam;

    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponentInParent<CharacterController>();
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

        if (comboChain >= 1 || heavyAtk)
        {
            desiredMoveDir = Vector3.zero;
        }

        if (desiredMoveDir != Vector3.zero)
        {
            transform.parent.rotation = Quaternion.Slerp(transform.parent.rotation, Quaternion.LookRotation(desiredMoveDir), rotSpeed);
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
                Anim.SetBool("IsinCombo", true);
                Anim.SetInteger("Combo", 1);

            }
            if (Anim.GetCurrentAnimatorStateInfo(0).IsName("BasicSlash"))
            {
                comboChain = 2;
                Anim.SetBool("IsinCombo", true);
                Anim.SetInteger("Combo", 2);
            }
            if (Anim.GetCurrentAnimatorStateInfo(0).IsName("BasicSlash_2"))
            {
                comboChain = 3;
                Anim.SetBool("IsinCombo", true);
                Anim.SetInteger("Combo", 3);
            }
        }

        if (Input.GetButtonDown("Fire2"))
        {
            Anim.SetTrigger("Heavy");
            heavyAtk = true;
        }
    }

    void EndCombo1()
    {
        if (comboChain == 1)
        {
            comboChain = 0;
            Anim.SetBool("IsinCombo", false);
            Anim.SetInteger("Combo", 0);
        }
    }

    void EndCombo2()
    {
        if (comboChain == 2)
        {
            comboChain = 0;
            Anim.SetBool("IsinCombo", false);
            Anim.SetInteger("Combo", 0);
        }
    }

    void EndCombo3()
    {
        if (comboChain == 3)
        {
            comboChain = 0;
            Anim.SetBool("IsinCombo", false);
            Anim.SetInteger("Combo", 0);
        }
    }

    void EndHeavy()
    {
        heavyAtk = false;
    }
}
