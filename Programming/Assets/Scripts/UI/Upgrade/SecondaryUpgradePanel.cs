using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SecondaryUpgradePanel : MonoBehaviour
{
    public List<Button> upgradeButtons = new List<Button>();

    [Header("LEVEL ELEMENTS")]
    public TextMeshProUGUI damageLevelText;
    public TextMeshProUGUI cooldownLevelText;
    public TextMeshProUGUI areaLevelText;
    public TextMeshProUGUI durationLevelText;
    public TextMeshProUGUI hitsLevelText;

    public Image damageBar;
    public Image cooldownBar;
    public Image areaBar;
    public Image durationBar;
    public Image hitsBar;

    [Space]
    [Header("INCREMENT TEXTS")]
    public TextMeshProUGUI damageIncrementText;
    public TextMeshProUGUI cooldownIncrementText;
    public TextMeshProUGUI areaSizeIncrementText;
    public TextMeshProUGUI durationIncrementText;
    public TextMeshProUGUI hitsIncrementText;

    public Image secondaryImage;

    public SecondaryData currentData;

    public void Set(Element element, SecondaryData data)
    {
        this.currentData = data;

        secondaryImage.sprite = GameData.Instance.GetElementSprite(element);

        SetIncrementTexts();

        UpdateValues();

    }
    public void UpdateValues()
    {
        damageLevelText.text = currentData.damageStat.level.ToString();
        cooldownLevelText.text = currentData.cooldownStat.level.ToString();
        areaLevelText.text = currentData.areaSizeStat.level.ToString();
        durationLevelText.text = currentData.durationStat.level.ToString();
        hitsLevelText.text = currentData.hitsXSecondStat.level.ToString();

        SetStatBarFill(damageBar, currentData.damageStat.level);
        SetStatBarFill(cooldownBar, currentData.cooldownStat.level);
        SetStatBarFill(areaBar, currentData.areaSizeStat.level);
        SetStatBarFill(durationBar, currentData.durationStat.level);
        SetStatBarFill(hitsBar, currentData.hitsXSecondStat.level);

        CheckIfEnoughPoints();
    }

    private void SetIncrementTexts()
    {
        damageIncrementText.text = "+ " + currentData.damageStat.incrementAmount.ToString();
        cooldownIncrementText.text = "- " + currentData.cooldownStat.incrementAmount.ToString() + "%";
        areaSizeIncrementText.text = "+ " + currentData.areaSizeStat.incrementAmount.ToString() + "%";
        durationIncrementText.text = "+ " + currentData.durationStat.incrementAmount.ToString() + "%";
        hitsIncrementText.text = "+ " + currentData.hitsXSecondStat.incrementAmount.ToString();
    }
    public void UpgradeDamage()
    {
        if (PlayerController.Instance.Core.Experience.CheckIfHasEnoughPoints() && currentData.damageStat.level < 10)
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
            //currentData.cooldownStat.currentValue -= (float)currentData.cooldownStat.incrementAmount / 100f;

            float increase = currentData.cooldownStat.currentValue * ((float)currentData.cooldownStat.incrementAmount / 100f);

            currentData.cooldownStat.currentValue -= increase;

            currentData.cooldownStat.level++;
            PlayerController.Instance.Core.Experience.ExpendPoint();
            UpdateValues();
        }

    }
    public void UpgradeAreaSize()
    {
        if (PlayerController.Instance.Core.Experience.CheckIfHasEnoughPoints() && currentData.areaSizeStat.level < 10)
        {
            //currentData.areaSizeStat.currentValue += (float)currentData.areaSizeStat.incrementAmount / 100f;

            float increase = currentData.areaSizeStat.currentValue * ((float)currentData.areaSizeStat.incrementAmount / 100f);

            currentData.areaSizeStat.currentValue += increase;

            currentData.areaSizeStat.level++;
            PlayerController.Instance.Core.Experience.ExpendPoint();
            UpdateValues();
        }

    }
    public void UpgradeDuration()
    {
        if (PlayerController.Instance.Core.Experience.CheckIfHasEnoughPoints() && currentData.durationStat.level < 10)
        {
            //currentData.durationStat.currentValue += (float)currentData.durationStat.incrementAmount / 100f;
            float increase = currentData.durationStat.currentValue * ((float)currentData.durationStat.incrementAmount / 100f);

            currentData.durationStat.currentValue += increase;

            currentData.durationStat.level++;
            PlayerController.Instance.Core.Experience.ExpendPoint();
            UpdateValues();
        }

    }
    public void UpgradeHitsXSecond()
    {
        if (PlayerController.Instance.Core.Experience.CheckIfHasEnoughPoints() && currentData.hitsXSecondStat.level < 10)
        {
            currentData.hitsXSecondStat.currentValue += currentData.hitsXSecondStat.incrementAmount;
            currentData.hitsXSecondStat.level++;
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
}
