using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "SecondaryAttackData", menuName = "Data/Attack Base Data/ New Secondary Attack Data")]
public class SecondaryData : AttackData
{
    public AttackStat areaSizeStat = new AttackStat(1f);
    public AttackStat durationStat = new AttackStat(2f);
    public AttackStat hitsXSecondStat = new AttackStat(2f);
}
