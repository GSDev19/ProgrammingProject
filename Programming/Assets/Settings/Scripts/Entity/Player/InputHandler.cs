using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputHandler : MovementController
{
    public Vector2 MovementInput { get; private set; }

    public void OnMoveInput(InputAction.CallbackContext context)
    {
        MovementInput = context.ReadValue<Vector2>();
        NormX = (int)(MovementInput * Vector2.right).normalized.x;
        NormY = (int)(MovementInput * Vector2.up).normalized.y;

    }
}
