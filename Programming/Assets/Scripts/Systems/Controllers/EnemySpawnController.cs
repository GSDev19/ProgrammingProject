using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawnController : MonoBehaviour
{
    public static EnemySpawnController Instance;

    public Entity enemy1Prefab;
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
    //private void Start()
    //{
    //    CreateMultipleEnemies(10);
    //}

    private void Update()
    {
        if(shouldCreateEnemy)
        {
            shouldCreateEnemy = false;
            CreateMultipleEnemies(10);
        }
    }
    public void CreateMultipleEnemies(int amount)
    {
        for (int i = 0; i < amount; i++)
        {
            CreateEnemy1(enemy1Prefab);
        }
    }
    public void CreateEnemy1(Entity enemy)
    {
        Entity newEntity = GameObject.Instantiate(enemy, null, true).GetComponent<Entity>();
        Element randomElement = GameData.Instance.GetRandomElement();
        newEntity.SetEntity(randomElement, GameData.Instance.GetEnemy1Data(randomElement));
    }
    
}
