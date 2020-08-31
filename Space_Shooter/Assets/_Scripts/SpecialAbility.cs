using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpecialAbility : MonoBehaviour
{

    public float ScoutTeleportCooldown;
    float ScoutTeleportTimer;
    public float TankShotCooldown;
    public GameObject ScoutHolo;
    Canons canons;
    public GameObject ScoutCritDashInd;
    bool ability;
    public TopDownMovement Movement;
    public enum State { Tank, Commander, Scout }

    public State ClassState;

    // Start is called before the first frame update
    void Start()
    {
        canons = GetComponent<Canons>();
        Movement = transform.parent.GetComponent<TopDownMovement>();
    }

    // Update is called once per frame
    void Update()
    {
        if (ClassState == State.Tank)
        {
            if (TankShotCooldown > 0)
            {
                TankShotCooldown -= Time.deltaTime;
            }
            else
            {
                if (Input.GetButtonDown("Fire2"))
                {
                    canons.TankSpecialShoot();
                    TankShotCooldown = 3;
                }
            }
        }
        
        if (ClassState == State.Scout)
        {
            if (ScoutTeleportTimer > 0)
            {
                ScoutTeleportTimer -= Time.deltaTime;
            }
            else
            {
                if (Input.GetButton("Fire2"))
                {
                    ScoutCritDashInd.SetActive(true);
                }
                if (Input.GetButtonUp("Fire2"))
                {
                    Movement.CanRotate = true;
                    ScoutHolo.SetActive(true);
                    ScoutHolo.transform.parent = null;
                    //Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                    //RaycastHit Hit;
                    //ScoutCritDashInd.SetActive(false);
                    ability = true;
                    //if (Physics.Raycast(ray, out Hit))
                    //{
                    //    if(Hit.transform.tag != "Obstruction" && Hit.transform.name != "Wall")
                    //    {
                    //        //transform.parent.position = new Vector3(Hit.point.x, 2.5f, Hit.point.z);
                    //        Debug.Log("cuyhagdhga");
                    //    }
                    //}
                    ScoutTeleportTimer = ScoutTeleportCooldown;
                }
            }
            if (ability)
            {
                transform.parent.position += transform.forward * 7;
                RaycastHit hit;
                // Does the ray intersect any objects excluding the player layer
                if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, Mathf.Infinity))
                {
                    if (hit.transform.name == "Wall" || hit.transform.tag == "Obstruction")
                    {
                        Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * hit.distance, Color.yellow);
                    }
                }
                if (hit.distance <= 6 && hit.transform.name == "Wall")
                {
                    ability = false;
                    Movement.CanRotate = false;
                }
                if (ScoutTeleportTimer < ScoutTeleportCooldown - .05f)
                {
                    ScoutCritDashInd.SetActive(false);
                    //transform.parent.GetComponent<Rigidbody>().velocity = Vector3.zero;
                    ability = false;
                    Movement.CanRotate = false;
                }
                //transform.parent.position = Vector3.MoveTowards(transform.parent.position, Hit.transform.position, 5 * Time.deltaTime);     
            }
        }
    }
}
