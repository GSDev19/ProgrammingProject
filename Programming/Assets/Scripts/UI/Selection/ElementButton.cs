using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ElementButton : MonoBehaviour
{
    private Image image;
    [SerializeField] private Element buttonElement;
    public AttackActionType actionType;
    AttackComponent AttackComponent;

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
            AttackComponent.SetPrimaryData(buttonElement);
        }
        else if(actionType == AttackActionType.Secondary)
        {
            AttackComponent.SetSecondaryData(buttonElement);
        }
    }
}

