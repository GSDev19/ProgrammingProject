using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PrimaryUpgradePanel : MonoBehaviour
{
    public TextMeshProUGUI damageText;
    public TextMeshProUGUI cooldownText;
    public TextMeshProUGUI speedText;
    public TextMeshProUGUI hitsText;
    public TextMeshProUGUI amountText;

    public int damage;
    public float cooldown;
    public float speed;
    public int enemyHits;
    public int projectileAmount;

    public Image primaryImage;

    public void Set(Element element, PrimaryData data)
    {
        this.damage = data.damage;
        this.cooldown = data.cooldown;
        this.speed = data.speed;
        this.enemyHits = data.enemyHits;
        this.projectileAmount = data.projectileAmount;

        primaryImage.sprite = GameData.Instance.GetElementSprite(element);

        damageText.text = damage.ToString();
        cooldownText.text = cooldown.ToString();
        speedText.text = speed.ToString();
        hitsText.text = enemyHits.ToString();
        amountText.text = projectileAmount.ToString();

    }
}
