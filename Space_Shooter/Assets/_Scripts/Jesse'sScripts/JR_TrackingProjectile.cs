using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JR_TrackingProjectile : MonoBehaviour
{
    public float projectileSpeed;
    private float distance;

    private bool stopTracking;
    private GameObject target;  

    // Start is called before the first frame update
    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player");
        Destroy(gameObject, 8);
    }

    // Update is called once per frame
    void Update()
    {
        if(!stopTracking)
        {
            transform.LookAt(target.transform);
        }

        transform.Translate(Vector3.forward * projectileSpeed);
        distance = Vector3.Distance(transform.position, target.transform.position);
        
        if(distance < 10) 
        {
            stopTracking = true; 
        }
    }


    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Hit");

        Destroy(gameObject);
    }
}
