using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AddRooms : MonoBehaviour
{

    RoomTemplates templates;
    public Transform RayPoint;
    bool FDeadend;
    bool RDeadend;
    bool LDeadend;
    bool BDeadend;
    public GameObject FD;
    public GameObject RD;
    public GameObject LD;
    public GameObject BD;
    public GameObject MMObject;
    public Image MMBackGround;
    public int NumInlist;
    BoxCollider BC;
    public Vector3 BCSize;


    private void Start()
    {
        templates = GameObject.FindGameObjectWithTag("Rooms").GetComponent<RoomTemplates>();
        templates.rooms.Add(this.gameObject);
        wallup();
        BC = GetComponent<BoxCollider>();
        BCSize.x = 85;
        BCSize.y = 5;
        BCSize.z = 45;
        BC.size = BCSize;
    }

    public void wallup()
    {
        WallDectection();
        if (FDeadend)
        {
            FD.SetActive(true);
        }
        if (RDeadend)
        {
            RD.SetActive(true);
        }
        if (BDeadend)
        {
            BD.SetActive(true);
        }
        if (LDeadend)
        {
            LD.SetActive(true);
        }
    }


    public void WallDectection()
    {
        RaycastHit hit;
        //Does the ray intersect a wall of the room on top of it
        if (Physics.Raycast(RayPoint.position, RayPoint.TransformDirection(Vector3.forward), out hit, Mathf.Infinity))
        {
            Debug.DrawRay(RayPoint.position, RayPoint.TransformDirection(Vector3.forward) * hit.distance, Color.yellow);
        }
        if (hit.distance > 24.5 && hit.distance < 30 && hit.transform.name == "Wall")
        {
            FDeadend = true;
        }

        RaycastHit hit2;
        //Does the ray intersect a wall of the room below it
        if (Physics.Raycast(RayPoint.position, RayPoint.TransformDirection(Vector3.back), out hit2, Mathf.Infinity))
        {
            Debug.DrawRay(RayPoint.position, RayPoint.TransformDirection(Vector3.back) * hit2.distance, Color.yellow);
        }
        if (hit2.distance > 24.5 && hit2.distance < 30 && hit2.transform.name == "Wall")
        {
            BDeadend = true;
        }

        RaycastHit hit3;
        //Does the ray intersect a wall of the room on the right of it
        if (Physics.Raycast(RayPoint.position, RayPoint.TransformDirection(Vector3.right), out hit3, Mathf.Infinity))
        {
            Debug.DrawRay(RayPoint.position, RayPoint.TransformDirection(Vector3.right) * hit3.distance, Color.yellow);
        }
        if (hit3.distance > 44.6 && hit3.distance < 50 && hit3.transform.name == "Wall")
        {
            RDeadend = true;
        }

        RaycastHit hit4;
        //Does the ray intersect a wall of the room on the left of it
        if (Physics.Raycast(RayPoint.position, RayPoint.TransformDirection(Vector3.left), out hit4, Mathf.Infinity))
        {
            Debug.DrawRay(RayPoint.position, RayPoint.TransformDirection(Vector3.left) * hit4.distance, Color.yellow);
        }
        if (hit4.distance > 44.6 && hit4.distance < 50 && hit4.transform.name == "Wall")
        {
            LDeadend = true;
        }
    }

    public void CheckFirstRoomForMM()
    {
        if(NumInlist == 0)
        {
            MMObject.SetActive(false);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            MMObject.SetActive(true);
            MMBackGround.color = Color.red;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            MMBackGround.color = Color.white;
        }
    }
}
