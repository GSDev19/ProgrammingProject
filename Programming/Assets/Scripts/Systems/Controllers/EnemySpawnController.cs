using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawnController : MonoBehaviour
{
    public static EnemySpawnController Instance;

    //public Entity enemy1Prefab;
    [field: SerializeField] public float  SpawnRadius {get; private set;}
    [SerializeField] private float spawnRate = 10f;
    [field: SerializeField] public float MaxEnemyRadius {get; private set;}

    public LevelSpawnData levelSpawnData;
    public SpawnData currentSpawnData;
    public int spawnDataIndex = 0;
    private void Awake()
    {
        if (!Instance)
        {
            Instance = this;
        }
        else if (Instance != this)
        {
            Destroy(this.gameObject);
        }
    }
    private void Start()
    {
        spawnDataIndex = 0;
        currentSpawnData = levelSpawnData.spawnDatas[spawnDataIndex];

        CreateMultipleEnemies(currentSpawnData.amountOfEnemies);
    }

    public void CreateMultipleEnemies(int amount)
    {
        for (int i = 0; i < amount; i++)
        {
            CreateEnemy1();
        }

        StartCoroutine(HandleEnemyCreation());


    }

    public int GetNextIndex()
    {
        int currentIndex = spawnDataIndex;

        if(currentIndex  >= levelSpawnData.spawnDatas.Count)
        {
            Debug.Log("RETURN COUNT");
            spawnDataIndex = levelSpawnData.spawnDatas.Count;
        }
        else
        {
            spawnDataIndex = currentIndex + 1;
            Debug.Log("INDEX " + spawnDataIndex);
        }
        return spawnDataIndex;
    }
    public void CreateEnemy1()
    {
        float randomAngle = Random.Range(0f, 360f);

        // Convert the angle to a direction vector
        Vector3 spawnDirection = Quaternion.Euler(0f, 0f, randomAngle) * Vector3.right;

        // Calculate the spawn position just outside the camera view
        Vector3 spawnPosition = PlayerController.Instance.transform.position + spawnDirection * SpawnRadius;

        Entity newEntity = SpawnController.Instance.enemy1Pool.Spawn(spawnPosition, Quaternion.identity).GetComponent<Entity>();
        Element randomElement = GameData.Instance.GetRandomElement(currentSpawnData.elements);
        EntityData randomEntityData = GetRandomData(currentSpawnData.enemydatas);

        newEntity.SetEntity(randomElement, randomEntityData);
    }
    private EntityData GetRandomData(List<EntityData> entities)
    {
        if (entities.Count > 0)
        {
            int randomIndex = Random.Range(0, entities.Count - 1);

            return entities[randomIndex];
        }
        else
        {
            return entities[0];
        }
    }
    private IEnumerator HandleEnemyCreation()
    {
        yield return new WaitForSeconds(spawnRate);
        currentSpawnData = levelSpawnData.spawnDatas[GetNextIndex()];
        CreateMultipleEnemies(currentSpawnData.amountOfEnemies);

    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.cyan;
        if(PlayerController.Instance != null)
        {
            Gizmos.DrawWireSphere(PlayerController.Instance.transform.position, SpawnRadius);
            Gizmos.DrawWireSphere(PlayerController.Instance.transform.position, MaxEnemyRadius);
        }

    }
}
