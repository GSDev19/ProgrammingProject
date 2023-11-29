using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SecondaryUpgradePanel : MonoBehaviour
{
    public List<Button> upgradeButtons = new List<Button>();

    public TextMeshProUGUI damageText;
    public TextMeshProUGUI cooldownText;
    public TextMeshProUGUI areaSizeText;
    public TextMeshProUGUI durationText;
    public TextMeshProUGUI hitsText;

    public Image secondaryImage;

    public SecondaryData currentSecondaryData;

    public void Set(Element element, SecondaryData data)
    {
        this.currentSecondaryData = data;

        secondaryImage.sprite = GameData.Instance.GetElementSprite(element);

        UpdateValues();

    }
    public void UpdateValues()
    {
        damageText.text = currentSecondaryData.damageStat.currentValue.ToString();
        cooldownText.text = currentSecondaryData.cooldownStat.currentValue.ToString();
        areaSizeText.text = currentSecondaryData.areaSizeStat.currentValue.ToString();
        durationText.text = currentSecondaryData.durationStat.currentValue.ToString();
        hitsText.text = currentSecondaryData.hitsXSecondStat.currentValue.ToString();

        CheckIfEnoughPoints();
    }


    public void UpgradeDamage()
    {
        if (PlayerController.Instance.Core.Experience)
        {
            currentSecondaryData.damageStat.currentValue += currentSecondaryData.damageStat.incrementAmount;
            currentSecondaryData.damageStat.timesIncremented++;
            PlayerController.Instance.Core.Experience.ExpendPoint();
            UpdateValues();
        }

    }
    public void UpgradeCooldown()
    {
        if (PlayerController.Instance.Core.Experience)
        {
            currentSecondaryData.cooldownStat.currentValue -= currentSecondaryData.cooldownStat.currentValue * currentSecondaryData.cooldownStat.incrementPercentaje;
            currentSecondaryData.cooldownStat.timesIncremented++;
            PlayerController.Instance.Core.Experience.ExpendPoint();
            UpdateValues();
        }

    }
    public void UpgradeAreaSize()
    {
        if (PlayerController.Instance.Core.Experience)
        {
            currentSecondaryData.areaSizeStat.currentValue += currentSecondaryData.areaSizeStat.currentValue * currentSecondaryData.areaSizeStat.incrementPercentaje;
            currentSecondaryData.areaSizeStat.timesIncremented++;
            PlayerController.Instance.Core.Experience.ExpendPoint();
            UpdateValues();
        }

    }
    public void UpgradeDuration()
    {
        if (PlayerController.Instance.Core.Experience)
        {
            currentSecondaryData.durationStat.currentValue += currentSecondaryData.durationStat.currentValue * currentSecondaryData.durationStat.incrementPercentaje;
            currentSecondaryData.durationStat.timesIncremented++;
            PlayerController.Instance.Core.Experience.ExpendPoint();
            UpdateValues();
        }

    }
    public void UpgradeHitsXSecond()
    {
        if (PlayerController.Instance.Core.Experience)
        {
            currentSecondaryData.hitsXSecondStat.currentValue += currentSecondaryData.hitsXSecondStat.incrementAmount;
            currentSecondaryData.hitsXSecondStat.timesIncremented++;
            PlayerController.Instance.Core.Experience.ExpendPoint();
            UpdateValues();
        }

    }

    private void CheckIfEnoughPoints()
    {
        if (PlayerController.Instance.Core.Experience.currentPoints > 0)
        {
            foreach (Button button in upgradeButtons)
            {
                button.enabled = true;
            }
        }
        else
        {
            foreach (Button button in upgradeButtons)
            {
                button.enabled = false;
            }
        }
    }
}
