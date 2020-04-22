using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomManager : MonoBehaviour
{

    public int openingDirection;
    //1 = need bottom door
    //2 = need top door
    //3 = need left door
    //4 = need right door
    bool spawned;
    RoomTemplates templates;
    int rand;
    public GameObject DeadEnd;
    public float waitTime = 4;

    private void Start()
    {
        //Destroy(gameObject, waitTime);
        templates = GameObject.FindGameObjectWithTag("Rooms").GetComponent<RoomTemplates>();
        StartCoroutine(SpawnRooms());
    }


    private IEnumerator SpawnRooms()
    {
        yield return new WaitForSeconds(1);
        if (!spawned)
        {
            if (templates.rooms.Count < templates.RoomLimit)
            {
                if (openingDirection == 1)
                {
                    //spawn room with bottom door
                    rand = Random.Range(0, templates.bottomRooms.Length);
                    Instantiate(templates.bottomRooms[rand], transform.position, templates.bottomRooms[rand].transform.rotation);
                    spawned = true;
                }
                else if (openingDirection == 2)
                {
                    //spawn room with top door
                    rand = Random.Range(0, templates.topRooms.Length);
                    Instantiate(templates.topRooms[rand], transform.position, templates.topRooms[rand].transform.rotation);
                    spawned = true;
                }
                else if (openingDirection == 3)
                {
                    //spawn room with left door
                    rand = Random.Range(0, templates.leftRooms.Length);
                    Instantiate(templates.leftRooms[rand], transform.position, templates.leftRooms[rand].transform.rotation);
                    spawned = true;
                }
                else if (openingDirection == 4)
                {
                    //spawn room with right door
                    rand = Random.Range(0, templates.rightRooms.Length);
                    Instantiate(templates.rightRooms[rand], transform.position, templates.rightRooms[rand].transform.rotation);
                    spawned = true;
                }
            }
        }
        if (RoomTemplates.DoneSpawning)
        {
            DeadEnd.SetActive(true);
            StopAllCoroutines();
            gameObject.SetActive(false);
            templates.CheckList();
        }
        else
        {
            StartCoroutine(SpawnRooms());
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("EnterRoom"))
        {
            gameObject.SetActive(false);
        }
        if (other.CompareTag("EnterRoom") || other.CompareTag("SpawnPoint"))
        {
            spawned = true;
        }
    }
}
