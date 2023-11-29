using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStatReferenceButton : MonoBehaviour
{
    public PlayerStats playerStat;

    public void OnButtonClick()
    {
        Debug.Log(playerStat);
        UIController.Instance.upgradeHandler.SetPlayerUpgradeData(playerStat);
    }
}
