using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using static UnityEditor.Rendering.FilterWindow;

public class ReferenceButton : MonoBehaviour
{
    public Image image;
    [SerializeField] private Element buttonElement;
    public AttackActionType actionType;
    PrimaryData primaryData;
    SecondaryData secondaryData;

    public void InitializeForAttack(Element element, AttackActionType actionType)
    {
        this.buttonElement = element;
        this.image.sprite = GameData.Instance.GetElementSprite(element);
        this.actionType = actionType;
    }
    public void OnButtonClick()
    {
        if(actionType == AttackActionType.Primary)
        {
            primaryData = GameData.Instance.GetPrimaryData(buttonElement);
            UIController.Instance.upgradeHandler.SetPrimaryUpgradeData(buttonElement, primaryData);
        }
        else if(actionType == AttackActionType.Secondary)
        {
            secondaryData = GameData.Instance.GetSecondaryData(buttonElement);
            UIController.Instance.upgradeHandler.SetSecondaryUpgradeData(buttonElement, secondaryData);
        }

    }
}
