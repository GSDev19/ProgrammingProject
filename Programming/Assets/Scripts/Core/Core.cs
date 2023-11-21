using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Core : MonoBehaviour
{
    public PlayerController player { get; private set; }
    public Rigidbody2D RB { get; private set; }
    public MovementComponent Movement { get; private set; }
    public CollisionComponent Collision { get; private set; }
    public AttackComponent Attack { get; private set; }
    public LifeComponent Life { get; private set; }

    private void Awake()
    {
        RB = GetComponentInParent<Rigidbody2D>();

        Movement = GetComponentInChildren<MovementComponent>();
        Collision = GetComponentInChildren<CollisionComponent>();
        Attack = GetComponentInChildren<AttackComponent>();
        Life = GetComponentInChildren<LifeComponent>();
    }
    private void Start()
    {
        player = PlayerController.Instance;
    }
}
