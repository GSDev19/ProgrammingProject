using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "SecondaryAttackData", menuName = "Data/Attack Base Data/ New Secondary Attack Data")]
public class SecondaryData : AttackData
{
    public float areaSize = 1f;
    public float duration = 2f;
    public float hitsXSecond = 2f;


    public int areaSizeUpgradePercent = 20;
    public int areaSizeUpgradedTimes = 0;


    public int durationUpgradePercent = 20;
    public int durationUpgradedTimes = 0;


    public int hitsXSecondUpgradeAmount = 1;
    public int hitsXSecondUpgradedTimes = 0;
}
