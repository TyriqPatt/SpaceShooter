using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    CharacterController controller;
    public float moveSpeed = 2;
    float curSpeed;
    float speedSmoothVel;
    float speedSmoothTime = .1f;
    float rotSpeed = .1f;
    float gravity = 3;

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
    }

    private void Move()
    {
        Vector2 movementInput = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        Vector3 forward = MainCam.forward;
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

        if(desiredMoveDir != Vector3.zero)
        {
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(desiredMoveDir), rotSpeed);
        }

        float targetSpeed = moveSpeed * movementInput.magnitude;
        curSpeed = Mathf.SmoothDamp(curSpeed, targetSpeed, ref speedSmoothVel, speedSmoothTime);

        controller.Move(desiredMoveDir * curSpeed * Time.deltaTime);
        controller.Move(gravityVector * Time.deltaTime);
    }
}
