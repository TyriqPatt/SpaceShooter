using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TopDownMovement : MonoBehaviour
{

    public float moveSpeed;
    public float rotSpeed = 7f;
    public Transform MainCam;
    public GameObject PlayerObj;
    CharacterController controller;
    float curSpeed;
    float speedSmoothVel;
    float speedSmoothTime = .1f;

    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponent<CharacterController>();
        MainCam = Camera.main.transform;
    }

    // Update is called once per frame
    void Update()
    {
       
        Plane playerPlane = new Plane(Vector3.up, transform.position);
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        float hitDist = 0.0f;

        if(playerPlane.Raycast(ray, out hitDist))
        {
            Vector3 targetPoint = ray.GetPoint(hitDist);
            Quaternion targetRotation = Quaternion.LookRotation(targetPoint - transform.position);
            targetRotation.x = 0;
            targetRotation.z = 0;
            PlayerObj.transform.rotation = Quaternion.Slerp(PlayerObj.transform.rotation, targetRotation, rotSpeed * Time.deltaTime);
        }

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
        //Vector3 gravityVector = Vector3.zero;

        float targetSpeed = moveSpeed * movementInput.magnitude;
        curSpeed = Mathf.SmoothDamp(curSpeed, targetSpeed, ref speedSmoothVel, speedSmoothTime);

        controller.Move(desiredMoveDir * curSpeed * Time.deltaTime);
        //controller.Move(gravityVector * Time.deltaTime);
    }
}
