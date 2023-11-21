using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Enemy1Data", menuName = "Data/Entity Base Data/ New Enemy1 Data")]
public class Enemy1Data : EntityData
{
    [Header("SPECIFIC")]
    [Header("BEHAVIOUR")]
    public float minDistanceToPlayer = 10f;
    public float rotationSpeed = 50f;
}
