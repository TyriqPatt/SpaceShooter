using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Class : MonoBehaviour
{

    public DashAbility DashAbility;
    public TopDownMovement Movement;
    public GameObject CommanderClass, TankClass, ScoutClass;

    public enum State { Tank, Commander, Scout }

    public State ClassState;

    // Start is called before the first frame update
    void Start()
    {
        DashAbility = GetComponent<DashAbility>();
        Movement = GetComponent<TopDownMovement>();

        if (ClassState == State.Tank)
        {
            TankClass.gameObject.SetActive(true);
            Movement.PlayerObj = TankClass;
            DashAbility.ClassState = DashAbility.State.Tank;
            Movement.ClassState = TopDownMovement.C_State.Tank;
        }
        else if (ClassState == State.Commander)
        {
            CommanderClass.gameObject.SetActive(true);
            Movement.PlayerObj = CommanderClass;
            DashAbility.ClassState = DashAbility.State.Commander;
            Movement.ClassState = TopDownMovement.C_State.Commander;
        }
        else if (ClassState == State.Scout)
        {
            ScoutClass.gameObject.SetActive(true);
            Movement.PlayerObj = ScoutClass;
            DashAbility.ClassState = DashAbility.State.Scout;
            Movement.ClassState = TopDownMovement.C_State.Scout;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
