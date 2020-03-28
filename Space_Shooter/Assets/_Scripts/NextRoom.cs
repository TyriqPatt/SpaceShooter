using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NextRoom : MonoBehaviour
{

    public GameObject[] Rooms;
    public Transform Spawn;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        int ranNum = Random.Range(0, Rooms.Length);
        Instantiate(Rooms[ranNum], Spawn.position, transform.rotation);
    }
}
