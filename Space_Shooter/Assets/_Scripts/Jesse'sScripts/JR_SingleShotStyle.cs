﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JR_SingleShotStyle : MonoBehaviour
{
  
    public Transform barrel;

    public float Firerate = 4f;
    public float nextTimeToFire = 0f;
    //JR_EnemyObjectPooling m_objectPooling;
    public JR_EneObjectPooler objectPooler; 

    public enum State
    {
        Fire,
        Lighting,
        BlackHole,
        Double
    }
    public State _state; 
    

    //JR_EnemyObjectPooling m_enemyOjectPooling; 

    // Start is called before the first frame update
    void Start()
    {
        //barrel = gameObject.transform.GetChild(0).transform;
        // m_objectPooling = GetComponent<JR_EnemyObjectPooling>(); 
        objectPooler = JR_EneObjectPooler.Instance; 
    }

    // Update is called once per frame
    void Update()
    {
        nextTimeToFire += Time.deltaTime; 
        if (Time.timeScale != 0)
        {

            if (nextTimeToFire >= Firerate)
            {
                SingleFire();

            }
        }
    }

    void SingleFire()
    {
        switch(_state)
        {
            case State.Fire:
                {
                    objectPooler.SpawnFromPool("Fire", barrel.transform.position, barrel.transform.rotation);
                    nextTimeToFire = 0;
                    break; 
                }
            case State.Lighting:
                {
                    objectPooler.SpawnFromPool("Lighting", barrel.transform.position, barrel.transform.rotation);
                    nextTimeToFire = 0;
                    break;
                }
            case State.BlackHole:
                {
                    objectPooler.SpawnFromPool("BlackHole", barrel.transform.position, barrel.transform.rotation);
                    nextTimeToFire = 0;
                    break;
                }
            case State.Double:
                {
                    objectPooler.SpawnFromPool("Double", barrel.transform.position, barrel.transform.rotation);
                    nextTimeToFire = 0;
                    break;
                }
        }
        

      
    }
}
