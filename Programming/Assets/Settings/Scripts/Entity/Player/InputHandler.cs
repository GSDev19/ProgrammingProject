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
}
