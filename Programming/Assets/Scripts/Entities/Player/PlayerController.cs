using System.Collections;
using System.Collections.Generic;
using System.Xml.Linq;
using UnityEngine;

public class PlayerController : Entity
{
    public static PlayerController Instance { get; private set; }

    public PlayerData data;

    public string stateName;

    public override void Awake()
    {
        base.Awake();

        if (!Instance)
        {
            Instance = this;
        }
        else if (Instance != this)
        {
            Destroy(this.gameObject);
        }

        EntityData = data;

        ResetStats();

    }
    private void Start()
    {
        currentElement = Element.None;

        moveState = new PlayerMoveState(this, data, StateMachine, Core, stateName);
        idleState = new PlayerIdleState(this, data, StateMachine, Core, stateName);
        primaryAttackState = new PlayerPrimaryAttackState(this, data, StateMachine, Core, stateName);
        secondaryAttackState = new PlayerSecondaryAttackState(this, data, StateMachine, Core, stateName);

        StateMachine.Initialize(idleState);

        Core.Life.SetInitialEntityHealth(data.healthStat.currentValue);
    }
    private void Update()
    {
        StateMachine.CurrentState.LogicUpdate();
        stateName = StateMachine.CurrentState.StateName();
    }
    private void FixedUpdate()
    {
        StateMachine.CurrentState.PhysicsUpdate();
    }
    //public void ChangeElement(Element element)
    //{
    //    currentElement = element;
    //    spriteRenderer.color = GameData.Instance.GetColor(element);
    //}
    private void ResetStats()
    {
        data.healthStat.Reset();
        data.recoveryStat.Reset();
        data.armorStat.Reset();
        data.movementSpeedStat.Reset();
        data.luckStat.Reset();
    }
}
