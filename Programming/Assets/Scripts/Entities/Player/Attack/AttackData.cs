using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackData : ScriptableObject
{
    public Element element;

    public GameObject prefab;

    public AttackStat damageStat = new AttackStat(20f);
    public AttackStat cooldownStat = new AttackStat(1f);
}
public enum AttackActionType
{
    Primary,
    Secondary
}
