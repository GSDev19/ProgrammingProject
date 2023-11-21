using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : Entity
{
    public static PlayerController Instance { get; private set; }
    public InputHandler InputHandler;

    [field: SerializeField] public EntityData PlayerData;

    public Core Core { get; private set; }

    [SerializeField] public string stateName;
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

        Core = GetComponentInChildren<Core>();
        InputHandler = GetComponent<InputHandler>();


        StateMachine = new StateMachine();
        moveState = new PlayerMoveState(this, PlayerData, StateMachine, Core, InputHandler, stateName, true);
        idleState = new PlayerIdleState(this, PlayerData, StateMachine, Core, InputHandler, stateName, true);


    }
    private void Start()
    {
        StateMachine.Initialize(idleState);
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
}
