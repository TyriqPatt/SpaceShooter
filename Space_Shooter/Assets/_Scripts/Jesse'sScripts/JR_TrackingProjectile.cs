using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JR_TrackingProjectile : MonoBehaviour
{
    public float speed;
    public float Lifetime;
    float LifeCounter;
    public GameObject W_impact;

    private Vector3 target; 

    // Use this for initialization
    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").transform.position; 
    }

    // Update is called once per frame
    void Update()
    {
        transform.LookAt(target); 
        transform.position += transform.forward * Time.deltaTime * speed;
        LifeCounter += Time.deltaTime;
        if (LifeCounter >= Lifetime)
        {
            gameObject.SetActive(false);
        }

    }

    private void OnDisable()
    {
        LifeCounter = 0;
    }
}
