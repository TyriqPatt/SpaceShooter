using UnityEngine;
using System.Collections;

public class ShotBehavior : MonoBehaviour {

    public float speed;
    public float Lifetime;
    float LifeCounter;
    public GameObject W_impact;
    public JR_EnemyHealth Enemy_HP;

    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		transform.position += transform.forward * Time.deltaTime * speed;
        LifeCounter += Time.deltaTime;
        if(LifeCounter >= Lifetime)
        {
            gameObject.SetActive(false);
        }

	}

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            Debug.Log("Hit");
            Enemy_HP = other.GetComponent<JR_EnemyHealth>();
            Enemy_HP.TakeDamage(DamageValues._instance.BasicBullet);
            gameObject.SetActive(false);
        }
    }

    private void OnDisable()
    {
        LifeCounter = 0;
    }
}
