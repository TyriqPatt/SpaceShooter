using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JR_SingleShotStyle : MonoBehaviour
{
  
    public Transform barrel;

    public float Firerate = 4f;
    public float nextTimeToFire = 0f;
    //JR_EnemyObjectPooling m_objectPooling;
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
    

    //JR_EnemyObjectPooling m_enemyOjectPooling; 

    // Start is called before the first frame update
    void Start()
    {
        //barrel = gameObject.transform.GetChild(0).transform;
        // m_objectPooling = GetComponent<JR_EnemyObjectPooling>(); 
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
        switch(_state)
        {
            case State.Fire:
                {
                    objectPooler.SpawnFromPool("Fire", barrel.transform.position, barrel.transform.rotation);
                    nextTimeToFire = 0;
                    break; 
                }
            case State.Lighting:
                {
                    objectPooler.SpawnFromPool("Lighting", barrel.transform.position, barrel.transform.rotation);
                    nextTimeToFire = 0;
                    break;
                }
            case State.BlackHole:
                {
                    objectPooler.SpawnFromPool("BlackHole", barrel.transform.position, barrel.transform.rotation);
                    nextTimeToFire = 0;
                    break;
                }
            case State.Double:
                {
                    objectPooler.SpawnFromPool("Double", barrel.transform.position, barrel.transform.rotation);
                    nextTimeToFire = 0;
                    break;
                }
            case State.Frost:
                {
                    objectPooler.SpawnFromPool("Frost", barrel.transform.position, barrel.transform.rotation);
                    nextTimeToFire = 0;
                    break;
                }
            case State.RedTrail:
                {
                    objectPooler.SpawnFromPool("RedTrail", barrel.transform.position, barrel.transform.rotation);
                    nextTimeToFire = 0;
                    break;
                }
            case State.BlueTrail:
                {
                    objectPooler.SpawnFromPool("BlueTrail", barrel.transform.position, barrel.transform.rotation);
                    nextTimeToFire = 0;
                    break;
                }
            case State.PurpleTrail:
                {
                    objectPooler.SpawnFromPool("PurpleTrail", barrel.transform.position, barrel.transform.rotation);
                    nextTimeToFire = 0;
                    break;
                }
            case State.Slash:
                {
                    objectPooler.SpawnFromPool("Slash", barrel.transform.position, barrel.transform.rotation);
                    nextTimeToFire = 0;
                    break;
                }
            case State.BlueOrb:
                {
                    objectPooler.SpawnFromPool("BlueOrb", barrel.transform.position, barrel.transform.rotation);
                    nextTimeToFire = 0;
                    break;
                }
            case State.PurpleOrb:
                {
                    objectPooler.SpawnFromPool("PurpleOrb", barrel.transform.position, barrel.transform.rotation);
                    nextTimeToFire = 0;
                    break;
                }
            case State.OrangeOrb:
                {
                    objectPooler.SpawnFromPool("OrangeOrb", barrel.transform.position, barrel.transform.rotation);
                    nextTimeToFire = 0;
                    break;
                }
            case State.GreenOrb:
                {
                    objectPooler.SpawnFromPool("GreenOrb", barrel.transform.position, barrel.transform.rotation);
                    nextTimeToFire = 0;
                    break;
                }
            case State.LastOrb:
                {
                    objectPooler.SpawnFromPool("RedOrb", barrel.transform.position, barrel.transform.rotation);
                    nextTimeToFire = 0;
                    break;
                }
            
        }
        

      
    }
}
