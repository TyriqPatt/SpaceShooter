using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TopDownMovement : MonoBehaviour
{

    public float moveSpeed;
    public float rotSpeed = 7f;
    public GameObject PlayerObj;
    Rigidbody Rig;
    Vector3 movement;

    // Start is called before the first frame update
    void Start()
    {
        Rig = GetComponent<Rigidbody>();   
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

        movement.z = Input.GetAxisRaw("Vertical");
        movement.x = Input.GetAxisRaw("Horizontal");
    }

    private void LateUpdate()
    {
        Move();
    }

    private void Move()
    {
        Rig.MovePosition(Rig.position + movement * moveSpeed * Time.fixedDeltaTime);
    }
}
