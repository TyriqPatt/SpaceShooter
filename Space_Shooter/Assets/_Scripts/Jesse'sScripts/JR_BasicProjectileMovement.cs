using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JR_BasicProjectileMovement : MonoBehaviour
{

    public float speed;
    public float Lifetime;
    float LifeCounter;
    public GameObject W_impact;
    PlayerHealth m_playerHealth; 

    // Use this for initialization
    void Start()
    {
        m_playerHealth = GameObject.FindObjectOfType<PlayerHealth>();
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
        if (collision.gameObject.GetComponent<PlayerHealth>())
        {
            m_playerHealth.DealDamage(0.1f);  
        }

    }

    private void OnDisable()
    {
        LifeCounter = 0;
       // Instantiate(W_impact, transform.position, transform.rotation); 
    }
}
