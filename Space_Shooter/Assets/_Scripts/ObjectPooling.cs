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
    //initial amount of objects spawned 
    public int ObjectsSpawned = 20;
    //List to hold pooled objects
    public List<GameObject> ObjectList = new List<GameObject>();

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
            objects.transform.parent = this.transform;
            objects.SetActive(false);
            ObjectList.Add(objects);
        }
    }
}
