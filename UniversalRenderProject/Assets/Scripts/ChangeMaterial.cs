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
        playerMat.gameObject.GetComponent<Renderer>().material = materialBase;
    }

    void Update()
    {
        //turn on menu
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

    public void ChangeMat()
    {
        //change the material based on num and resets
        materialNum++;

    }
    public void TurnOff()
    {
        //turn off the menu
        Time.timeScale = 1;
        player.GetComponent<InputManagerTPS>().cursorLocked = true;
        player.GetComponent<InputManagerTPS>().cursorInputLook = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    public void FlameOn()
    {
        //Turn the particle flame off or on
        if (m_fire.gameObject.activeSelf)
        {
            m_fire.gameObject.SetActive(false);
            return;
        }
        if (!m_fire.gameObject.activeSelf)
        {
            m_fire.gameObject.SetActive(true);
            return;
        }
    }

    public void Quit()
    {
        Application.Quit();
    }
}
