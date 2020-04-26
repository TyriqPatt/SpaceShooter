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
        Double,
        Frost,
        RedTrail,
        BlueTrail,
        PurpleTrail,
        Slash,
        BlueOrb,
        PurpleOrb,
        OrangeOrb,
        GreenOrb,
        LastOrb,
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
            case State.Frost:
                {
                    objectPooler.SpawnFromPool("Frost", barrel.transform.position, barrel.transform.rotation);
                    objectPooler.SpawnFromPool("Frost", barrelTwo.transform.position, barrelTwo.transform.rotation);
                    objectPooler.SpawnFromPool("Frost", barrelThree.transform.position, barrelThree.transform.rotation);
                    nextTimeToFire = 0;
                    break;
                }
            case State.RedTrail:
                {
                    objectPooler.SpawnFromPool("RedTrail", barrel.transform.position, barrel.transform.rotation);
                    objectPooler.SpawnFromPool("RedTrail", barrelTwo.transform.position, barrelTwo.transform.rotation);
                    objectPooler.SpawnFromPool("RedTrail", barrelThree.transform.position, barrelThree.transform.rotation);
                    nextTimeToFire = 0;
                    break;
                }
            case State.BlueTrail:
                {
                    objectPooler.SpawnFromPool("BlueTrail", barrel.transform.position, barrel.transform.rotation);
                    objectPooler.SpawnFromPool("BlueTrail", barrelTwo.transform.position, barrelTwo.transform.rotation);
                    objectPooler.SpawnFromPool("BlueTrail", barrelThree.transform.position, barrelThree.transform.rotation);
                    nextTimeToFire = 0;
                    break;
                }
            case State.PurpleTrail:
                {
                    objectPooler.SpawnFromPool("PurpleTrail", barrel.transform.position, barrel.transform.rotation);
                    objectPooler.SpawnFromPool("PurpleTrail", barrelTwo.transform.position, barrelTwo.transform.rotation);
                    objectPooler.SpawnFromPool("PurpleTrail", barrelThree.transform.position, barrelThree.transform.rotation);
                    nextTimeToFire = 0;
                    break;
                }
            case State.Slash:
                {
                    objectPooler.SpawnFromPool("Slash", barrel.transform.position, barrel.transform.rotation);
                    objectPooler.SpawnFromPool("Slash", barrelTwo.transform.position, barrelTwo.transform.rotation);
                    objectPooler.SpawnFromPool("Slash", barrelThree.transform.position, barrelThree.transform.rotation);
                    nextTimeToFire = 0;
                    break;
                }
            case State.BlueOrb:
                {
                    objectPooler.SpawnFromPool("BlueOrb", barrel.transform.position, barrel.transform.rotation);
                    objectPooler.SpawnFromPool("BlueOrb", barrelTwo.transform.position, barrelTwo.transform.rotation);
                    objectPooler.SpawnFromPool("BlueOrb", barrelThree.transform.position, barrelThree.transform.rotation);
                    nextTimeToFire = 0;
                    break;
                }
            case State.PurpleOrb:
                {
                    objectPooler.SpawnFromPool("PurpleOrb", barrel.transform.position, barrel.transform.rotation);
                    objectPooler.SpawnFromPool("PurpleOrb", barrelTwo.transform.position, barrelTwo.transform.rotation);
                    objectPooler.SpawnFromPool("PurpleOrb", barrelThree.transform.position, barrelThree.transform.rotation);
                    nextTimeToFire = 0;
                    break;
                }
            case State.OrangeOrb:
                {
                    objectPooler.SpawnFromPool("OrangeOrb", barrel.transform.position, barrel.transform.rotation);
                    objectPooler.SpawnFromPool("OrangeOrb", barrelTwo.transform.position, barrelTwo.transform.rotation);
                    objectPooler.SpawnFromPool("OrangeOrb", barrelThree.transform.position, barrelThree.transform.rotation);
                    nextTimeToFire = 0;
                    break;
                }
            case State.GreenOrb:
                {
                    objectPooler.SpawnFromPool("GreenOrb", barrel.transform.position, barrel.transform.rotation);
                    objectPooler.SpawnFromPool("GreenOrb", barrelTwo.transform.position, barrelTwo.transform.rotation);
                    objectPooler.SpawnFromPool("GreenOrb", barrelThree.transform.position, barrelThree.transform.rotation);
                    nextTimeToFire = 0;
                    break;
                }
            case State.LastOrb:
                {
                    objectPooler.SpawnFromPool("RedOrb", barrel.transform.position, barrel.transform.rotation);
                    objectPooler.SpawnFromPool("RedOrb", barrelTwo.transform.position, barrelTwo.transform.rotation);
                    objectPooler.SpawnFromPool("RedOrb", barrelThree.transform.position, barrelThree.transform.rotation);
                    nextTimeToFire = 0;
                    break;
                }
        }



    }



}
