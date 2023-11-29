using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "PlayerData", menuName = "Data/Entity Base Data/ New Player Data")]
public class PlayerData : EntityData
{
    [Header("SPECIFIC")]
    [Header("STATS")]
    public Stat armorStat = new Stat(2f);
    public Stat recoveryStat = new Stat(2f);
    public Stat luckStat = new Stat(2f);
}
