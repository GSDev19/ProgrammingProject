using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackData : ScriptableObject
{
    public Element element;

    public GameObject prefab;

    public int damage = 20;

    public float cooldown = 1f;

    public int damageUpgradeAmount = 10;
    public int damageUpgradedTimes = 0;

    public float cooldownUpgradePercent = 0.1f;
    public int cooldownUpgradedTimes = 0;
}
public enum AttackActionType
{
    Primary,
    Secondary
}
