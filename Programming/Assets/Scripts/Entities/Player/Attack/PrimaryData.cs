using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "PrimaryAttackData", menuName = "Data/Attack Base Data/ New Primary Attack Data")]
public class PrimaryData : AttackData
{
    public float speed = 3f;
    public int enemyHits = 1;
    public int projectileAmount = 1;


    public float speedUpgradePercent = 0.2f;
    public int speedUpgradedTimes = 0;


    public int enemyHistsUpgradeAmount = 1;
    public int enemyHitsUpgradedTimes = 0;


    public int projectileAmountUpgradeAmount = 1;
    public int projectileAmountUpgradedTimes = 0;
}
