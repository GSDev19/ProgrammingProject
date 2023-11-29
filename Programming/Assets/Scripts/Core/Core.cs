using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.EventSystems.EventTrigger;

public class Core : MonoBehaviour
{
    //public PlayerController player { get; private set; }
    public Entity Entity { get; private set; }
    public Enemy1 Enemy1 { get; private set; }
    public Rigidbody2D RB { get; private set; }
    public MovementComponent Movement { get; private set; }
    public CollisionComponent Collision { get; private set; }
    public AttackComponent Attack { get; private set; }
    public LifeComponent Life { get; private set; }
    public ExperienceComponent Experience { get; private set; }

    private void Awake()
    {
        Entity = GetComponentInParent<Entity>();

        if(GetComponentInParent<Enemy1>())
        {
            Enemy1 = GetComponentInParent<Enemy1>();
        }
        else
        {
            Enemy1 = null;
        }


        RB = GetComponentInParent<Rigidbody2D>();

        Movement = GetComponentInChildren<MovementComponent>();
        Collision = GetComponentInChildren<CollisionComponent>();
        Attack = GetComponentInChildren<AttackComponent>();
        Life = GetComponentInChildren<LifeComponent>();
        Experience = GetComponentInChildren<ExperienceComponent>();
    }
}
