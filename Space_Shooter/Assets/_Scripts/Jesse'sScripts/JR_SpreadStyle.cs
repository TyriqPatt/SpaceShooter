using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JR_SpreadStyle : MonoBehaviour
{
    public float fireRate;
    private float startTime;
    private bool canShoot;


    public GameObject BasicProjectile;
    public GameObject TrackingProjectile;
    public GameObject SwirlProjectile;

    private GameObject CurrentBullet;


    private Transform barrel;
    private Transform barrelTwo;
    private Transform barrelThree;

    public int BulletType = 1;



    // Start is called before the first frame update
    void Start()
    {
        startTime = fireRate;
        barrel = gameObject.transform.GetChild(0).transform;
        barrelTwo = gameObject.transform.GetChild(1).transform;
        barrelThree = gameObject.transform.GetChild(2).transform;

        switch (BulletType)
        {
            case 3:
                CurrentBullet = SwirlProjectile;
                print("Swirl");
                break;
            case 2:
                CurrentBullet = TrackingProjectile;
                print("Tracking");
                break;
            case 1:
                CurrentBullet = BasicProjectile;

                print("Basic");
                break;
            default:
                print("No Bullet");
                break;
        }

    }


    // Update is called once per frame
    void Update()
    {
        fireRate -= Time.deltaTime;

        if (fireRate <= 0)
        {
            Instantiate(CurrentBullet, barrel.position, barrel.rotation);
            Instantiate(CurrentBullet, barrelTwo.position, barrelTwo.rotation);
            Instantiate(CurrentBullet, barrelThree.position, barrelThree.rotation);
           

            fireRate = startTime;
        }
    }
}
