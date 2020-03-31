using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomManager : MonoBehaviour
{

    public GameObject Door, Door2, Door3, Door4;
    public enum State { DisableNothing ,DisableDoor, DisableDoor2, DisableDoor3, DisableDoor4 }

    public State RoomState;

    // Start is called before the first frame update
    void Start()
    {
        switch (RoomState)
        {
            case State.DisableDoor:
                Door.SetActive(false);
                break;
            case State.DisableDoor2:
                Door2.SetActive(false);
                break;
            case State.DisableDoor3:
                Door3.SetActive(false);
                break;
            case State.DisableDoor4:
                Door4.SetActive(false);
                break;

        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
