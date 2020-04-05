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

    public List<GameObject> rooms;

    public float waitTime;
    bool spawnedBoss;
    GameObject Boss;

    private void Update()
    {
        if(waitTime <= 0 && !spawnedBoss)
        {
            for(int i = 0; i < rooms.Count; i++)
            {
                if(i == rooms.Count - 1)
                {
                    rooms[i].transform.GetChild(0).GetComponent<MeshRenderer>().material.color = Color.red;
                    //Instantiate(Boss, rooms[i].transform.position, Quaternion.identity);
                    spawnedBoss = true;
                }
            }
        }
        else
        {
            waitTime -= Time.deltaTime;
        }
    }
}
