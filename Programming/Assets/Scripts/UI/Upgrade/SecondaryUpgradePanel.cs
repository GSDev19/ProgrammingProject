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

    //public int damage;
    //public float cooldown;
    //public float areaSize;
    //public float duration;
    //public float hitsXSecond;

    public Image secondaryImage;

    public SecondaryData currentSecondaryData;

    public void Set(Element element, SecondaryData data)
    {
        this.currentSecondaryData = data;
        //this.damage = data.damage;
        //this.cooldown = data.cooldown;
        //this.areaSize = data.areaSize;
        //this.duration = data.duration;
        //this.hitsXSecond = data.hitsXSecond;

        secondaryImage.sprite = GameData.Instance.GetElementSprite(element);

        damageText.text = currentSecondaryData.damage.ToString();
        cooldownText.text = currentSecondaryData.cooldown.ToString();
        areaSizeText.text = currentSecondaryData.areaSize.ToString();
        durationText.text = currentSecondaryData.duration.ToString();
        hitsText.text = currentSecondaryData.hitsXSecond.ToString();

    }
    public void UpdateValues()
    {
        damageText.text = currentSecondaryData.damage.ToString();
        cooldownText.text = currentSecondaryData.cooldown.ToString();
        areaSizeText.text = currentSecondaryData.areaSize.ToString();
        durationText.text = currentSecondaryData.duration.ToString();
        hitsText.text = currentSecondaryData.hitsXSecond.ToString();
    }


    public void UpgradeDamage()
    {
        currentSecondaryData.damage += currentSecondaryData.damageUpgradeAmount;
        currentSecondaryData.damageUpgradeAmount++;
        UpdateValues();
    }
    public void UpgradeCooldown()
    {
        currentSecondaryData.cooldown -= currentSecondaryData.cooldown * currentSecondaryData.cooldownUpgradePercent;
        currentSecondaryData.cooldownUpgradedTimes++;
        UpdateValues();
    }
    public void UpgradeAreaSize()
    {
        currentSecondaryData.areaSize += currentSecondaryData.areaSize * currentSecondaryData.areaSizeUpgradePercent;
        currentSecondaryData.areaSizeUpgradedTimes++;
        UpdateValues();
    }
    public void UpgradeDuration()
    {
        currentSecondaryData.duration += currentSecondaryData.duration * currentSecondaryData.durationUpgradePercent;
        currentSecondaryData.durationUpgradedTimes++;
        UpdateValues();
    }
    public void UpgradeHitsXSecond()
    {
        currentSecondaryData.hitsXSecond += currentSecondaryData.hitsXSecondUpgradeAmount;
        currentSecondaryData.hitsXSecondUpgradedTimes++;
        UpdateValues();
    }
}
