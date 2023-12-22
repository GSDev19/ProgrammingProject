using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy1 : Entity
{
    public string stateName;
    public override void Awake()
    {
        base.Awake();
    }

    private void Start()
    {
        moveState = new Enemy1MoveState(this, EntityData, StateMachine, Core, stateName, spriteRenderer);
        idleState = new Enemy1IdleState(this, EntityData, StateMachine, Core, stateName);

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
        if(EntityData != null)
        {
            Gizmos.color = Color.cyan;
            Gizmos.DrawWireSphere(transform.position, EntityData.minDistanceToPlayer);
            Gizmos.color = Color.red;
            Gizmos.DrawWireSphere(transform.position, EntityData.damageRadious);
        }

    }

    public override void ResetStats()
    {
        base.ResetStats();
    }
}
