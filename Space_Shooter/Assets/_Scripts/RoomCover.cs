using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomCover : MonoBehaviour
{

    public GameObject[] Cover;
    public int rand;
    public int scasca;
    // Start is called before the first frame update
    void Start()
    {
        scasca = Cover.Length;
        rand = Random.Range(0, 10);
        if(rand < Cover.Length - 1)
        {
            Instantiate(Cover[rand], transform.position, transform.rotation);
        }
        else if (rand >= Cover.Length)
        {
            
        } 
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
