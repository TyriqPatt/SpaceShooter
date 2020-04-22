using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JR_BasicProjectileMovement : MonoBehaviour
{

    public float speed;
    public float Lifetime;
    float LifeCounter;
    public GameObject W_impact;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        transform.position += transform.forward * Time.deltaTime * speed;
        LifeCounter += Time.deltaTime;
        if (LifeCounter >= Lifetime)
        {
            gameObject.SetActive(false);
        }

    }

    private void OnCollisionEnter(Collision collision)
    {
        gameObject.SetActive(false);

    }

    private void OnDisable()
    {
        LifeCounter = 0;
        Instantiate(W_impact, transform.position, transform.rotation); 
    }
}
