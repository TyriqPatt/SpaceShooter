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

    private Vector3 playerVec;
    // Start is called before the first frame update
    void Start()
    {
        navAgent = gameObject.GetComponent<NavMeshAgent>();
        player = GameObject.FindGameObjectWithTag("Player");
        playerVec = new Vector3(player.transform.position.x, 0, player.transform.position.z);   

      
    }

    // Update is called once per frame
    void Update()
    {
        transform.LookAt(player.transform); 


        switch (MovementType)
        {
            case 3:
                break;
            case 2:
                EnemyMove();
                break;
            case 1:
                break;
            default:
                break;
        }

    }


    private void EnemyMove()
    {
        GetComponent<NavMeshAgent>().Move(transform.forward * Time.deltaTime);

    }


}
