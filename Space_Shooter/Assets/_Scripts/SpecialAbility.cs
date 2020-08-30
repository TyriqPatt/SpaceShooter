using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpecialAbility : MonoBehaviour
{

    public float ScoutTeleportCooldown;
    public float TankShotCooldown;
    public GameObject ScoutHolo;
    Canons canons;
    public GameObject Length;
    bool ability;
    public enum State { Tank, Commander, Scout }

    public State ClassState;

    // Start is called before the first frame update
    void Start()
    {
        canons = GetComponent<Canons>();
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
           

            if (ScoutTeleportCooldown > 0)
            {
                ScoutTeleportCooldown -= Time.deltaTime;
            }
            else
            {
                if (Input.GetButton("Fire2"))
                {
                    Length.SetActive(true);
                }
                if (Input.GetButtonUp("Fire2"))
                {
                    ScoutHolo.SetActive(true);
                    ScoutHolo.transform.parent = null;
                    Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                    RaycastHit Hit;
                    Length.SetActive(false);
                    ability = true;
                    if (Physics.Raycast(ray, out Hit))
                    {
                        if(Hit.transform.tag != "Obstruction" && Hit.transform.name != "Wall")
                        {
                            //transform.parent.position = new Vector3(Hit.point.x, 2.5f, Hit.point.z);
                            Debug.Log("cuyhagdhga");
                        }
                    }
                    ScoutTeleportCooldown = 5;
                }
            }
            if (ability)
            {
                transform.parent.position += transform.forward * 5;
                RaycastHit hit;
                // Does the ray intersect any objects excluding the player layer
                if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, Mathf.Infinity))
                {
                    if (hit.transform.name == "Wall" || hit.transform.tag == "Obstruction")
                    {
                        Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * hit.distance, Color.yellow);
                    }
                }
                if (hit.distance <= 4 && hit.transform.name == "Wall" || hit.distance <= 4 && hit.transform.tag == "Obstruction")
                {
                    ability = false;
                }
                if (ScoutTeleportCooldown < 4.9f)
                {
                    //transform.parent.GetComponent<Rigidbody>().velocity = Vector3.zero;
                    ability = false;
                    
                }
                //transform.parent.position = Vector3.MoveTowards(transform.parent.position, Hit.transform.position, 5 * Time.deltaTime);

            }
        }
    }
}
