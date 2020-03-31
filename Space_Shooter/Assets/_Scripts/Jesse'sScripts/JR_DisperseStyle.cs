using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JR_DisperseStyle : MonoBehaviour
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
    private Transform barrelFour;
    private Transform barrelFive;
    private Transform barrelSix;
    private Transform barrelSeven;
    private Transform barrelEigth;

    public int BulletType;


    // Start is called before the first frame update
    void Start()
    {

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
            Instantiate(CurrentBullet, barrel.position, barrel.rotation);
            Instantiate(CurrentBullet, barrelTwo.position, barrelTwo.rotation);
            Instantiate(CurrentBullet, barrelThree.position, barrelThree.rotation);
            Instantiate(CurrentBullet, barrelFour.position, barrelFour.rotation);
            Instantiate(CurrentBullet, barrelFive.position, barrelFive.rotation);
            Instantiate(CurrentBullet, barrelSix.position, barrelSix.rotation);
            Instantiate(CurrentBullet, barrelSeven.position, barrelSeven.rotation);
            Instantiate(CurrentBullet, barrelEigth.position, barrelEigth.rotation);

            fireRate = startTime;
        }
    }

}
    

