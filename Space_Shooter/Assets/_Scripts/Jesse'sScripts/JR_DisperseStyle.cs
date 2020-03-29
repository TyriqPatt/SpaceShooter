using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JR_DisperseStyle : MonoBehaviour
{
    public float fireRate;
    private float startTime;
    private bool canShoot;


    public GameObject BasicProjectile;
   


    private Transform barrel;
    private Transform barrelTwo;
    private Transform barrelThree;
    private Transform barrelFour;
    private Transform barrelFive;
    private Transform barrelSix;
    private Transform barrelSeven;
    private Transform barrelEigth;



    // Start is called before the first frame update
    void Start()
    {
        startTime = fireRate;
        barrel = gameObject.transform.GetChild(0).transform;
        barrelTwo = gameObject.transform.GetChild(1).transform;
        barrelThree = gameObject.transform.GetChild(2).transform;
        barrelFour = gameObject.transform.GetChild(3).transform;
        barrelFive = gameObject.transform.GetChild(4).transform;
        barrelSix = gameObject.transform.GetChild(5).transform;
        barrelSeven = gameObject.transform.GetChild(6).transform;
        barrelEigth = gameObject.transform.GetChild(7).transform;



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
            Instantiate(BasicProjectile, barrelFour.position, barrelFour.rotation);
            Instantiate(BasicProjectile, barrelFive.position, barrelFive.rotation);
            Instantiate(BasicProjectile, barrelSix.position, barrelSix.rotation);
            Instantiate(BasicProjectile, barrelSeven.position, barrelSeven.rotation);
            Instantiate(BasicProjectile, barrelEigth.position, barrelEigth.rotation);

            fireRate = startTime;
        }
    }
}
