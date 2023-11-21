using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputHandler : MonoBehaviour
{
    public static InputHandler Instance { get; private set; }
    public Vector2 MovementInput { get; private set; }
    public int NormX { get; private set; }
    public int NormY { get; private set; }

    public bool PrimaryAttackInput { get; private set; }
    public bool SecondaryAttackInput { get; private set; }

    private void Awake()
    {
        if (!Instance)
        {
            Instance = this;
        }
        else if (Instance != this)
        {
            Destroy(this.gameObject);
        }
    }
    public void OnMoveInput(InputAction.CallbackContext context)
    {
        MovementInput = context.ReadValue<Vector2>();
        NormX = (int)(MovementInput * Vector2.right).normalized.x;
        NormY = (int)(MovementInput * Vector2.up).normalized.y;
    }

    public void OnPrimaryAttackInput(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            PrimaryAttackInput = true;
        }
        if (context.canceled)
        {
            PrimaryAttackInput = false;
        }
    }
    public void OnSecondaryAttackInput(InputAction.CallbackContext context)
    {
        if(context.started)
        {
            SecondaryAttackInput = true;
        }
        if(context.canceled)
        {
            SecondaryAttackInput = false;
        }
    }
}
