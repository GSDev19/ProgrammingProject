using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "PrimaryAttackData", menuName = "Data/Attack Base Data/ New Primary Attack Data")]
public class PrimaryData : AttackData
{
    public Stat speedStat = new Stat(3f);
    public Stat enemyHitsStat = new Stat(1f);
    public Stat projectileAmountStat = new Stat(1f);
}
