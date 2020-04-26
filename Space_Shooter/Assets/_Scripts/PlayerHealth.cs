using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    //Current health value
    public float CurHearts;
    //Max health value can be set in inspector or from another script
    public float MaxHearts = 3;
    //Reference to all the hearts
    public GameObject[] Hearts;

    public MeshRenderer Mrend;

    public float _MaxIFrames;
    float _IFrames;

    // Use this for initialization
    void Start()
    {
        //Sets current health to max health
        CurHearts = MaxHearts;
        //Sets hearts active equal to max health
        for (int i = 0; i < Hearts.Length; i++)
        {
            if(i > MaxHearts - 1)
            {
                Hearts[i].SetActive(false);
            }

        }
        Mrend = GetComponent<MeshRenderer>();
    }

    //Call this method when enemy takes damage
    public void DealDamage(float DamageValue)
    {
        _IFrames = _MaxIFrames;
        CurHearts -= DamageValue;
        RemoveHeart();
        if (CurHearts <= 0)
        {
            Die();
        }
    }

    //Sets hearts active equal to current health
    void RemoveHeart()
    {
        for (int i = 0; i < Hearts.Length; i++)
        {
            if (i > CurHearts - 1)
            {
                Hearts[i].SetActive(false);
            }
        }
        StartCoroutine(IFrames());
    }

    //A death method to call death animation, particles, or destroy
    void Die()
    {
        CurHearts = 0;
        Debug.Log("Dead");
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Bullet"))
        {
            //DealDamage(DamageValues._instance.EnemyBullet);
        }
    }

    IEnumerator IFrames()
    {
        Mrend.enabled = false;
        gameObject.tag = "Invincible";
        yield return new WaitForSeconds(.2f);
        Mrend.enabled = true;
        yield return new WaitForSeconds(.2f);
        if (_IFrames > 0)
        {
            if (_IFrames > 1)
            {
                StartCoroutine(IFrames());
            }
            _IFrames -= 1;
        }
        if(_IFrames == 0)
        {
            gameObject.tag = "Player";
        }
    }
}
