using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "SecondaryAttackData", menuName = "Data/Attack Base Data/ New Secondary Attack Data")]
public class SecondaryData : AttackData
{
    public AttackStat areaSizeStat = new AttackStat(1f);
    public AttackStat durationStat = new AttackStat(2f);
    public AttackStat hitsXSecondStat = new AttackStat(2f);

    //public float areaSize = 1f;
    //public float duration = 2f;
    //public float hitsXSecond = 2f;


    //public float areaSizeUpgradePercent = 0.2f;
    //public int areaSizeUpgradedTimes = 0;


    //public float durationUpgradePercent = 0.2f;
    //public int durationUpgradedTimes = 0;


    //public int hitsXSecondUpgradeAmount = 1;
    //public int hitsXSecondUpgradedTimes = 0;
}
