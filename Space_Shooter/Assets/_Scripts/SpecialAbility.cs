using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpecialAbility : MonoBehaviour
{

    public float ScoutTeleportCooldown;
    public float TankShotCooldown;
    public GameObject ScoutHolo;
    Canons canons;
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
                RaycastHit hit;
                if (Physics.SphereCast(ScoutHolo.transform.position, 5, transform.position, out hit))
                {
                    
                }

                if (Input.GetButtonUp("Fire2"))
                {
                    ScoutHolo.SetActive(true);
                    ScoutHolo.transform.parent = null;
                    Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                    RaycastHit Hit;

                    if (Physics.Raycast(ray, out Hit))
                    {
                        transform.parent.position = new Vector3(Hit.point.x, 2.5f, Hit.point.z);
                        Debug.Log("cuyhagdhga");
                    }
                    ScoutTeleportCooldown = 5;
                }
            }
        }
    }
}
