using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class JR_EnemyMovement : MonoBehaviour
{
    public int MovementType; 
    private NavMeshAgent navAgent;

    private GameObject player;
    private float distance; 

    // Start is called before the first frame update
    void Start()
    {
        navAgent = gameObject.GetComponent<NavMeshAgent>();
        player = GameObject.FindGameObjectWithTag("Player"); 

      
    }

    // Update is called once per frame
    void Update()
    {
        transform.LookAt(player.transform);


        switch (MovementType)
        {
            case 3:
                print("Something");
                break;
            case 2:
                EnemyMove();
                print("Moving");
                break;
            case 1:
                print("Stationary");
                break;
            default:
                print("Nothing");
                break;
        }

    }


    private void EnemyMove()
    {
        GetComponent<NavMeshAgent>().Move(transform.forward * Time.deltaTime);

    }


}
