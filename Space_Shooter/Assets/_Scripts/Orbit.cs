using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Orbit : MonoBehaviour
{

    public Transform Target;
    public float speed;
    public float TimeTilSwitch;
    public bool pingpong;

    // Start is called before the first frame update
    void Start()
    {
        if (pingpong)
        {
            StartCoroutine(reverse(TimeTilSwitch));
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (pingpong)
        {
            transform.RotateAround(Target.position, Vector3.down, speed);
        }
        else
        {
            transform.RotateAround(Target.position, Vector3.down, speed);
        }
    }

    IEnumerator reverse(float time)
    {
        yield return new WaitForSeconds(time);
        speed = -speed;
        StartCoroutine(reverse(TimeTilSwitch + .3f));
    }
}
