using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class JR_EnemyMovement : MonoBehaviour
{
    public int MovementType; 
    private NavMeshAgent navAgent;

    private GameObject player;
    public float distance;
    public float Speed;
    public GameObject target;
    private Vector3 playerVec;

    private GameObject[] _points;

    private int ranNum;

    public float MoveTimer;

    private float point_distance; 

    // Start is called before the first frame update
    void Start()
    {
        navAgent = gameObject.GetComponent<NavMeshAgent>();
        player = GameObject.FindGameObjectWithTag("Player");
        playerVec = new Vector3(player.transform.position.x, 0, player.transform.position.z);

        _points = GameObject.FindGameObjectsWithTag("Point");
        ranNum = Random.RandomRange(0, 15);

        target = _points[ranNum];  
    }

    // Update is called once per frame
    void Update()
    {
        MoveTimer -= Time.deltaTime; 
       

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
        point_distance = Vector3.Distance(gameObject.transform.position, target.transform.position);


        if (point_distance > 1)
        {
            transform.Translate(Vector3.forward * Time.deltaTime * Speed);
            EnemyLookAt();

        }
        if (MoveTimer <= 0)
        {
            PickPoint();
        }
    }

    private void PickPoint()
    {
        
            ranNum = Random.RandomRange(0, 15);

            target = _points[ranNum];

            MoveTimer = Random.Range(6, 10);
        
    }


    private void EnemyLookAt()
    {
        
            transform.LookAt(target.transform.position);
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Enemy")
        {
            PickPoint(); 
        }
    }


}
