using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawnController : MonoBehaviour
{
    public static EnemySpawnController Instance;

    public Entity enemy1Prefab;
    [SerializeField] private float spawnRadius = 20f;
    [SerializeField] private float spawnRate = 10f;
    public bool shouldCreateEnemy = false;
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
        CreateMultipleEnemies(10);
    }

    public void CreateMultipleEnemies(int amount)
    {
        for (int i = 0; i < amount; i++)
        {
            CreateEnemy1(enemy1Prefab);
        }

        StartCoroutine(HandleEnemyCreation());
    }
    public void CreateEnemy1(Entity enemy)
    {
        float randomAngle = Random.Range(0f, 360f);

        // Convert the angle to a direction vector
        Vector3 spawnDirection = Quaternion.Euler(0f, 0f, randomAngle) * Vector3.right;

        // Calculate the spawn position just outside the camera view
        Vector3 spawnPosition = PlayerController.Instance.transform.position + spawnDirection * spawnRadius;


        //Entity newEntity = GameObject.Instantiate(enemy, spawnPosition, Quaternion.identity).GetComponent<Entity>();
        Entity newEntity = SpawnController.Instance.enemy1Pool.Spawn(spawnPosition, Quaternion.identity).GetComponent<Entity>();
        Element randomElement = GameData.Instance.GetRandomElement();
        newEntity.SetEntity(randomElement, GameData.Instance.GetEnemy1Data(randomElement));
    }
    private IEnumerator HandleEnemyCreation()
    {
        yield return new WaitForSeconds(spawnRate);
        CreateMultipleEnemies(10);

    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.cyan;
        if(PlayerController.Instance != null)
        {
            Gizmos.DrawWireSphere(PlayerController.Instance.transform.position, spawnRadius);
        }

    }
}
