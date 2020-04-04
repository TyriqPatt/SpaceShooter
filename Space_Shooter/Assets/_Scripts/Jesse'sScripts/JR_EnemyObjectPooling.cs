﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JR_EnemyObjectPooling : MonoBehaviour
{


    //Singleton
    private static JR_EnemyObjectPooling _instance;
    public static JR_EnemyObjectPooling Instance
    {
        get
        {
            if (_instance == null)
            {
                GameObject go = new GameObject("PoolManager");
                go.AddComponent<ObjectPooling>();
            }
            return _instance;
        }
    }

    //BulletTypeOfEnemy
    public GameObject currentBullet;
    //Hold player bullets
    public GameObject BulletContainer;
    //initial amount of objects spawned 
    public int ObjectsSpawned = 10;
    //List to hold pooled objects
    public List<GameObject> ObjectList = new List<GameObject>();

    public int BulletType = 1;

    public GameObject BasicProjectile;
    public GameObject TrackingProjectile;
    public GameObject SwirlProjectile;

    private void Awake()
    {
        _instance = this;


        switch (BulletType)
        {
            case 3:
                currentBullet = SwirlProjectile;
                print("Swirl");
                break;
            case 2:
                currentBullet = TrackingProjectile;
                print("Tracking");
                break;
            case 1:
                currentBullet = BasicProjectile;

                print("Basic");
                break;
            default:
                print("No Bullet");
                break;
        }
    }

    //Spawns the objects
    public void Start()
    {
        for (int i = 0; i < ObjectsSpawned; i++)
        {
            GameObject objects = Instantiate(currentBullet, Vector3.zero, Quaternion.identity) as GameObject;
            objects.transform.parent = BulletContainer.transform;
            objects.SetActive(false);
            ObjectList.Add(objects);
        }
    }
}
