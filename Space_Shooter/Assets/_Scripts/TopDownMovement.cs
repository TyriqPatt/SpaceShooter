using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TopDownMovement : MonoBehaviour
{

    public float moveSpeed;
    public float rotSpeed = 7f;
    public float dashSpeed;
    public float dashDuration = .1f;
    public GameObject PlayerObj;
    public Rigidbody Rig;
    public Vector3 movement;
    public float ForwardDis;
    bool isdashing;
    public TrailRenderer trail;
    public DashAbility Dash_Ability;
    public bool CanRotate;
    public enum State { f, b, r,l,fr,fl,br,bl }
    public enum C_State { Tank, Commander, Scout }

    public State DashState;
    public C_State ClassState;

    // Start is called before the first frame update
    void Start()
    {
        Rig = GetComponent<Rigidbody>();
        Dash_Ability = GetComponent<DashAbility>();
        trail = GetComponent<TrailRenderer>();
        trail.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (!CanRotate)
        {
            //Look At mouse
            Plane playerPlane = new Plane(Vector3.up, transform.position);
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            float hitDist = 0.0f;

            if (playerPlane.Raycast(ray, out hitDist))
            {
                Vector3 targetPoint = ray.GetPoint(hitDist);
                Quaternion targetRotation = Quaternion.LookRotation(targetPoint - transform.position);
                targetRotation.x = 0;
                targetRotation.z = 0;
                PlayerObj.transform.rotation = Quaternion.Slerp(PlayerObj.transform.rotation, targetRotation, rotSpeed * Time.deltaTime);
            }
        }

        //Movement
        movement.z = Input.GetAxisRaw("Vertical");
        movement.x = Input.GetAxisRaw("Horizontal");

        //Dash
        if (Input.GetKeyDown(KeyCode.Space))
        {
            StartCoroutine(dash());
            Dash_Ability.AbilityCall();
        }
    }

    IEnumerator dash()
    {
        //moveSpeed *= 2;
        isdashing = true;
        trail.enabled = true;
        yield return new WaitForSeconds(dashDuration);
        //moveSpeed /= 2;
        Rig.velocity = Vector3.zero;
        isdashing = false;
        trail.enabled = false;
    }

    private void LateUpdate()
    {
        WallDectection();
        Move();
        Dash();
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
                Rig.velocity = new Vector3(0, 0, dashSpeed);
            }
            if (DashState == State.b)
            {
                Rig.velocity = new Vector3(0, 0, -dashSpeed);
            }
            if (DashState == State.r)
            {
                Rig.velocity = new Vector3(dashSpeed, 0, 0);
            }
            if (DashState == State.l)
            {
                Rig.velocity = new Vector3(-dashSpeed, 0, 0);
            }
            if (DashState == State.fl)
            {
                Rig.velocity = new Vector3(-dashSpeed, 0, dashSpeed);
            }
            if (DashState == State.fr)
            {
                Rig.velocity = new Vector3(dashSpeed, 0, dashSpeed);
            }
            if (DashState == State.br)
            {
                Rig.velocity = new Vector3(dashSpeed, 0, -dashSpeed);
            }
            if (DashState == State.bl)
            {
                Rig.velocity = new Vector3(-dashSpeed, 0, -dashSpeed);
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
            if (hit.distance <= 5 && hit.transform.name == "Wall" || hit.distance <= 2.5 && hit.transform.tag == "Obstruction")
            {
                movement.z = 0;
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
            if (hit.distance <= 2.5 && hit.transform.name == "Wall" || hit.distance <= 2.5 && hit.transform.tag == "Obstruction")
            {
                movement.z = 0;
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
            if (hit.distance <= 2.5 && hit.transform.name == "Wall" || hit.distance <= 2.5 && hit.transform.tag == "Obstruction")
            {
                movement.x = 0;
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
            if (hit.distance <= 2.5 && hit.transform.name == "Wall" || hit.distance <= 2.5 && hit.transform.tag == "Obstruction")
            {
                movement.x = 0;
            }
            DashState = State.l;
        }
        //fr
        if (movement.z == 1 && movement.x == 1)
        {
            DashState = State.fr;
        }
        //fl
        if (movement.z == 1 && movement.x == -1)
        {
            DashState = State.fl;
        }
        //br
        if (movement.z == -1 && movement.x == 1)
        {
            DashState = State.br;
        }
        //bl
        if (movement.z == -1 && movement.x == -1)
        {
            DashState = State.bl;
        }
    }

    void Dash()
    {
        RaycastHit hitf;
        // Does the ray intersect any objects excluding the player layer
        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hitf, Mathf.Infinity))
        {
            if (hitf.transform.name == "Wall" || hitf.transform.tag == "Obstruction")
            {
                Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * hitf.distance, Color.yellow);
            }
        }
        if (hitf.distance <= 5 && hitf.transform.name == "Wall" || hitf.distance <= 5 && hitf.transform.tag == "Obstruction")
        {
            if (DashState == State.f)
            {
                Rig.velocity = Vector3.zero;
                isdashing = false;
            }
        }

        RaycastHit hitb;
        // Does the ray intersect any objects excluding the player layer
        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.back), out hitb, Mathf.Infinity))
        {
            if (hitb.transform.name == "Wall" || hitb.transform.tag == "Obstruction")
            {
                Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.back) * hitb.distance, Color.yellow);
            }
        }
        if (hitb.distance <= 5 && hitb.transform.name == "Wall" || hitb.distance <= 5 && hitb.transform.tag == "Obstruction")
        {

            if (DashState == State.b)
            {
                Rig.velocity = Vector3.zero;
                isdashing = false;
            }
        }

        RaycastHit hitr;
        // Does the ray intersect any objects excluding the player layer
        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.right), out hitr, Mathf.Infinity))
        {
            if (hitr.transform.name == "Wall" || hitr.transform.tag == "Obstruction")
            {
                Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.right) * hitr.distance, Color.yellow);
            }
        }
        if (hitr.distance <= 5 && hitr.transform.name == "Wall" || hitr.distance <= 5 && hitr.transform.tag == "Obstruction")
        {
            if (DashState == State.r)
            {
                Rig.velocity = Vector3.zero;
                isdashing = false;
            }
        }

        RaycastHit hitl;
        // Does the ray intersect any objects excluding the player layer
        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.left), out hitl, Mathf.Infinity))
        {
            if (hitl.transform.name == "Wall" || hitl.transform.tag == "Obstruction")
            {
                Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.left) * hitl.distance, Color.yellow);
            }
        }
        if (hitl.distance <= 5 && hitl.transform.name == "Wall" || hitl.distance <= 5 && hitl.transform.tag == "Obstruction")
        {
            if (DashState == State.l)
            {
                Rig.velocity = Vector3.zero;
                isdashing = false;
            }
        }

        //fr
        RaycastHit hitfr;
        // Does the ray intersect any objects excluding the player layer
        if (Physics.Raycast(transform.position, transform.TransformDirection(1, 0, 1), out hitfr, Mathf.Infinity))
        {
            if (hitfr.transform.name == "Wall" || hitfr.transform.tag == "Obstruction")
            {
                Debug.DrawRay(transform.position, transform.TransformDirection(1, 0, 1) * hitfr.distance, Color.yellow);
            }
        }
        if (hitfr.distance <= 5 && hitfr.transform.name == "Wall" || hitfr.distance <= 5 && hitfr.transform.tag == "Obstruction")
        {
            if (DashState == State.fr)
            {
                Rig.velocity = Vector3.zero;
                isdashing = false;
            }
        }

        //fl
        RaycastHit hitfl;
        // Does the ray intersect any objects excluding the player layer
        if (Physics.Raycast(transform.position, transform.TransformDirection(-1, 0, 1), out hitfl, Mathf.Infinity))
        {
            if (hitfl.transform.name == "Wall" || hitfl.transform.tag == "Obstruction")
            {
                Debug.DrawRay(transform.position, transform.TransformDirection(-1, 0, 1) * hitfl.distance, Color.yellow);
            }
        }
        if (hitfl.distance <= 5 && hitfl.transform.name == "Wall" || hitfl.distance <= 5 && hitfl.transform.tag == "Obstruction")
        {
            if (DashState == State.fl)
            {
                Rig.velocity = Vector3.zero;
                isdashing = false;
            }
        }
        
        //br
        RaycastHit hitbr;
        // Does the ray intersect any objects excluding the player layer
        if (Physics.Raycast(transform.position, transform.TransformDirection(1, 0, -1), out hitbr, Mathf.Infinity))
        {
            if (hitbr.transform.name == "Wall" || hitbr.transform.tag == "Obstruction")
            {
                Debug.DrawRay(transform.position, transform.TransformDirection(1, 0, -1) * hitbr.distance, Color.yellow);
            }
        }
        if (hitbr.distance <= 5 && hitbr.transform.name == "Wall" || hitbr.distance <= 5 && hitbr.transform.tag == "Obstruction")
        {
            if (DashState == State.br)
            {
                Rig.velocity = Vector3.zero;
                isdashing = false;
            }
        }

        //bl
        RaycastHit hitbl;
        // Does the ray intersect any objects excluding the player layer
        if (Physics.Raycast(transform.position, transform.TransformDirection(-1, 0, -1), out hitbl, Mathf.Infinity))
        {
            if (hitbl.transform.name == "Wall" || hitbl.transform.tag == "Obstruction")
            {
                Debug.DrawRay(transform.position, transform.TransformDirection(-1, 0, -1) * hitbl.distance, Color.yellow);
            }
        }
        if (hitbl.distance <= 5 && hitbl.transform.name == "Wall" || hitbl.distance <= 5 && hitbl.transform.tag == "Obstruction")
        {
            if (DashState == State.bl)
            {
                Rig.velocity = Vector3.zero;
                isdashing = false;
            }
        }
    }
}
