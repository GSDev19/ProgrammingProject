using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "PrimaryAttackData", menuName = "Data/Attack Base Data/ New Primary Attack Data")]
public class PrimaryData : AttackData
{
    public AttackStat speedStat = new AttackStat(3f);
    public AttackStat enemyHitsStat = new AttackStat(1f);
    public AttackStat projectileAmountStat = new AttackStat(1f);
}
