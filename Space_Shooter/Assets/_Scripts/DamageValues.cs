using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageValues : MonoBehaviour
{

    public int BasicBullet;

    public int EnemyBullet;


    public static DamageValues _instance;
    // Start is called before the first frame update
    void Start()
    {
        _instance = GetComponent<DamageValues>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
