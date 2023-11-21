using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "PrimaryAttackData", menuName = "Data/Attack Base Data/ New Primary Attack Data")]
public class PrimaryData : AttackData
{
    public float speed = 3f;
    public int enemyHits = 1;
    public int projectileAmount = 1;
}
