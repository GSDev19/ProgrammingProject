using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using static UnityEditor.Rendering.FilterWindow;

public class ReferenceButton : MonoBehaviour
{
    private Image image;
    [SerializeField] private Element buttonElement;
    public AttackActionType actionType;
    AttackComponent AttackComponent;
    PrimaryData primaryData;
    SecondaryData secondaryData;

    private void Awake()
    {
        image = GetComponent<Image>();
    }
    private void Start()
    {
        AttackComponent = PlayerController.Instance.Core.Attack;
    }
    public void Initialize(Element element, AttackActionType actionType)
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
