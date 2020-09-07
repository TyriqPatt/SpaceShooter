using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Canons : MonoBehaviour
{

    public Transform RightCanon, RightCanon2, LeftCanon, LeftCanon2, CenterCanon;
    public ParticleSystem Leftps, Rightps;
    public float Firerate = 15f;
    public float nextTimeToFire = 0f;
    public bool isCommanderHolo;
    public Transform parent;
    public enum State { Tank, Commander, CommanderHolo, Scout }

    public State ClassState;

    // Start is called before the first frame update
    void Start()
    {
        parent = transform.parent;
        if (ClassState == State.Tank)
        {
            TankWeapon();
        }
        else if (ClassState == State.Commander)
        {
            CommanderWeapon();
        }
        else if (ClassState == State.CommanderHolo)
        {
            CommanderHoloWeapon();
        }
        else if (ClassState == State.Scout)
        {
            ScoutWeapon();
        }        
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.timeScale != 0)
        {
            if (!isCommanderHolo)
            {
                if (Input.GetButton("Fire1") && Time.time >= nextTimeToFire)
                {
                    nextTimeToFire = Time.time + 1f / Firerate;
                    if (ClassState == State.Tank)
                    {
                        DuelFire();
                    }
                    else
                    {
                        SingleFire();
                    }
                }
            }
            else
            {
                if (Time.time >= nextTimeToFire)
                {
                    nextTimeToFire = Time.time + 1f / Firerate;
                    if (ClassState == State.Tank)
                    {
                        DuelFire();
                    }
                    else
                    {
                        SingleFire();
                    }
                }
            }
            
            
        }
    }

    void SingleFire()
    {
        for (int i = 0; i < ObjectPooling.Instance.ObjectList.Count; i++)
        {
            if (ObjectPooling.Instance.ObjectList[i].activeInHierarchy == false)
            {
                if(ClassState == State.Commander)
                {
                    ObjectPooling.Instance.ObjectList[i].GetComponent<ShotBehavior>().ClassState = ShotBehavior.State.Commander;
                    ObjectPooling.Instance.ObjectList[i].SetActive(true);
                    ObjectPooling.Instance.ObjectList[i].transform.position = CenterCanon.transform.position;
                    ObjectPooling.Instance.ObjectList[i].transform.rotation = CenterCanon.transform.rotation;
                }
                else if(ClassState == State.CommanderHolo)
                {
                    ObjectPooling.Instance.ObjectList[i].GetComponent<ShotBehavior>().ClassState = ShotBehavior.State.Scout;
                    ObjectPooling.Instance.ObjectList[i].SetActive(true);
                    ObjectPooling.Instance.ObjectList[i].transform.position = CenterCanon.transform.position;
                    ObjectPooling.Instance.ObjectList[i].transform.rotation = CenterCanon.transform.rotation;
                }
                else
                {
                    ObjectPooling.Instance.ObjectList[i].GetComponent<ShotBehavior>().ClassState = ShotBehavior.State.Scout;
                    ObjectPooling.Instance.ObjectList[i].SetActive(true);
                    ObjectPooling.Instance.ObjectList[i].transform.position = CenterCanon.transform.position;
                    ObjectPooling.Instance.ObjectList[i].transform.rotation = CenterCanon.transform.rotation;
                }
                
                break;
            }
        }
    }

    public void TankSpecialShoot()
    {
        for (int i = 0; i < ObjectPooling.Instance.TankShotList.Count; i++)
        {
            if (ObjectPooling.Instance.TankShotList[i].activeInHierarchy == false)
            {
                ObjectPooling.Instance.TankShotList[i].SetActive(true);
                ObjectPooling.Instance.TankShotList[i].GetComponent<ShotBehavior>().Lifetime = .115f;
                ObjectPooling.Instance.TankShotList[i].GetComponent<ShotBehavior>().ClassState = ShotBehavior.State.Tank;
                ObjectPooling.Instance.TankShotList[i].transform.position = CenterCanon.transform.position;
                ObjectPooling.Instance.TankShotList[i].transform.rotation = CenterCanon.transform.rotation;
                break;
            }
        }
    }

    void DuelFire()
    {
        shoot();
        shoot2();
        shoot3();
        shoot4();
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

    void shoot3()
    {
        for (int i = 0; i < ObjectPooling.Instance.ObjectList.Count; i++)
        {
            if (ObjectPooling.Instance.ObjectList[i + 2].activeInHierarchy == false)
            {
                ObjectPooling.Instance.ObjectList[i + 2].SetActive(true);
                ObjectPooling.Instance.ObjectList[i + 2].transform.position = RightCanon2.transform.position;
                ObjectPooling.Instance.ObjectList[i + 2].transform.rotation = RightCanon2.transform.rotation;
                break;
            }
        }
        //Instantiate(CurLaser, rightCanon.position, rightCanon.rotation);
        //Instantiate(CurLaser, LeftCanon.position, LeftCanon.rotation);
        //Rightps.Play();
        //Leftps.Play();
    }

    void shoot4()
    {
        for (int i = 0; i < ObjectPooling.Instance.ObjectList.Count; i++)
        {
            if (ObjectPooling.Instance.ObjectList[i + 3].activeInHierarchy == false)
            {
                ObjectPooling.Instance.ObjectList[i + 3].SetActive(true);
                ObjectPooling.Instance.ObjectList[i + 3].transform.position = LeftCanon2.transform.position;
                ObjectPooling.Instance.ObjectList[i + 3].transform.rotation = LeftCanon2.transform.rotation;
                break;
            }
        }
        //Instantiate(CurLaser, rightCanon.position, rightCanon.rotation);
        //Instantiate(CurLaser, LeftCanon.position, LeftCanon.rotation);
        //Rightps.Play();
        //Leftps.Play();
    }

    public void CommanderWeapon()
    {
        Firerate = 3f;
        for (int i = 0; i < ObjectPooling.Instance.ObjectList.Count; i++)
        {
            ObjectPooling.Instance.ObjectList[i].GetComponent<ShotBehavior>().Lifetime = .2f;
            ObjectPooling.Instance.ObjectList[i].GetComponent<ShotBehavior>().ClassState = ShotBehavior.State.Commander;
        }
    }

    public void CommanderHoloWeapon()
    {
        Firerate = 3f;
        for (int i = 0; i < ObjectPooling.Instance.ObjectList.Count; i++)
        {
            ObjectPooling.Instance.ObjectList[i].GetComponent<ShotBehavior>().Lifetime = .2f;
            ObjectPooling.Instance.ObjectList[i].GetComponent<ShotBehavior>().ClassState = ShotBehavior.State.Scout;
        }
    }

    public void ScoutWeapon()
    {
        Firerate = 8;
        for (int i = 0; i < ObjectPooling.Instance.ObjectList.Count; i++)
        {
            ObjectPooling.Instance.ObjectList[i].GetComponent<ShotBehavior>().Lifetime = .25f;
            ObjectPooling.Instance.ObjectList[i].GetComponent<ShotBehavior>().ClassState = ShotBehavior.State.Scout;
        }
    }

    public void TankWeapon()
    {
        Firerate = 2f;
        for (int i = 0; i < ObjectPooling.Instance.ObjectList.Count; i++)
        {
            ObjectPooling.Instance.ObjectList[i].GetComponent<ShotBehavior>().Lifetime = .1f;
            ObjectPooling.Instance.ObjectList[i].GetComponent<ShotBehavior>().ClassState = ShotBehavior.State.Scout;
        }
    }
}
