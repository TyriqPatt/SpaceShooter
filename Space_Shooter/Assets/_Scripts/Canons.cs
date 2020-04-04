using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Canons : MonoBehaviour
{

    public GameObject CurLaser, laser, HeavyLaser;
    public Transform RightCanon, LeftCanon, CenterCanon;
    public ParticleSystem Leftps, Rightps;
    public float Firerate = 15f;
    public float nextTimeToFire = 0f;


    // Start is called before the first frame update
    void Start()
    {
        CurLaser = laser;
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.timeScale != 0)
        {
            if (Input.GetButton("Fire1") && Time.time >= nextTimeToFire)
            {
                nextTimeToFire = Time.time + 1f / Firerate;
                SingleFire();
            }
        }
    }

    void SingleFire()
    {
        for (int i = 0; i < ObjectPooling.Instance.ObjectList.Count; i++)
        {
            if (ObjectPooling.Instance.ObjectList[i].activeInHierarchy == false)
            {
                ObjectPooling.Instance.ObjectList[i].SetActive(true);
                ObjectPooling.Instance.ObjectList[i].transform.position = CenterCanon.transform.position;
                ObjectPooling.Instance.ObjectList[i].transform.rotation = CenterCanon.transform.rotation;

                break;
            }
        }

     
    }

    void DuelFire()
    {
        shoot();
        shoot2();
    }

    void shoot()
    {
        for (int i = 0; i < ObjectPooling.Instance.ObjectList.Count; i++)
        {
            if (ObjectPooling.Instance.ObjectList[i].activeInHierarchy == false)
            {
                ObjectPooling.Instance.ObjectList[i].SetActive(true);
                ObjectPooling.Instance.ObjectList[i].transform.position = RightCanon.transform.position;
                ObjectPooling.Instance.ObjectList[i].transform.rotation = RightCanon.transform.rotation;

                break;
            }
        }
    }

    void shoot2()
    {
        for (int i = 0; i < ObjectPooling.Instance.ObjectList.Count; i++)
        {
            if (ObjectPooling.Instance.ObjectList[i + 1].activeInHierarchy == false)
            {

                ObjectPooling.Instance.ObjectList[i + 1].SetActive(true);
                ObjectPooling.Instance.ObjectList[i + 1].transform.position = LeftCanon.transform.position;
                ObjectPooling.Instance.ObjectList[i + 1].transform.rotation = LeftCanon.transform.rotation;
                break;
            }
        }

        //Instantiate(CurLaser, rightCanon.position, rightCanon.rotation);
        //Instantiate(CurLaser, LeftCanon.position, LeftCanon.rotation);
        //Rightps.Play();
        //Leftps.Play();
    }
}
