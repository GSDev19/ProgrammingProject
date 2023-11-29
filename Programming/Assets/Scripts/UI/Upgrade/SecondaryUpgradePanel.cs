using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SecondaryUpgradePanel : MonoBehaviour
{
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
    }


    public void UpgradeDamage()
    {
        currentSecondaryData.damageStat.currentValue += currentSecondaryData.damageStat.incrementAmount;
        currentSecondaryData.damageStat.timesIncremented++;
        UpdateValues();
    }
    public void UpgradeCooldown()
    {
        currentSecondaryData.cooldownStat.currentValue -= currentSecondaryData.cooldownStat.currentValue * currentSecondaryData.cooldownStat.incrementPercentaje;
        currentSecondaryData.cooldownStat.timesIncremented++;
        UpdateValues();
    }
    public void UpgradeAreaSize()
    {
        currentSecondaryData.areaSizeStat.currentValue += currentSecondaryData.areaSizeStat.currentValue * currentSecondaryData.areaSizeStat.incrementPercentaje;
        currentSecondaryData.areaSizeStat.timesIncremented++;
        UpdateValues();
    }
    public void UpgradeDuration()
    {
        currentSecondaryData.durationStat.currentValue += currentSecondaryData.durationStat.currentValue * currentSecondaryData.durationStat.incrementPercentaje;
        currentSecondaryData.durationStat.timesIncremented++;
        UpdateValues();
    }
    public void UpgradeHitsXSecond()
    {
        currentSecondaryData.hitsXSecondStat.currentValue += currentSecondaryData.hitsXSecondStat.incrementAmount;
        currentSecondaryData.hitsXSecondStat.timesIncremented++;
        UpdateValues();
    }
}
