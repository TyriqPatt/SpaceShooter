using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DashAbility : MonoBehaviour
{

    public GameObject TankMelee;
    public GameObject CommanderMine;
    public TopDownMovement Movement;

    public enum State { Tank, Commander, Scout }

    public State ClassState;


    // Start is called before the first frame update
    void Start()
    {
        Movement = GetComponent<TopDownMovement>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AbilityCall()
    {
        if (ClassState == State.Tank)
        {
            StartCoroutine(TankMeleeDash());
        }
        else if(ClassState == State.Commander)
        {
            GameObject Mine = Instantiate(CommanderMine, transform.position, transform.rotation);
            Mine.GetComponent<DestroyScript>().Duration = 2;
        }
        else if(ClassState == State.Scout)
        {
            StartCoroutine(ScoutTempSpeed());
        }
    }

    IEnumerator TankMeleeDash()
    {
        TankMelee.gameObject.SetActive(true);
        TankMelee.transform.position = transform.position;
        yield return new WaitForSeconds(1f);
        TankMelee.gameObject.SetActive(false);
    }

    IEnumerator ScoutTempSpeed()
    {
        Movement.moveSpeed *= 1.75f;
        yield return new WaitForSeconds(3f);
        Movement.moveSpeed /= 1.75f;
    }

}
