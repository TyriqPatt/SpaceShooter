﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JR_EnemyLookAtPlayer : MonoBehaviour
{
    public Vector3 target;
    public GameObject player;


    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");

    }

    // Update is called once per frame
    void Update()
    {
        target = new Vector3(player.transform.position.x, gameObject.transform.position.y, player.transform.position.z);

        transform.LookAt(target);

    }
}
