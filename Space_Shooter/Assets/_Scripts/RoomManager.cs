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

    RoomTemplates templates;
    int rand;
    bool spawned = false;

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
        if (!RoomTemplates.spawned)
        {
            if (openingDirection == 1)
            {
                //spawn room with bottom door
                rand = Random.Range(0, templates.bottomRooms.Length);
                Instantiate(templates.bottomRooms[rand], transform.position, templates.bottomRooms[rand].transform.rotation);
            }
            else if (openingDirection == 2)
            {
                //spawn room with top door
                rand = Random.Range(0, templates.topRooms.Length);
                Instantiate(templates.topRooms[rand], transform.position, templates.topRooms[rand].transform.rotation);
            }
            else if (openingDirection == 3)
            {
                //spawn room with left door
                rand = Random.Range(0, templates.leftRooms.Length);
                Instantiate(templates.leftRooms[rand], transform.position, templates.leftRooms[rand].transform.rotation);
            }
            else if (openingDirection == 4)
            {
                //spawn room with right door
                rand = Random.Range(0, templates.rightRooms.Length);
                Instantiate(templates.rightRooms[rand], transform.position, templates.rightRooms[rand].transform.rotation);
            }
            gameObject.SetActive(false);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("SpawnPoint"))
        {
            //if (other.gameObject.name != "Destroyer")
            //{
            //    if (other.GetComponent<RoomManager>().spawned == false && spawned == false)
            //    {
            //        //spawn walls blocking off and openings

            //        Instantiate(templates.closedRoom, transform.position, templates.closedRoom.transform.rotation);
            //        Destroy(gameObject);

            //    }
            //}
            //else
            //{
            //    StopAllCoroutines();
            //    Destroy(gameObject);
            //}
            //spawned = true;
        }
        if (other.CompareTag("EnterRoom"))
        {
            StopAllCoroutines();
        }
    }

}
