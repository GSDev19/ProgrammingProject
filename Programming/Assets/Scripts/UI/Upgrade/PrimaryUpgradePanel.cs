using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PrimaryUpgradePanel : MonoBehaviour
{
    public List<Button> upgradeButtons = new List<Button>();

    [Header("LEVEL ELEMENTS")]
    public TextMeshProUGUI damageLevelText;
    public TextMeshProUGUI cooldownLevelText;
    public TextMeshProUGUI speedLevelText;
    public TextMeshProUGUI hitsLevelText;
    public TextMeshProUGUI projectileAmountLevelText;

    public Image damageBar;
    public Image cooldownBar;
    public Image speedBar;
    public Image hitsBar;
    public Image projectilesBar;

    [Space]
    [Header("INCREMENT TEXTS")]
    public TextMeshProUGUI damageIncrementText;
    public TextMeshProUGUI cooldownIncrementText;
    public TextMeshProUGUI speedIncrementText;
    public TextMeshProUGUI hitsIncrementText;
    public TextMeshProUGUI projectileAmountIncrementText;

    public Image primaryImage;
    public PrimaryData currentData;
    public void Set(Element element, PrimaryData data)
    {
        this.currentData = data;

        primaryImage.sprite = GameData.Instance.GetElementSprite(element);

        SetIncrementTexts();

        UpdateValues();
    }

    public void UpdateValues()
    {
        damageLevelText.text = currentData.damageStat.level.ToString();
        cooldownLevelText.text = currentData.cooldownStat.level.ToString();
        speedLevelText.text = currentData.speedStat.level.ToString();
        hitsLevelText.text = currentData.speedStat.level.ToString();
        projectileAmountLevelText.text = currentData.projectileAmountStat.level.ToString();

        SetStatBarFill(damageBar, currentData.damageStat.level);
        SetStatBarFill(cooldownBar, currentData.cooldownStat.level);
        SetStatBarFill(speedBar, currentData.speedStat.level);
        SetStatBarFill(hitsBar, currentData.enemyHitsStat.level);
        SetStatBarFill(projectilesBar, currentData.projectileAmountStat.level);

        CheckIfEnoughPoints();
    }
    private void SetIncrementTexts()
    {
        damageIncrementText.text = "+ " + currentData.damageStat.incrementAmount.ToString();
        cooldownIncrementText.text = "- " + currentData.cooldownStat.incrementAmount.ToString() + "%";
        speedIncrementText.text = "+ " + currentData.speedStat.incrementAmount.ToString() + "%";
        hitsIncrementText.text = "+ " + currentData.enemyHitsStat.incrementAmount.ToString();
        projectileAmountIncrementText.text = "+ " + currentData.projectileAmountStat.incrementAmount.ToString();
    }

    public void UpgradeDamage()
    {
        if(PlayerController.Instance.Core.Experience.CheckIfHasEnoughPoints() && currentData.damageStat.level < 10)
        {
            currentData.damageStat.currentValue += currentData.damageStat.incrementAmount;
            currentData.damageStat.level++;
            PlayerController.Instance.Core.Experience.ExpendPoint();
            UpdateValues();
        }
    }
    public void UpgradeCooldown()
    {
        if (PlayerController.Instance.Core.Experience.CheckIfHasEnoughPoints() && currentData.cooldownStat.level < 10)
        {
            currentData.cooldownStat.currentValue -= (float)currentData.cooldownStat.incrementAmount / 100f;
            currentData.cooldownStat.level++;
            PlayerController.Instance.Core.Experience.ExpendPoint();
            UpdateValues();
        }

    }
    public void UpgradeSpeed()
    {
        if (PlayerController.Instance.Core.Experience.CheckIfHasEnoughPoints() && currentData.speedStat.level < 10)
        {
            currentData.speedStat.currentValue += (float)currentData.speedStat.incrementAmount / 100f;
            currentData.speedStat.level++;
            PlayerController.Instance.Core.Experience.ExpendPoint();
            UpdateValues();
        }

    }
    public void UpgradeEnemyHits()
    {
        if (PlayerController.Instance.Core.Experience.CheckIfHasEnoughPoints() && currentData.enemyHitsStat.level < 10)
        {
            currentData.enemyHitsStat.currentValue += currentData.enemyHitsStat.incrementAmount;
            currentData.enemyHitsStat.level++;
            PlayerController.Instance.Core.Experience.ExpendPoint();
            UpdateValues();
        }

    }
    public void UpgradeProjectileAmount()
    {
        if (PlayerController.Instance.Core.Experience.CheckIfHasEnoughPoints() && currentData.projectileAmountStat.level < 10)
        {
            currentData.projectileAmountStat.currentValue += currentData.projectileAmountStat.incrementAmount;
            currentData.projectileAmountStat.level++;
            PlayerController.Instance.Core.Experience.ExpendPoint();
            UpdateValues();
        }

    }

    private void SetStatBarFill(Image image, int currentLevel)
    {
        image.fillAmount = (float)currentLevel / 10;
    }
    private void CheckIfEnoughPoints()
    {
        if(PlayerController.Instance.Core.Experience.currentPoints > 0)
        {
            foreach(Button button in upgradeButtons)
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
}
