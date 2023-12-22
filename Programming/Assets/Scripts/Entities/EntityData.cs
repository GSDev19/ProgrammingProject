using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "EntityData", menuName = "Data/Entity Base Data/ New Entity Data")]
public class EntityData : ScriptableObject
{
    [Header("GENERAL")]
    [Range(0, 2)]
    public int entityLevel = 0;
    public float entitySize = 1.5f;
    [Space]
    [Header("MOVEMENT")]
    public Stat movementSpeedStat = new Stat(5f);
    [Space]
    [Header("HEALTH")]
    public Stat healthStat = new Stat(100f);
    [Space]
    [Header("EXP")]
    public int entityExp = 10;
    [Space]
    [Header("DAMAGE")]
    public int damage = 5;
    public float damageRadious = 1.4f;
    public float damageCooldown = 0.5f;
    [Space]
    [Header("BEHAVIOUR")]
    public float minDistanceToPlayer = 1.5f;
    public float rotationSpeed = 50f;

}
