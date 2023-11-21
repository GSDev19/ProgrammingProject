using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "PlayerData", menuName = "Data/Entity Base Data/ New Player Data")]
public class PlayerData : EntityData
{
    [Header("SPECIFIC")]
    [Header("EXP")]
    public int exp = 0;
}
