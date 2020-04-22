using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JR_EnemyHealth : MonoBehaviour
{

    public bool isCaptin = false;  
    private float currentHealth;
    public float maxHealth;

    private float currentShield;
    public float maxShield;

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth; 
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void TakeDamage(int amount)
    {
        if (isCaptin)
        {
            currentShield -= amount;
            CheckShield(); 
        }
        else
        {
            currentHealth -= amount;
            CheckifDead();
        }
    }

    private void CheckifDead()
    {
        if(currentHealth <= 0)
        {
            gameObject.SetActive(false); 
        }
    }

    private void CheckShield()
    {
        if (currentShield <= 0)
        {
            isCaptin = false; 
        }
    }
}
