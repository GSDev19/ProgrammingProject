using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackData : ScriptableObject
{
    public Element element;

    public GameObject prefab;

    public Stat damageStat = new Stat(20f);
    public Stat cooldownStat = new Stat(1f);
}
public enum AttackActionType
{
    Primary,
    Secondary
}
