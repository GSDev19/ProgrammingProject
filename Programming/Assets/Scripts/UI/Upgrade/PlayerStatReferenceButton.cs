using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStatReferenceButton : MonoBehaviour
{
    public void OnButtonClick()
    {
        UIController.Instance.upgradeHandler.SetPlayerUpgradeData();
    }
}
