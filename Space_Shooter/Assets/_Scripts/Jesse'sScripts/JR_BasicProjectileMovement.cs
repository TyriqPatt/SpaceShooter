﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JR_BasicProjectileMovement : MonoBehaviour
{

    public float projectileSpeed; 

    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, 8);
    }

    // Update is called once per frame
    void Update()
    {

        transform.Translate(Vector3.forward * projectileSpeed);  
        
    }


    private void OnTriggerEnter(Collider other)
    {
        Destroy(gameObject); 
    }
}
