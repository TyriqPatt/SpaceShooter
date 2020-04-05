using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JR_SingleShotStyle : MonoBehaviour
{
  
    public Transform barrel;

    public float Firerate = 4f;
    public float nextTimeToFire = 0f;

    

    //JR_EnemyObjectPooling m_enemyOjectPooling; 

    // Start is called before the first frame update
    void Start()
    {
        //barrel = gameObject.transform.GetChild(0).transform;

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
        for (int i = 0; i < JR_EnemyObjectPooling.Instance.ObjectList.Count; i++)
        {
            if (JR_EnemyObjectPooling.Instance.ObjectList[i].activeInHierarchy == false)
            {
                JR_EnemyObjectPooling.Instance.ObjectList[i].SetActive(true);
                JR_EnemyObjectPooling.Instance.ObjectList[i].transform.position = barrel.transform.position;
                JR_EnemyObjectPooling.Instance.ObjectList[i].transform.rotation = barrel.transform.rotation;

                break;
            }
        }
        nextTimeToFire = 0;

      
    }
}
