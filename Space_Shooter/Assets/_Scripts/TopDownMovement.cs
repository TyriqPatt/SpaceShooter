using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TopDownMovement : MonoBehaviour
{

    public float moveSpeed;
    public float rotSpeed = 7f;
    public float dashspeed;
    public GameObject PlayerObj;
    Rigidbody Rig;
    public Vector3 movement;
    public float ForwardDis;
    bool isdashing;
    public enum State { f, b, r,l,fr,fl,br,bl }

    public State DashState;

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
        //moveSpeed *= 2;
        isdashing = true;
        Dash();
        yield return new WaitForSeconds(.1f);
        //moveSpeed /= 2;
        Rig.velocity = Vector3.zero;
        isdashing = false;
    }

    private void LateUpdate()
    {
        WallDectection();
        Move();
        
    }

    private void Move()
    {
        if (!isdashing)
        {
            Rig.MovePosition(Rig.position + movement * moveSpeed * Time.fixedDeltaTime);
        }
        else
        {
            if (DashState == State.f)
            {
                Rig.velocity = new Vector3(0, 0, dashspeed);
            }
            if (DashState == State.b)
            {
                Rig.velocity = new Vector3(0, 0, -dashspeed);
            }
            if (DashState == State.r)
            {
                Rig.velocity = new Vector3(dashspeed, 0, 0);
            }
            if (DashState == State.l)
            {
                Rig.velocity = new Vector3(-dashspeed, 0, 0);
            }
            if (DashState == State.fl)
            {
                Rig.velocity = new Vector3(-dashspeed, 0, dashspeed);
            }
            if (DashState == State.fr)
            {
                Rig.velocity = new Vector3(dashspeed, 0, dashspeed);
            }
            if (DashState == State.br)
            {
                Rig.velocity = new Vector3(dashspeed, 0, -dashspeed);
            }
            if (DashState == State.bl)
            {
                Rig.velocity = new Vector3(-dashspeed, 0, -dashspeed);
            }
        }
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

    void Dash()
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
            if (hit.distance <= 2.5 && hit.transform.name == "Wall" || hit.distance <= 5 && hit.transform.tag == "Obstruction")
            {
                movement.z = 0;
                Rig.velocity = Vector3.zero;
                isdashing = false;
            }
            DashState = State.f;
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
            if (hit.distance <= 2.5 && hit.transform.name == "Wall" || hit.distance <= 5 && hit.transform.tag == "Obstruction")
            {
                movement.z = 0;
                Rig.velocity = Vector3.zero;
                isdashing = false;
            }
            DashState = State.b;
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
            if (hit.distance <= 2.5 && hit.transform.name == "Wall" || hit.distance <= 5 && hit.transform.tag == "Obstruction")
            {
                movement.x = 0;
                Rig.velocity = Vector3.zero;
                isdashing = false;
            }
            DashState = State.r;
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
            if (hit.distance <= 2.5 && hit.transform.name == "Wall" || hit.distance <= 5 && hit.transform.tag == "Obstruction")
            {
                movement.x = 0;
                Rig.velocity = Vector3.zero;
                isdashing = false;
            }
            DashState = State.l;
        }

        //fr
        if (movement.z == 1 && movement.x == 1)
        {
            RaycastHit hit;
            // Does the ray intersect any objects excluding the player layer
            if (Physics.Raycast(transform.position, transform.TransformDirection(1, 0, 1), out hit, Mathf.Infinity))
            {
                if (hit.transform.name == "Wall" || hit.transform.tag == "Obstruction")
                {
                    Debug.DrawRay(transform.position, transform.TransformDirection(1,0,1) * hit.distance, Color.yellow);
                }
            }
            if (hit.distance <= 2.5 && hit.transform.name == "Wall" || hit.distance <= 5 && hit.transform.tag == "Obstruction")
            {
                movement.z = 0;
                Rig.velocity = Vector3.zero;
                isdashing = false;
            }
            DashState = State.fr;
        }
        //fl
        if (movement.z == 1 && movement.x == -1)
        {
            RaycastHit hit;
            // Does the ray intersect any objects excluding the player layer
            if (Physics.Raycast(transform.position, transform.TransformDirection(-1, 0, 1), out hit, Mathf.Infinity))
            {
                if (hit.transform.name == "Wall" || hit.transform.tag == "Obstruction")
                {
                    Debug.DrawRay(transform.position, transform.TransformDirection(-1, 0, 1) * hit.distance, Color.yellow);
                }
            }
            if (hit.distance <= 2.5 && hit.transform.name == "Wall" || hit.distance <= 5 && hit.transform.tag == "Obstruction")
            {
                movement.z = 0;
                Rig.velocity = Vector3.zero;
                isdashing = false;
            }
            DashState = State.fl;
        }
        //br
        if (movement.z == -1 && movement.x == 1)
        {
            RaycastHit hit;
            // Does the ray intersect any objects excluding the player layer
            if (Physics.Raycast(transform.position, transform.TransformDirection(1, 0, -1), out hit, Mathf.Infinity))
            {
                if (hit.transform.name == "Wall" || hit.transform.tag == "Obstruction")
                {
                    Debug.DrawRay(transform.position, transform.TransformDirection(1, 0, -1) * hit.distance, Color.yellow);
                }
            }
            if (hit.distance <= 2.5 && hit.transform.name == "Wall" || hit.distance <= 5 && hit.transform.tag == "Obstruction")
            {
                movement.z = 0;
                Rig.velocity = Vector3.zero;
                isdashing = false;
            }
            DashState = State.br;
        }

        //bl
        if (movement.z == -1 && movement.x == -1)
        {
            RaycastHit hit;
            // Does the ray intersect any objects excluding the player layer
            if (Physics.Raycast(transform.position, transform.TransformDirection(-1, 0, -1), out hit, Mathf.Infinity))
            {
                if (hit.transform.name == "Wall" || hit.transform.tag == "Obstruction")
                {
                    Debug.DrawRay(transform.position, transform.TransformDirection(-1, 0, -1) * hit.distance, Color.yellow);
                }
            }
            if (hit.distance <= 2.5 && hit.transform.name == "Wall" || hit.distance <= 5 && hit.transform.tag == "Obstruction")
            {
                movement.z = 0;
                Rig.velocity = Vector3.zero;
                isdashing = false;
            }
            DashState = State.bl;
        }
    }
}
