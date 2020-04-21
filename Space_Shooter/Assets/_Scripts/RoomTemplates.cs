using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomTemplates : MonoBehaviour
{

    public GameObject[] bottomRooms;
    public GameObject[] topRooms;
    public GameObject[] leftRooms;
    public GameObject[] rightRooms;

    public GameObject closedRoom;
    public float RoomLimit;
    public List<GameObject> rooms;

    
    bool spawnedBoss;
    GameObject Boss;
    public static bool DoneSpawning;

    private void Start()
    {
        int rand = Random.Range(0, 4);
        if(rand == 0)
        {
            int rand2 = Random.Range(0, bottomRooms.Length);
            Instantiate(bottomRooms[rand2], Vector3.zero, bottomRooms[rand2].transform.rotation);
        }
        else if (rand == 1)
        {
            int rand2 = Random.Range(0, topRooms.Length);
            Instantiate(topRooms[rand2], Vector3.zero, topRooms[rand2].transform.rotation);
        }
        else if (rand == 2)
        {
            int rand2 = Random.Range(0, rightRooms.Length);
            Instantiate(rightRooms[rand2], Vector3.zero, rightRooms[rand2].transform.rotation);
        }
        else if (rand == 3)
        {
            int rand2 = Random.Range(0, leftRooms.Length);
            Instantiate(leftRooms[rand2], Vector3.zero, leftRooms[rand2].transform.rotation);
        }
    }

    private void Update()
    {
        if (!DoneSpawning)
        {
            if (rooms.Count >= RoomLimit)
            {
                DoneSpawning = true;
            }
        }
    }
}
