using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

[CreateAssetMenu(fileName = "Enemy1Data", menuName = "Data/Entity Base Data/ New Enemy1 Data")]
public class Enemy1Data : EntityData
{
    [Header("SPECIFIC")]
    [Header("EXP")]
    public int entityExp = 10;
    [Header("DAMAGE")]
    public int damage = 5;
    public float damageRadious = 1.4f;
    public float damageCooldown = 0.5f;
    [Header("BEHAVIOUR")]
    public float minDistanceToPlayer = 10f;
    public float rotationSpeed = 50f;
}
