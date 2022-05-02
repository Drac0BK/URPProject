using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class ChangeMaterial : MonoBehaviour
{

    int materialNum = 0;
    public Material materialRim;
    public Material materialInvis;
    public Material materialBase;
    public GameObject playerMat;
    public GameObject player;
    public GameObject menu;
    bool cursorLock = false;
    public ParticleSystem m_fire;

    private void Start()
    {
        
    }

    void Update()
    {
        if(Keyboard.current.qKey.wasPressedThisFrame)
        {
            menu.SetActive(true);
            player.GetComponent<InputManagerTPS>().cursorLocked = false;
            Cursor.lockState = CursorLockMode.None;
        }


        if (materialNum == 2) playerMat.gameObject.GetComponent<Renderer>().material = materialRim;

        if (materialNum == 1) playerMat.gameObject.GetComponent<Renderer>().material = materialInvis;

        if (materialNum == 0) playerMat.gameObject.GetComponent<Renderer>().material = materialBase;

        if (materialNum == 3) materialNum = 0;

    }

    public void addNum()
    {
        materialNum++;
    }
    public void turnOn()
    {
        player.GetComponent<InputManagerTPS>().cursorLocked = true;
        Cursor.lockState = CursorLockMode.Locked;
    }

    public void flameOn()
    {
        if (m_fire.isEmitting)
        {
            m_fire.Stop();
            return;
        }
        if (!m_fire.isEmitting)
        {
            m_fire.Play();
            return;
        }
    }
}
