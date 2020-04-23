using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MMDoor : MonoBehaviour
{

    public Image MiniMapUI;
    public GameObject Wall;

    // Start is called before the first frame update
    void Start()
    {
        MiniMapUI = GetComponent<Image>();
        MiniMapUI.color = Color.yellow;
        //MiniMapUI.color = Color.green;
        //MiniMapUI.color = Color.red;
        if(Wall.activeSelf == true)
        {
            gameObject.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            MiniMapUI.color = Color.green;
        }
    }
}
