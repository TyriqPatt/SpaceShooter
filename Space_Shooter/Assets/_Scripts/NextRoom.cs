using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NextRoom : MonoBehaviour
{

    public GameObject[] Rooms;
    public Transform Spawn;
    public float DoorNum;


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
        if(other.transform.tag == "Player")
        {
            int ranNum = Random.Range(0, Rooms.Length);
            GameObject _nextRoom;
            _nextRoom = Instantiate(Rooms[ranNum], Spawn.position, Spawn.rotation);
            if(DoorNum == 1)
            {
                _nextRoom.GetComponent<RoomManager>().RoomState = RoomManager.State.DisableDoor4;
            }
            else if (DoorNum == 2)
            {
                _nextRoom.GetComponent<RoomManager>().RoomState = RoomManager.State.DisableDoor3;
            }
            else if (DoorNum == 3)
            {
                _nextRoom.GetComponent<RoomManager>().RoomState = RoomManager.State.DisableDoor2;
            }
            else if (DoorNum == 4)
            {
                _nextRoom.GetComponent<RoomManager>().RoomState = RoomManager.State.DisableDoor;
            }
            
            gameObject.SetActive(false);
        }
    }
}
