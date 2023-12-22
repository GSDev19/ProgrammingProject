using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnController : MonoBehaviour
{
    public static SpawnController Instance;

    public ObjectPool enemy1Pool;
    public ObjectPool areaDamagePool;
    public ObjectPool projectilePool;


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
        enemy1Pool.Initialize();
        areaDamagePool.Initialize();
        projectilePool.Initialize();
    }
}
