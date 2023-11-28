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

    public int damage;
    public float cooldown;
    public float areaSize;
    public float duration;
    public float hitsXSecond;

    public Image secondaryImage;

    public void Set(Element element, SecondaryData data)
    {
        this.damage = data.damage;
        this.cooldown = data.cooldown;
        this.areaSize = data.areaSize;
        this.duration = data.duration;
        this.hitsXSecond = data.hitsXSecond;

        secondaryImage.sprite = GameData.Instance.GetElementSprite(element);

        damageText.text = damage.ToString();
        cooldownText.text = cooldown.ToString();
        areaSizeText.text = areaSize.ToString();
        durationText.text = duration.ToString();
        hitsText.text = hitsXSecond.ToString();

    }
}
