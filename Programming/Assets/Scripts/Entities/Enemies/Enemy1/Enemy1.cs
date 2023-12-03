using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy1 : Entity
{
    public string stateName;
    public Enemy1Data data;

    public override void Awake()
    {
        base.Awake();

        ResetStats();
    }

    private void Start()
    {
        moveState = new Enemy1MoveState(this, data, StateMachine, Core, stateName, spriteRenderer);
        idleState = new Enemy1IdleState(this, data, StateMachine, Core, stateName);

        StateMachine.Initialize(idleState);
    }
    private void Update()
    {
        StateMachine.CurrentState.LogicUpdate();
        stateName = StateMachine.CurrentState.StateName();

        CheckIfShouldRelocate();
    }
    private void FixedUpdate()
    {
        StateMachine.CurrentState.PhysicsUpdate();
    }

    private void CheckIfShouldRelocate()
    {
        float distance = Vector3.Distance(PlayerController.Instance.transform.position, transform.position);

        if (EnemySpawnController.Instance.MaxEnemyRadius < distance)
        {
            Vector3 directionToPlayer = (PlayerController.Instance.transform.position - transform.position).normalized;
            Vector3 newPosition = PlayerController.Instance.transform.position + directionToPlayer * EnemySpawnController.Instance.SpawnRadius;
            transform.position = newPosition;
        }
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.cyan;
        Gizmos.DrawWireSphere(transform.position, data.minDistanceToPlayer);
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, data.damageRadious);
    }
    private void ResetStats()
    {
        data.healthStat.Reset();
        data.movementSpeedStat.Reset();
    }
}
