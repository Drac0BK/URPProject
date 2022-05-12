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
    public Material materialLine;

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
        if(Keyboard.current.escapeKey.wasPressedThisFrame)
        {
            menu.SetActive(true);
            player.GetComponent<InputManagerTPS>().cursorLocked = false;
            player.GetComponent<InputManagerTPS>().cursorInputLook = true;
            Cursor.lockState = CursorLockMode.None;
            Time.timeScale = 0;
        }


        if (materialNum == 3) playerMat.gameObject.GetComponent<Renderer>().material = materialRim;

        if (materialNum == 2) playerMat.gameObject.GetComponent<Renderer>().material = materialLine;

        if (materialNum == 1) playerMat.gameObject.GetComponent<Renderer>().material = materialInvis;

        if (materialNum == 0) playerMat.gameObject.GetComponent<Renderer>().material = materialBase;

        if (materialNum == 4) materialNum = 0;

    }

    public void addNum()
    {
        materialNum++;
    }
    public void turnOn()
    {
        Time.timeScale = 1;
        player.GetComponent<InputManagerTPS>().cursorLocked = true;
        player.GetComponent<InputManagerTPS>().cursorInputLook = false;
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

    public void Quit()
    {
        Application.Quit();
    }
}
