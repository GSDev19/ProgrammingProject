using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PrimaryUpgradePanel : MonoBehaviour
{
    public List<Button> upgradeButtons = new List<Button>();

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

        CheckIfEnoughPoints();
    }


    public void UpgradeDamage()
    {
        if(PlayerController.Instance.Core.Experience)
        {
            currentPrimaryData.damageStat.currentValue += currentPrimaryData.damageStat.incrementAmount;
            currentPrimaryData.damageStat.timesIncremented++;
            PlayerController.Instance.Core.Experience.ExpendPoint();
            UpdateValues();
        }
    }
    public void UpgradeCooldown()
    {
        if (PlayerController.Instance.Core.Experience)
        {
            currentPrimaryData.cooldownStat.currentValue -= currentPrimaryData.cooldownStat.currentValue * currentPrimaryData.cooldownStat.incrementPercentaje;
            currentPrimaryData.cooldownStat.timesIncremented++;
            PlayerController.Instance.Core.Experience.ExpendPoint();
            UpdateValues();
        }

    }
    public void UpgradeSpeed()
    {
        if (PlayerController.Instance.Core.Experience)
        {
            currentPrimaryData.speedStat.currentValue += currentPrimaryData.speedStat.currentValue * currentPrimaryData.speedStat.incrementPercentaje;
            currentPrimaryData.speedStat.timesIncremented++;
            PlayerController.Instance.Core.Experience.ExpendPoint();
            UpdateValues();
        }

    }
    public void UpgradeEnemyHits()
    {
        if (PlayerController.Instance.Core.Experience)
        {
            currentPrimaryData.enemyHitsStat.currentValue += currentPrimaryData.enemyHitsStat.incrementAmount;
            currentPrimaryData.enemyHitsStat.timesIncremented++;
            PlayerController.Instance.Core.Experience.ExpendPoint();
            UpdateValues();
        }

    }
    public void UpgradeProjectileAmount()
    {
        if (PlayerController.Instance.Core.Experience)
        {
            currentPrimaryData.projectileAmountStat.currentValue += currentPrimaryData.projectileAmountStat.incrementAmount;
            currentPrimaryData.projectileAmountStat.timesIncremented++;
            PlayerController.Instance.Core.Experience.ExpendPoint();
            UpdateValues();
        }

    }

    private void CheckIfEnoughPoints()
    {
        if(PlayerController.Instance.Core.Experience.currentPoints > 0)
        {
            foreach(Button button in upgradeButtons)
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
