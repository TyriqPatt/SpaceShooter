using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JR_SwirlStyle : MonoBehaviour
{
    public float fireRate;
    private float startTime;
    private bool canShoot;


    public GameObject BasicProjectile;



    private Transform barrel;

    // Start is called before the first frame update
    void Start()
    {
        startTime = fireRate;
        barrel = gameObject.transform.GetChild(0).transform;

    }

    // Update is called once per frame
    void Update()
    {
        fireRate -= Time.deltaTime;

        if (fireRate <= 0)
        {
            Instantiate(BasicProjectile, barrel.position, barrel.rotation);

            fireRate = startTime;
        }
    }
}
