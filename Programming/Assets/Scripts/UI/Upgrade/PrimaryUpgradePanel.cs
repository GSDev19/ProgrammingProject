using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using static UnityEditor.Rendering.FilterWindow;

public class PrimaryUpgradePanel : MonoBehaviour
{
    public TextMeshProUGUI damageText;
    public TextMeshProUGUI cooldownText;
    public TextMeshProUGUI speedText;
    public TextMeshProUGUI hitsText;
    public TextMeshProUGUI projetileAmount;

    public Image primaryImage;
    public PrimaryData currentPrimaryData;
    public void Set(Element element, PrimaryData data)
    {
        this.currentPrimaryData = data;

        primaryImage.sprite = GameData.Instance.GetElementSprite(element);

        UpdateValues();
    }

    public void UpdateValues()
    {
        damageText.text = currentPrimaryData.damageStat.currentValue.ToString();
        cooldownText.text = currentPrimaryData.cooldownStat.currentValue.ToString();
        speedText.text = currentPrimaryData.speedStat.currentValue.ToString();
        hitsText.text = currentPrimaryData.enemyHitsStat.currentValue.ToString();
        projetileAmount.text = currentPrimaryData.projectileAmountStat.currentValue.ToString();
    }


    public void UpgradeDamage()
    {
        currentPrimaryData.damageStat.currentValue += currentPrimaryData.damageStat.incrementAmount;
        currentPrimaryData.damageStat.timesIncremented++;
        UpdateValues();
    }
    public void UpgradeCooldown()
    {
        currentPrimaryData.cooldownStat.currentValue -= currentPrimaryData.cooldownStat.currentValue * currentPrimaryData.cooldownStat.incrementPercentaje;
        currentPrimaryData.cooldownStat.timesIncremented++;
        UpdateValues();
    }
    public void UpgradeSpeed()
    {
        currentPrimaryData.speedStat.currentValue += currentPrimaryData.speedStat.currentValue * currentPrimaryData.speedStat.incrementPercentaje;
        currentPrimaryData.speedStat.timesIncremented++;
        UpdateValues();
    }
    public void UpgradeEnemyHits()
    {
        currentPrimaryData.enemyHitsStat.currentValue += currentPrimaryData.enemyHitsStat.incrementAmount;
        currentPrimaryData.enemyHitsStat.timesIncremented++;
        UpdateValues();
    }
    public void UpgradeProjectileAmount()
    {
        currentPrimaryData.projectileAmountStat.currentValue += currentPrimaryData.projectileAmountStat.incrementAmount;
        currentPrimaryData.projectileAmountStat.timesIncremented++;
        UpdateValues();
    }
}
