using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "EntityData", menuName = "Data/Entity Base Data/ New Entity Data")]
public class EntityData : ScriptableObject
{
    [Header("GENERAL")]
    public float enemySize = 1.5f;
    [Space]
    [Header("MOVEMENT")]
    //public float movementSpeed = 5f;
    public Stat movementSpeedStat = new Stat(5f);
    [Header("HEALTH")]
    //public int entityHealth = 100;
    public Stat healthStat = new Stat(100f);

    [Header("EXP")]
    public int entityExp = 10;
    [Header("DAMAGE")]
    public int damage = 5;
    public float damageRadious = 1.4f;
    public float damageCooldown = 0.5f;

}
