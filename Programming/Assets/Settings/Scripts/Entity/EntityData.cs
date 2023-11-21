using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "EntityData", menuName = "Data/Entity Base Data/ New Entity Data")]
public class EntityData : ScriptableObject
{
    [Header("GENERAL")]
    [Space]
    [Header("MOVEMENT")]
    public float movementSpeed = 5f;
    [Header("HEALTH")]
    public int entityHealth = 100;
}
