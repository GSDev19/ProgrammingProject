using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Utilities;

public class PlayerUpgradePanel : MonoBehaviour
{
    public UDictionary<PlayerStats, GameObject> statsGameObjects = new UDictionary<PlayerStats, GameObject>();
    public List<Button> upgradeButtons = new List<Button>();

    [Header("LEVEL ELEMENTS")]
    public TextMeshProUGUI healthLevelText;
    public TextMeshProUGUI recoveryLevelText;
    public TextMeshProUGUI armorLevelText;
    public TextMeshProUGUI speedLevelText;
    public TextMeshProUGUI luckLevelText;

    public Image healthBar;
    public Image recoveryBar;
    public Image armorBar;
    public Image speedBar;
    public Image luckBar;

    [Space]
    [Header("INCREMENT TEXTS")]
    public TextMeshProUGUI healthIncrementText;
    public TextMeshProUGUI recoveryIncrementText;
    public TextMeshProUGUI armorIncrementText;
    public TextMeshProUGUI speedIncrementText;
    public TextMeshProUGUI luckIncrementText;

    public Image statImage;
    public PlayerData currentData;

    private void Start()
    {
        currentData = PlayerController.Instance.data;
    }
    public void Set(/*PlayerStats stat*/)
    {
        //SelectStat(stat);

        SetIncrementTexts();

        UpdateValues();
    }
    //private void SelectStat(PlayerStats selectedStat)
    //{
    //    Debug.Log(selectedStat);
    //    foreach (PlayerStats key in statsGameObjects.Keys)
    //    {
    //        if (key == selectedStat)
    //        {
    //            statsGameObjects[key].SetActive(true);
    //        }
    //        else
    //        {
    //            statsGameObjects[key].SetActive(false);
    //        }
    //    }
    //}

    private void UpdateValues()
    {
        healthLevelText.text = currentData.healthStat.level.ToString();
        recoveryLevelText.text = currentData.recoveryStat.level.ToString();
        armorLevelText.text = currentData.armorStat.level.ToString();
        speedLevelText.text = currentData.movementSpeedStat.level.ToString();
        luckLevelText.text = currentData.luckStat.level.ToString();

        SetStatBarFill(healthBar, currentData.healthStat.level);
        SetStatBarFill(recoveryBar, currentData.recoveryStat.level);
        SetStatBarFill(armorBar, currentData.armorStat.level);
        SetStatBarFill(speedBar, currentData.movementSpeedStat.level);
        SetStatBarFill(luckBar, currentData.luckStat.level);

        CheckIfEnoughPoints();
    }
    private void SetIncrementTexts()
    {
        healthIncrementText.text = "+ " + currentData.healthStat.incrementAmount.ToString();
        recoveryIncrementText.text = "- " + currentData.recoveryStat.incrementAmount.ToString();
        armorIncrementText.text = "+ " + currentData.armorStat.incrementAmount.ToString();
        speedIncrementText.text = "+ " + currentData.movementSpeedStat.incrementAmount.ToString() + "%";
        luckIncrementText.text = "+ " + currentData.luckStat.incrementAmount.ToString() + "%";
    }
    private void SetStatBarFill(Image image, int currentLevel)
    {
        image.fillAmount = (float)currentLevel / 10;
    }
    private void CheckIfEnoughPoints()
    {
        if (PlayerController.Instance.Core.Experience.currentPoints > 0)
        {
            foreach (Button button in upgradeButtons)
            {
                button.interactable = true;
            }
        }
        else
        {
            foreach (Button button in upgradeButtons)
            {
                button.interactable = false;
            }
        }
    }
    public void OnHealthUpgrade()
    {
        if(PlayerController.Instance.Core.Experience.currentPoints > 0)
        {
            currentData.healthStat.currentValue += currentData.healthStat.incrementAmount;
            currentData.healthStat.level++;
            PlayerController.Instance.Core.Experience.ExpendPoint();
            UpdateValues();
        }
    }
    public void OnRecoveryUpgrade()
    {
        if (PlayerController.Instance.Core.Experience.currentPoints > 0)
        {
            currentData.recoveryStat.currentValue += currentData.recoveryStat.incrementAmount;
            currentData.recoveryStat.level++;
            PlayerController.Instance.Core.Experience.ExpendPoint();
            UpdateValues();
        }
    }
    public void OnArmorUpgrade()
    {
        if (PlayerController.Instance.Core.Experience.currentPoints > 0)
        {
            currentData.armorStat.currentValue += currentData.armorStat.incrementAmount;
            currentData.armorStat.level++;
            PlayerController.Instance.Core.Experience.ExpendPoint();
            UpdateValues();
        }
    }
    public void OnSpeedUpgrade()
    {
        if (PlayerController.Instance.Core.Experience.currentPoints > 0)
        {
            currentData.movementSpeedStat.currentValue += currentData.movementSpeedStat.incrementAmount / 100;
            currentData.movementSpeedStat.level++;
            PlayerController.Instance.Core.Experience.ExpendPoint();
            UpdateValues();
        }
    }
    public void OnLuckUpgrade()
    {
        if (PlayerController.Instance.Core.Experience.currentPoints > 0)
        {
            currentData.luckStat.currentValue += currentData.luckStat.incrementAmount /100 ;
            currentData.luckStat.level++;
            PlayerController.Instance.Core.Experience.ExpendPoint();
            UpdateValues();
        }
    }
}
public enum PlayerStats
{
    Health,
    Recovery,
    Armor,
    Speed,
    Luck
}
