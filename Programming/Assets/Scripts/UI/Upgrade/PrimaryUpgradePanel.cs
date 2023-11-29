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

    //public int damage;
    //public float cooldown;
    //public float speed;
    //public int enemyHits;
    //public int projectileAmount;

    public Image primaryImage;
    public PrimaryData currentPrimaryData;
    public void Set(Element element, PrimaryData data)
    {
        this.currentPrimaryData = data;
        //this.damage = data.damage;
        //this.cooldown = data.cooldown;
        //this.speed = data.speed;
        //this.enemyHits = data.enemyHits;
        //this.projectileAmount = data.projectileAmount;

        primaryImage.sprite = GameData.Instance.GetElementSprite(element);

        damageText.text = currentPrimaryData.damage.ToString();
        cooldownText.text = currentPrimaryData.cooldown.ToString();
        speedText.text = currentPrimaryData.speed.ToString();
        hitsText.text = currentPrimaryData.enemyHits.ToString();
        projetileAmount.text = currentPrimaryData.projectileAmount.ToString();
    }

    public void UpdateValues()
    {
        damageText.text = currentPrimaryData.damage.ToString();
        cooldownText.text = currentPrimaryData.cooldown.ToString();
        speedText.text = currentPrimaryData.speed.ToString();
        hitsText.text = currentPrimaryData.enemyHits.ToString();
        projetileAmount.text = currentPrimaryData.projectileAmount.ToString();
    }


    public void UpgradeDamage()
    {
        currentPrimaryData.damage += currentPrimaryData.damageUpgradeAmount;
        currentPrimaryData.damageUpgradeAmount++;
        UpdateValues();
    }
    public void UpgradeCooldown()
    {
        currentPrimaryData.cooldown -= currentPrimaryData.cooldown * currentPrimaryData.cooldownUpgradePercent;
        currentPrimaryData.cooldownUpgradedTimes++;
        UpdateValues();
    }
    public void UpgradeSpeed()
    {
        currentPrimaryData.speed += currentPrimaryData.speed * currentPrimaryData.speedUpgradePercent;
        currentPrimaryData.speedUpgradePercent++;
        UpdateValues();
    }
    public void UpgradeEnemyHits()
    {
        currentPrimaryData.enemyHits += currentPrimaryData.enemyHistsUpgradeAmount;
        currentPrimaryData.enemyHitsUpgradedTimes++;
        UpdateValues();
    }
    public void UpgradeProjectileAmount()
    {
        currentPrimaryData.projectileAmount += currentPrimaryData.projectileAmountUpgradeAmount;
        currentPrimaryData.projectileAmountUpgradedTimes++;
        UpdateValues();
    }
}
