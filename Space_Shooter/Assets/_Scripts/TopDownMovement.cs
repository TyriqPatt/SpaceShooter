using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TopDownMovement : MonoBehaviour
{

    public float moveSpeed;
    public float rotSpeed = 7f;
    public GameObject PlayerObj;
    Rigidbody Rig;
    public Vector3 movement;
    public float ForwardDis;

    // Start is called before the first frame update
    void Start()
    {
        Rig = GetComponent<Rigidbody>();   
    }

    // Update is called once per frame
    void Update()
    {
       //Look At mouse
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

        //Movement
        movement.z = Input.GetAxisRaw("Vertical");
        movement.x = Input.GetAxisRaw("Horizontal");

        //Dash
        if (Input.GetKeyDown(KeyCode.Space))
        {
            StartCoroutine(speedboost());
        }
    }

    IEnumerator speedboost()
    {
        moveSpeed *= 2;
        yield return new WaitForSeconds(1);
        moveSpeed /= 2;
    }

    private void LateUpdate()
    {
        WallDectection();
        Move();
    }

    private void Move()
    {
        Rig.MovePosition(Rig.position + movement * moveSpeed * Time.fixedDeltaTime);
    }

    void WallDectection()
    {
        if (movement.z == 1)
        {
            RaycastHit hit;
            // Does the ray intersect any objects excluding the player layer
            if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, Mathf.Infinity))
            {
                if (hit.transform.name == "Wall" || hit.transform.tag == "Obstruction")
                {
                    Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * hit.distance, Color.yellow);
                }
            }
            if (hit.distance <= 2.5 && hit.transform.name == "Wall" || hit.distance <= 2.5 && hit.transform.tag == "Obstruction")
            {
                movement.z = 0;
            }
        }

        if (movement.z == -1)
        {
            RaycastHit hit;
            // Does the ray intersect any objects excluding the player layer
            if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.back), out hit, Mathf.Infinity))
            {
                if (hit.transform.name == "Wall" || hit.transform.tag == "Obstruction")
                {
                    Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.back) * hit.distance, Color.yellow);
                }
            }
            if (hit.distance <= 2.5 && hit.transform.name == "Wall" || hit.distance <= 2.5 && hit.transform.tag == "Obstruction")
            {
                movement.z = 0;
            }
        }

        if (movement.x == 1)
        {
            RaycastHit hit;
            // Does the ray intersect any objects excluding the player layer
            if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.right), out hit, Mathf.Infinity))
            {
                if (hit.transform.name == "Wall" || hit.transform.tag == "Obstruction")
                {
                    Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.right) * hit.distance, Color.yellow);
                }
            }
            if (hit.distance <= 2.5 && hit.transform.name == "Wall" || hit.distance <= 2.5 && hit.transform.tag == "Obstruction")
            {
                movement.x = 0;
            }
        }

        if (movement.x == -1)
        {
            RaycastHit hit;
            // Does the ray intersect any objects excluding the player layer
            if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.left), out hit, Mathf.Infinity))
            {
                if (hit.transform.name == "Wall" || hit.transform.tag == "Obstruction")
                {
                    Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.left) * hit.distance, Color.yellow);
                }
            }
            if (hit.distance <= 2.5 && hit.transform.name == "Wall" || hit.distance <= 2.5 && hit.transform.tag == "Obstruction")
            {
                movement.x = 0;
            }
        }
    }
}
