using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroyer : MonoBehaviour
{
    RoomTemplates templates;

    private void Start()
    {
        templates = GameObject.FindGameObjectWithTag("Rooms").GetComponent<RoomTemplates>();
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("SecretRoom"))
        {
            //templates.rooms.Remove(other.transform.parent.gameObject);
            //Destroy(other.transform.parent.gameObject);
        }
        
    }
}
