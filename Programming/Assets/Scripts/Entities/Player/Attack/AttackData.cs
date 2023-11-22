using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackData : ScriptableObject
{
    public Element element;

    public GameObject prefab;

    public int damage = 20;

    public float cooldown = 1f;
}

