using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JR_EneObjectPooler : MonoBehaviour
{
    [System.Serializable]
    public class Pool
    {
        public string tag;
        public GameObject prefab;
        public int size; 
    }
    #region Singleton
    public static JR_EneObjectPooler Instance;
    private void Awake()
    {
        Instance = this; 
    }

    #endregion
     
    public List<Pool> listOfPools; 
    public Dictionary<string, Queue<GameObject>> poolDictionary;
    public GameObject BulletContainer;

    // Start is called before the first frame update
    void Start()
    {
        poolDictionary = new Dictionary<string, Queue<GameObject>>();  

        foreach (Pool pool in listOfPools)
        {
            Queue<GameObject> objectPool = new Queue<GameObject>(); 

            for (int i = 0; i < pool.size; i++)
            {
                GameObject obj = Instantiate(pool.prefab);
                obj.SetActive(false);
                objectPool.Enqueue(obj);
                obj.transform.parent = BulletContainer.transform;

            }

            poolDictionary.Add(pool.tag, objectPool); 
        }
    }

    public GameObject SpawnFromPool(string tag, Vector3 position, Quaternion rotation)
    {

        if(!poolDictionary.ContainsKey(tag))
        {
            Debug.Log(" Pool with tag " + tag + " doesn't exist. ");
            return null;  
        }


        GameObject objectToSpawn = poolDictionary[tag].Dequeue();

        objectToSpawn.SetActive(true);
        objectToSpawn.transform.position = position;
        objectToSpawn.transform.rotation = rotation;

        poolDictionary[tag].Enqueue(objectToSpawn);

        return objectToSpawn; 
    }

   
}
