using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JR_SpreadStyle : MonoBehaviour
{
    public float fireRate;
    private float startTime;
    private bool canShoot;


    public GameObject BasicProjectile;



    private Transform barrel;
    private Transform barrelTwo;
    private Transform barrelThree;
   



    // Start is called before the first frame update
    void Start()
    {
        startTime = fireRate;
        barrel = gameObject.transform.GetChild(0).transform;
        barrelTwo = gameObject.transform.GetChild(1).transform;
        barrelThree = gameObject.transform.GetChild(2).transform;
      
    }

    // Update is called once per frame
    void Update()
    {
        fireRate -= Time.deltaTime;

        if (fireRate <= 0)
        {
            Instantiate(BasicProjectile, barrel.position, barrel.rotation);
            Instantiate(BasicProjectile, barrelTwo.position, barrelTwo.rotation);
            Instantiate(BasicProjectile, barrelThree.position, barrelThree.rotation);
           

            fireRate = startTime;
        }
    }
}
