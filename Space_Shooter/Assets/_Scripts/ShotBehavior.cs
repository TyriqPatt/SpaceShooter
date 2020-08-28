using UnityEngine;
using System.Collections;

public class ShotBehavior : MonoBehaviour {

    public float speed;
    public float Lifetime;
    float LifeCounter;
    public GameObject W_impact;
    public GameObject CommanderImpact;
    public JR_EnemyHealth Enemy_HP;
    public enum State { Tank, Commander, Scout }

    public State ClassState;

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
            if(ClassState == State.Commander)
            {
                GameObject Cimpact = Instantiate(CommanderImpact, transform.position, transform.rotation);
                Cimpact.GetComponent<DestroyScript>().Duration = 1;
            }
            else
            {
                GameObject Wimpact = Instantiate(W_impact, transform.position, transform.rotation);
                Wimpact.GetComponent<DestroyScript>().Duration = 1;
            }
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
            if (ClassState == State.Commander)
            {
                GameObject Cimpact = Instantiate(CommanderImpact, transform.position, transform.rotation);
                Cimpact.GetComponent<DestroyScript>().Duration = 1;
            }
            else
            {
                GameObject Wimpact = Instantiate(W_impact, transform.position, transform.rotation);
                Wimpact.GetComponent<DestroyScript>().Duration = 1;
                gameObject.SetActive(false);
            }
        }
        if (other.gameObject.name == "Wall")
        {
            if (ClassState == State.Commander)
            {
                GameObject Cimpact = Instantiate(CommanderImpact, transform.position, transform.rotation);
                Cimpact.GetComponent<DestroyScript>().Duration = 1;
                gameObject.SetActive(false);
            }
            else
            {
                GameObject Wimpact = Instantiate(W_impact, transform.position, transform.rotation);
                Wimpact.GetComponent<DestroyScript>().Duration = 1;
                gameObject.SetActive(false);
            }
        }
        if (other.gameObject.tag == "Obstruction")
        {
            if (ClassState == State.Commander)
            {
                GameObject Cimpact = Instantiate(CommanderImpact, transform.position, transform.rotation);
                Cimpact.GetComponent<DestroyScript>().Duration = 1;
                gameObject.SetActive(false);
            }
            else
            {
                GameObject Wimpact = Instantiate(W_impact, transform.position, transform.rotation);
                Wimpact.GetComponent<DestroyScript>().Duration = 1;
                gameObject.SetActive(false);
            }
        }
    }

    private void OnDisable()
    {
        LifeCounter = 0;
    }
}
