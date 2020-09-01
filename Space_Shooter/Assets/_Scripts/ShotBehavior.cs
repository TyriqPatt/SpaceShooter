using UnityEngine;
using System.Collections;

public class ShotBehavior : MonoBehaviour {

    public float speed;
    public float Lifetime;
    float LifeCounter;
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
                for (int i = 0; i < ObjectPooling.Instance.CImpactList.Count; i++)
                {
                    if (ObjectPooling.Instance.CImpactList[i].activeInHierarchy == false)
                    {
                        ObjectPooling.Instance.CImpactList[i].SetActive(true);
                        ObjectPooling.Instance.CImpactList[i].GetComponent<DeactivateScript>().Duration = 1f;
                        ObjectPooling.Instance.CImpactList[i].transform.position = transform.position;
                        ObjectPooling.Instance.CImpactList[i].transform.rotation = transform.rotation;
                        break;
                    }
                }
            }
            else if (ClassState == State.Tank)
            {
                for (int i = 0; i < ObjectPooling.Instance.TSImpactList.Count; i++)
                {
                    if (ObjectPooling.Instance.TSImpactList[i].activeInHierarchy == false)
                    {
                        ObjectPooling.Instance.TSImpactList[i].SetActive(true);
                        ObjectPooling.Instance.TSImpactList[i].GetComponent<DeactivateScript>().Duration = 1f;
                        ObjectPooling.Instance.TSImpactList[i].transform.position = transform.position;
                        ObjectPooling.Instance.TSImpactList[i].transform.rotation = transform.rotation;
                        break;
                    }
                }
            }
            else
            {
                for (int i = 0; i < ObjectPooling.Instance.ImpactList.Count; i++)
                {
                    if (ObjectPooling.Instance.ImpactList[i].activeInHierarchy == false)
                    {
                        ObjectPooling.Instance.ImpactList[i].SetActive(true);
                        ObjectPooling.Instance.ImpactList[i].GetComponent<DeactivateScript>().Duration = 1f;
                        ObjectPooling.Instance.ImpactList[i].transform.position = transform.position;
                        ObjectPooling.Instance.ImpactList[i].transform.rotation = transform.rotation;
                        break;
                    }
                }
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
                for (int i = 0; i < ObjectPooling.Instance.CImpactList.Count; i++)
                {
                    if (ObjectPooling.Instance.CImpactList[i].activeInHierarchy == false)
                    {
                        ObjectPooling.Instance.CImpactList[i].SetActive(true);
                        ObjectPooling.Instance.CImpactList[i].GetComponent<DeactivateScript>().Duration = 1f;
                        ObjectPooling.Instance.CImpactList[i].transform.position = transform.position;
                        ObjectPooling.Instance.CImpactList[i].transform.rotation = transform.rotation;
                        break;
                    }
                }
            }
            else if (ClassState == State.Tank)
            {
                for (int i = 0; i < ObjectPooling.Instance.TSImpactList.Count; i++)
                {
                    if (ObjectPooling.Instance.TSImpactList[i].activeInHierarchy == false)
                    {
                        ObjectPooling.Instance.TSImpactList[i].SetActive(true);
                        ObjectPooling.Instance.TSImpactList[i].GetComponent<DeactivateScript>().Duration = 1f;
                        ObjectPooling.Instance.TSImpactList[i].transform.position = transform.position;
                        ObjectPooling.Instance.TSImpactList[i].transform.rotation = transform.rotation;
                        break;
                    }
                }
            }
            else
            {
                for (int i = 0; i < ObjectPooling.Instance.ImpactList.Count; i++)
                {
                    if (ObjectPooling.Instance.ImpactList[i].activeInHierarchy == false)
                    {
                        ObjectPooling.Instance.ImpactList[i].SetActive(true);
                        ObjectPooling.Instance.ImpactList[i].GetComponent<DeactivateScript>().Duration = 1f;
                        ObjectPooling.Instance.ImpactList[i].transform.position = transform.position;
                        ObjectPooling.Instance.ImpactList[i].transform.rotation = transform.rotation;
                        break;
                    }
                }
                gameObject.SetActive(false);
            }
        }
        if (other.gameObject.name == "Wall")
        {
            if (ClassState == State.Commander)
            {
                for (int i = 0; i < ObjectPooling.Instance.CImpactList.Count; i++)
                {
                    if (ObjectPooling.Instance.CImpactList[i].activeInHierarchy == false)
                    {
                        ObjectPooling.Instance.CImpactList[i].SetActive(true);
                        ObjectPooling.Instance.CImpactList[i].GetComponent<DeactivateScript>().Duration = 1f;
                        ObjectPooling.Instance.CImpactList[i].transform.position = transform.position;
                        ObjectPooling.Instance.CImpactList[i].transform.rotation = transform.rotation;
                        break;
                    }
                }
            }
            else if (ClassState == State.Tank)
            {
                for (int i = 0; i < ObjectPooling.Instance.TSImpactList.Count; i++)
                {
                    if (ObjectPooling.Instance.TSImpactList[i].activeInHierarchy == false)
                    {
                        ObjectPooling.Instance.TSImpactList[i].SetActive(true);
                        ObjectPooling.Instance.TSImpactList[i].GetComponent<DeactivateScript>().Duration = 1f;
                        ObjectPooling.Instance.TSImpactList[i].transform.position = transform.position;
                        ObjectPooling.Instance.TSImpactList[i].transform.rotation = transform.rotation;
                        break;
                    }
                }
            }
            else
            {
                for (int i = 0; i < ObjectPooling.Instance.ImpactList.Count; i++)
                {
                    if (ObjectPooling.Instance.ImpactList[i].activeInHierarchy == false)
                    {
                        ObjectPooling.Instance.ImpactList[i].SetActive(true);
                        ObjectPooling.Instance.ImpactList[i].GetComponent<DeactivateScript>().Duration = 1f;
                        ObjectPooling.Instance.ImpactList[i].transform.position = transform.position;
                        ObjectPooling.Instance.ImpactList[i].transform.rotation = transform.rotation;
                        break;
                    }
                }
            }
            gameObject.SetActive(false);
        }
        if (other.gameObject.tag == "Obstruction")
        {
            if (ClassState == State.Commander)
            {
                for (int i = 0; i < ObjectPooling.Instance.CImpactList.Count; i++)
                {
                    if (ObjectPooling.Instance.CImpactList[i].activeInHierarchy == false)
                    {
                        ObjectPooling.Instance.CImpactList[i].SetActive(true);
                        ObjectPooling.Instance.CImpactList[i].GetComponent<DeactivateScript>().Duration = 1f;
                        ObjectPooling.Instance.CImpactList[i].transform.position = transform.position;
                        ObjectPooling.Instance.CImpactList[i].transform.rotation = transform.rotation;
                        break;
                    }
                }
            }
            else if (ClassState == State.Tank)
            {
                for (int i = 0; i < ObjectPooling.Instance.TSImpactList.Count; i++)
                {
                    if (ObjectPooling.Instance.TSImpactList[i].activeInHierarchy == false)
                    {
                        ObjectPooling.Instance.TSImpactList[i].SetActive(true);
                        ObjectPooling.Instance.TSImpactList[i].GetComponent<DeactivateScript>().Duration = 1f;
                        ObjectPooling.Instance.TSImpactList[i].transform.position = transform.position;
                        ObjectPooling.Instance.TSImpactList[i].transform.rotation = transform.rotation;
                        break;
                    }
                }
            }
            else
            {
                for (int i = 0; i < ObjectPooling.Instance.ImpactList.Count; i++)
                {
                    if (ObjectPooling.Instance.ImpactList[i].activeInHierarchy == false)
                    {
                        ObjectPooling.Instance.ImpactList[i].SetActive(true);
                        ObjectPooling.Instance.ImpactList[i].GetComponent<DeactivateScript>().Duration = 1f;
                        ObjectPooling.Instance.ImpactList[i].transform.position = transform.position;
                        ObjectPooling.Instance.ImpactList[i].transform.rotation = transform.rotation;
                        break;
                    }
                }
            }
            gameObject.SetActive(false);
        }
    }

    private void OnDisable()
    {
        LifeCounter = 0;
    }
}
