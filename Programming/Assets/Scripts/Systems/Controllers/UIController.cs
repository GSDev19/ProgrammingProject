using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    public static UIController Instance;
    [Header("Attack Selection")]
    public AttackSelectionHandler attacksHandler;
    public CanvasGroup attackSelectionCanvasGroup;
    public bool isAttackSelectionOpen = false;
    [Space]
    [Header("Attack Upgrade")]
    public AttackUpgradeHandler upgradeHandler;
    public CanvasGroup attackUpgradeCanvasGroup;
    public bool isAttackUpgradeOpen = false;
    [Space]
    [Header("Attack Cooldowns")]
    public Image primaryCooldownSprite;
    public Image primaryBlocker;
    [Space]
    public Image secondaryCooldownSprite;
    public Image secondaryBlocker;
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
    private void Start()
    {
        isAttackSelectionOpen = false;
        ShowAttackSelectionPanel(false);
        ShowAttackUpgradePanel(false);
    }

    #region Attack Selection 

    public void ShowAttackSelectionPanel(bool value)
    {
        isAttackSelectionOpen = value;

        if (isAttackSelectionOpen == true)
        {
            attacksHandler.CreateButtons();
            Time.timeScale = 0f;
            
        }
        else
        {
            Time.timeScale = 1f;
        }
        UIHelpers.SetCanvasGroup(attackSelectionCanvasGroup, isAttackSelectionOpen);
    }
    public void ShowAttackUpgradePanel(bool value)
    {
        isAttackUpgradeOpen = value;

        if (isAttackUpgradeOpen == true)
        {
            upgradeHandler.CreateButtons();
            Time.timeScale = 0f;

        }
        else
        {
            Time.timeScale = 1f;
        }
        UIHelpers.SetCanvasGroup(attackUpgradeCanvasGroup, isAttackUpgradeOpen);
    }
    #endregion

    #region Attack Icons
    public void SetPrimaryBlockerValue(float currentValue, float maxValue )
    {
        float percentaje = currentValue / maxValue;

        primaryBlocker.fillAmount = 1 - percentaje;
    }
    public void SetSecondaryBlockerValue(float currentValue, float maxValue)
    {
        float percentaje = currentValue / maxValue;

        secondaryBlocker.fillAmount = 1 - percentaje;
    }
    
    public void ChangePrimarySprite(Sprite sprite)
    {
        primaryCooldownSprite.sprite = sprite;
    }
    public void ChangeSecondarySprite(Sprite sprite)
    {
        secondaryCooldownSprite.sprite = sprite;
    }
    #endregion

}
