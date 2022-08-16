using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputManagerTPS : MonoBehaviour
{
    // TPS inputs
    public Vector2 move;
    public Vector2 look;
    public bool jump;
    public bool aim;
    public bool shoot;
    public bool run;
    public bool keypress;
    public bool menu = false;

    public bool movement;

    // mouse lockers
    public bool cursorLocked = true;
    public bool cursorInputLook = false;

    #region Functions We Call On Button Press

    public void MenuInput(bool a_menuState)
    {
        menu = a_menuState;
    }

    public void MoveInput(Vector2 a_moveDir)
    {
        move = a_moveDir;

    }

    public void LookInput(Vector2 a_lookDirection)
    {
        look = a_lookDirection;

    }

    public void AimInput(bool a_aimState)
    {
        aim = a_aimState;
    }
    public void JumpInput(bool a_jumpState)
    {
        jump = a_jumpState;
    }
    public void ShootInput(bool a_shootState)
    {
        shoot = a_shootState;
    }
    public void RunInput(bool a_runState)
    {
        run = a_runState;
    }

    public void MovementInput(bool a_moveState)
    {
        movement = a_moveState;
    }

    public void KeyboardInput(bool a_keypress)
    {
        keypress = a_keypress;
    }

    #endregion

    ////////////////////////////////////////////////////////////////////////

    #region Functions created for connecting to unity input system
    public void OnMove(InputValue a_value)
    {
        MoveInput(a_value.Get<Vector2>());
    }

    public void OnLook(InputValue a_value)
    {
        if (cursorLocked)
            LookInput(a_value.Get<Vector2>());
    }

    public void OnAim(InputValue a_value)
    {
        AimInput(a_value.isPressed);
    }
    public void OnJump(InputValue a_value)
    {
        JumpInput(a_value.isPressed);
    }
    public void OnRun(InputValue a_value)
    {
        RunInput(a_value.isPressed);
    }
    public void OnShoot(InputValue a_value)
    {
        ShootInput(a_value.isPressed);
    }
    public void onMenu(InputValue a_value)
    {
        MenuInput(a_value.isPressed);
    }
    public void OnPress(InputValue a_value)
    {
        KeyboardInput(a_value.isPressed);
    }

    #endregion

    private void OnApplicationFocus(bool focus)
    {
        SetCursorState(cursorLocked);
    }

    private void SetCursorState(bool a_static)
    {
        Cursor.lockState = a_static ? CursorLockMode.Locked : CursorLockMode.None;
    }
}