using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "SecondaryAttackData", menuName = "Data/Attack Base Data/ New Secondary Attack Data")]
public class SecondaryData : AttackData
{
    public Stat areaSizeStat = new Stat(1f);
    public Stat durationStat = new Stat(2f);
    public Stat hitsXSecondStat = new Stat(2f);
}
