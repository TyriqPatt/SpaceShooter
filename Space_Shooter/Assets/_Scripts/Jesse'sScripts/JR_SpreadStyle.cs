using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JR_SpreadStyle : MonoBehaviour
{
    public float Firerate = 4f;
    public float nextTimeToFire = 0f;






    public Transform barrel;
    public Transform barrelTwo;
    public Transform barrelThree;




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
                JR_EnemyObjectPooling.Instance.ObjectList[i].transform.position = barrelTwo.transform.position;
                JR_EnemyObjectPooling.Instance.ObjectList[i].transform.rotation = barrelTwo.transform.rotation;
                JR_EnemyObjectPooling.Instance.ObjectList[i].transform.position = barrelThree.transform.position;
                JR_EnemyObjectPooling.Instance.ObjectList[i].transform.rotation = barrelThree.transform.rotation;
                break;
            }
        }
        nextTimeToFire = 0;


    }
}
