using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackSelectionHandler : MonoBehaviour
{
    public GameObject buttonPrefab;
    [SerializeField] private Transform primaryButtonsParent;
    [SerializeField] private Transform secondaryButtonsParent;

    public void CreateButtons()
    {
        ClearChildObjects(primaryButtonsParent);
        ClearChildObjects(secondaryButtonsParent);
        foreach (Element element in GameManager.Instance.unlockedElements.Keys)
        {
            if (GameManager.Instance.unlockedElements[element] == true)
            {
                GameObject primaryButton = Instantiate(buttonPrefab, primaryButtonsParent);
                primaryButton.GetComponent<ElementButton>().Initialize(element, AttackActionType.Primary);

                GameObject secondaryButton = Instantiate(buttonPrefab, secondaryButtonsParent);
                secondaryButton.GetComponent<ElementButton>().Initialize(element, AttackActionType.Secondary);
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
}
