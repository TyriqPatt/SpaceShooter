using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPooling : MonoBehaviour
{
    //Singleton
    private static ObjectPooling _instance;
    public static ObjectPooling Instance
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

    //prefab that will be pooled
    public GameObject PooledObject;
    public GameObject Impact;
    public GameObject TankShot;
    public GameObject TSImpact;
    public GameObject CImpact;
    public GameObject CHolo;
    //Hold player bullets
    public GameObject BulletContainer;
    public GameObject ImpactContainer;
    public GameObject TankShotContainer;
    public GameObject TSImpactContainer;
    public GameObject CImpactContainer;
    public GameObject CHoloContainer;
    //initial amount of objects spawned 
    public int ObjectsSpawned = 10;
    //List to hold pooled objects
    public List<GameObject> ObjectList = new List<GameObject>();
    public List<GameObject> ImpactList = new List<GameObject>();
    public List<GameObject> TankShotList = new List<GameObject>();
    public List<GameObject> TSImpactList = new List<GameObject>();
    public List<GameObject> CImpactList = new List<GameObject>();
    public List<GameObject> CHoloList = new List<GameObject>();

    private void Awake()
    {
        _instance = this;
    }

    //Spawns the objects
    public void Start()
    {
        for (int i = 0; i < ObjectsSpawned; i++)
        {
            GameObject objects = Instantiate(PooledObject, Vector3.zero, Quaternion.identity) as GameObject;
            objects.transform.parent = BulletContainer.transform;
            objects.SetActive(false);
            ObjectList.Add(objects);
        }

        for (int i = 0; i < ObjectsSpawned; i++)
        {
            GameObject objects = Instantiate(Impact, Vector3.zero, Quaternion.identity) as GameObject;
            objects.transform.parent = ImpactContainer.transform;
            objects.SetActive(false);
            ImpactList.Add(objects);
        }

        for (int i = 0; i < ObjectsSpawned - 7; i++)
        {
            GameObject objects = Instantiate(TankShot, Vector3.zero, Quaternion.identity) as GameObject;
            objects.transform.parent = TankShotContainer.transform;
            objects.SetActive(false);
            TankShotList.Add(objects);
        }

        for (int i = 0; i < ObjectsSpawned - 7; i++)
        {
            GameObject objects = Instantiate(TSImpact, Vector3.zero, Quaternion.identity) as GameObject;
            objects.transform.parent = TSImpactContainer.transform;
            objects.SetActive(false);
            TSImpactList.Add(objects);
        }

        for (int i = 0; i < ObjectsSpawned; i++)
        {
            GameObject objects = Instantiate(CImpact, Vector3.zero, Quaternion.identity) as GameObject;
            objects.transform.parent = CImpactContainer.transform;
            objects.SetActive(false);
            CImpactList.Add(objects);
        }

        for (int i = 0; i < ObjectsSpawned - 8; i++)
        {
            GameObject objects = Instantiate(CHolo, Vector3.zero, Quaternion.identity) as GameObject;
            objects.transform.parent = CHoloContainer.transform;
            objects.SetActive(false);
            CHoloList.Add(objects);
        }
    }
}
