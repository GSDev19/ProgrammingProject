using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "SpawnData", menuName = "Data/Spawn Base Data/ New LevelSpawn Data")]
public class LevelSpawnData : ScriptableObject
{
    public List<SpawnData> spawnDatas;
}
