using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{

    public Transform player;
    public float AttackRange;
    public float distance;
    public float speed;
    Vector3 smoothpos;
    Animator anim;


    public enum State { move, attack }

    public State EnemyState;

    // Start is called before the first frame update
    void Start()
    {
        smoothpos = transform.position;
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void LateUpdate()
    {
        transform.LookAt(player);
        distance = Vector3.Distance(transform.position, player.position);

        if (EnemyState == State.move)
        {
            if (distance > AttackRange)
            {
                if (!anim.GetCurrentAnimatorStateInfo(0).IsName("attack3"))
                {
                    transform.Translate(Vector3.forward * speed * Time.deltaTime);
                }
                anim.SetBool("isWalking", true);
            }
            else
            {
                
                EnemyState = State.attack;
            }
        }
        else if(EnemyState == State.attack)
        {
            if(distance > AttackRange)
            {
                
                EnemyState = State.move;
                anim.SetBool("Attack", false);
            }
            else
            {
                anim.SetBool("isWalking", false);
                anim.SetBool("Attack", true);
            }
        }
    }
    
}
