using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpgradesHandler : MonoBehaviour
{
    [Header("LEFT PANEL")]
    public GameObject buttonPrefab;
    [SerializeField] private Transform primaryButtonsParent;
    [SerializeField] private Transform secondaryButtonsParent;
    [Header("RIGHT PANEL")]
    [Header("Primary")]
    public CanvasGroup primaryCanvasGroup;
    [SerializeField] private PrimaryUpgradePanel primaryUpgradePanel;

    [Header("Secondary")]
    public CanvasGroup secondaryCanvasGroup;
    [SerializeField] private SecondaryUpgradePanel secondaryUpgradePanel;

    [Header("Player")]
    public CanvasGroup playerCanvasGroup;
    [SerializeField] private PlayerUpgradePanel playerUpgradePanel;

    private void Start()
    {
        CreateButtons();
    }
    public void CreateButtons()
    {
        ClearChildObjects(primaryButtonsParent);
        ClearChildObjects(secondaryButtonsParent);
        foreach (Element element in GameManager.Instance.unlockedElements.Keys)
        {
            if (GameManager.Instance.unlockedElements[element] == true)
            {
                GameObject primaryButton = Instantiate(buttonPrefab, primaryButtonsParent);
                primaryButton.GetComponent<ReferenceButton>().InitializeForAttack(element, AttackActionType.Primary);

                GameObject secondaryButton = Instantiate(buttonPrefab, secondaryButtonsParent);
                secondaryButton.GetComponent<ReferenceButton>().InitializeForAttack(element, AttackActionType.Secondary);
            }
        }
    }
    public void ClearChildObjects(Transform parent)
    {
        foreach (Transform child in parent)
        {
            Destroy(child.gameObject);
        }
    }

    public void SetPrimaryUpgradeData(Element element, PrimaryData primaryData)
    {
        UIHelpers.SetCanvasGroup(primaryCanvasGroup, true);
        UIHelpers.SetCanvasGroup(secondaryCanvasGroup, false);
        UIHelpers.SetCanvasGroup(playerCanvasGroup, false);

        primaryUpgradePanel.Set(element, primaryData);
    }
    public void SetSecondaryUpgradeData(Element element, SecondaryData data)
    {
        UIHelpers.SetCanvasGroup(primaryCanvasGroup, false);
        UIHelpers.SetCanvasGroup(secondaryCanvasGroup, true);
        UIHelpers.SetCanvasGroup(playerCanvasGroup, false);

        secondaryUpgradePanel.Set(element, data);
    }
    public void SetPlayerUpgradeData(PlayerStats stat)
    {
        UIHelpers.SetCanvasGroup(primaryCanvasGroup, false);
        UIHelpers.SetCanvasGroup(secondaryCanvasGroup, false);
        UIHelpers.SetCanvasGroup(playerCanvasGroup, true);

        playerUpgradePanel.Set(stat);
    }
    public void SetNoneUpgradeData()
    {
        UIHelpers.SetCanvasGroup(primaryCanvasGroup, false);
        UIHelpers.SetCanvasGroup(secondaryCanvasGroup, false);
        UIHelpers.SetCanvasGroup(playerCanvasGroup, false);
    }
}
