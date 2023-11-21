using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "AttackData", menuName = "Data/Attack Base Data/ New Attack Data")]
public class AttackData : ScriptableObject
{
    public AttackType attackType;
    public Element element;

    public int damage = 20;
    public float area = 2f;
    public float fireRate = 1f;
    public float duration = 2f;

}
public enum AttackType
{
    Primary,
    Secondary
}
public enum Element
{
    Fire,
    Water,
    Plant
}
