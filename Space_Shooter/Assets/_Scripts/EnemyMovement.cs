using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{

    public Transform player;
    public float distance;
    public float speed;
    Vector3 smoothpos;


    public enum State { move, attack }

    public State EnemyState;

    // Start is called before the first frame update
    void Start()
    {
        smoothpos = transform.parent.position;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        transform.parent.LookAt(player);
        distance = Vector3.Distance(transform.position, player.position);
        if(distance > 5)
        {
            transform.parent.Translate(Vector3.forward * speed * Time.deltaTime);
            //transform.parent.position = smoothpos;
            //smoothpos = Vector3.Lerp(transform.parent.transform.position, player.transform.position, speed * Time.deltaTime);
        }
    }
}
