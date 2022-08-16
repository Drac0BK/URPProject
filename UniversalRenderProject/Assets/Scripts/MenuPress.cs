using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuPress : MonoBehaviour
{
    public GameObject player;
    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            player.GetComponent<InputManagerTPS>().cursorLocked = false;
        }
    }
}
