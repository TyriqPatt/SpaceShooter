using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JR_Points : MonoBehaviour
{
    public bool isTaken = false;  

    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Enemy" )
        {
            isTaken = true; 
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            isTaken = false; 
        }
    }


}
