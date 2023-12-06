using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class SpawnData
{
    public string description;
    public int amountOfEnemies = 20;
    public List<EntityData> enemydatas;
    public List<Element> elements;
}
