using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;

public class InputHandler : MonoBehaviour
{
    public static InputHandler Instance { get; private set; }
    public Vector2 MovementInput { get; private set; }
    public int NormX { get; private set; }
    public int NormY { get; private set; }

    public bool PrimaryAttackInput { get; private set; }
    public bool SecondaryAttackInput { get; private set; }
    public bool AttackSelectionInput { get; private set; }
    public bool AttackUpgradeInput { get; private set; }
    public bool isPointerOnUi { get; private set; }
    public bool PauseInput { get; private set; }

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
    private void Update()
    {
        isPointerOnUi = IsPointerOverUI();
    }
    public void OnMoveInput(InputAction.CallbackContext context)
    {
        if (CheckIfCanPerformAttack() == false)
        {
            NormX = 0;
            NormY = 0;
            return;
        }

        MovementInput = context.ReadValue<Vector2>();
        NormX = (int)(MovementInput * Vector2.right).normalized.x;
        NormY = (int)(MovementInput * Vector2.up).normalized.y;
    }

    public void OnPrimaryAttackInput(InputAction.CallbackContext context)
    {
        if(CheckIfCanPerformAttack() == false)
        {
            return;
        }
        if (context.started && isPointerOnUi == false)
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
        if (CheckIfCanPerformAttack() == false)
        {
            return;
        }

        if (context.started && isPointerOnUi == false)
        {
            SecondaryAttackInput = true;
        }
        if(context.canceled)
        {
            SecondaryAttackInput = false;
        }
    }   
    public void OnPauseInput(InputAction.CallbackContext context)
    {
        if(context.started)
        {
            PauseInput = true;

            if (UIController.Instance.pauseMenuOpen)
            {
                UIController.Instance.ShowPausePanel(false);
            }
            else
            {
                UIController.Instance.ShowPausePanel(true);
            }


        }
        if(context.canceled)
        {
            PauseInput = false;
        }
    }
    public void OnAttackSelectionInput(InputAction.CallbackContext context)
    {
        if(UIController.Instance.isAttackUpgradeOpen)
        {
            UIController.Instance.ShowAttackUpgradePanel(false);
        }
        if(context.started)
        {
            AttackSelectionInput = true;
            UIController.Instance.ShowAttackSelectionPanel(true);
        }

        if(context.canceled)
        {
            AttackSelectionInput = false;
            UIController.Instance.ShowAttackSelectionPanel(false);
        }
    }
    public void OnAttackUpgradeInput(InputAction.CallbackContext context)
    {
        if (UIController.Instance.isAttackSelectionOpen)
        {
            UIController.Instance.ShowAttackSelectionPanel(false);
        }
        if (context.started)
        {
            AttackUpgradeInput = true;
            if(UIController.Instance.isAttackUpgradeOpen)
            {
                UIController.Instance.ShowAttackUpgradePanel(false);
            }
            else
            {
                UIController.Instance.ShowAttackUpgradePanel(true);
            }
        }

        if (context.canceled)
        {
            AttackUpgradeInput = false;
            //UIController.Instance.ShowAttackUpgradePanel(false);
        }
    }
    private bool CheckIfCanPerformAttack()
    {
        if( UIController.Instance.isAttackSelectionOpen == true 
            || UIController.Instance.isAttackUpgradeOpen == true
            || UIController.Instance.pauseMenuOpen == true)
        {
            return false;
        }
        else
        {
            return true;
        }
    }
    private bool IsPointerOverUI()
    {
        return EventSystem.current.IsPointerOverGameObject();
    }
}
