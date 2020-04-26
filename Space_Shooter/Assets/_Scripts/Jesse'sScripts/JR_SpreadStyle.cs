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

    public JR_EneObjectPooler objectPooler;

    public enum State
    {
        Fire,
        Lighting,
        BlackHole,
        Double
    }
    public State _state;


    // Start is called before the first frame update
    void Start()
    {
        //barrel = gameObject.transform.GetChild(0).transform;
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
        switch (_state)
        {
            case State.Fire:
                {
                    objectPooler.SpawnFromPool("Fire", barrel.transform.position, barrel.transform.rotation);
                    objectPooler.SpawnFromPool("Fire", barrelTwo.transform.position, barrelTwo.transform.rotation);
                    objectPooler.SpawnFromPool("Fire", barrelThree.transform.position, barrelThree.transform.rotation);

                    nextTimeToFire = 0;
                    break;
                }
            case State.Lighting:
                {
                    objectPooler.SpawnFromPool("Lighting", barrel.transform.position, barrel.transform.rotation);
                    objectPooler.SpawnFromPool("Lighting", barrelTwo.transform.position, barrelTwo.transform.rotation);
                    objectPooler.SpawnFromPool("Lighting", barrelThree.transform.position, barrelThree.transform.rotation);

                    nextTimeToFire = 0;
                    break;
                }
            case State.BlackHole:
                {
                    objectPooler.SpawnFromPool("BlackHole", barrel.transform.position, barrel.transform.rotation);
                    objectPooler.SpawnFromPool("BlackHole", barrelTwo.transform.position, barrelTwo.transform.rotation);
                    objectPooler.SpawnFromPool("BlackHole", barrelThree.transform.position, barrelThree.transform.rotation);

                    nextTimeToFire = 0;
                    break;
                }
            case State.Double:
                {
                    objectPooler.SpawnFromPool("Double", barrel.transform.position, barrel.transform.rotation);
                    objectPooler.SpawnFromPool("Double", barrelTwo.transform.position, barrelTwo.transform.rotation);
                    objectPooler.SpawnFromPool("Double", barrelThree.transform.position, barrelThree.transform.rotation);

                    nextTimeToFire = 0;
                    break;
                }
        }



    }



}
