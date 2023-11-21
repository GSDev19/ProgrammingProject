using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Core : MonoBehaviour
{
    public Rigidbody2D RB;
    public MovementComponent Movement;

    private void Awake()
    {
        RB = GetComponentInParent<Rigidbody2D>();

        Movement = GetComponentInChildren<MovementComponent>();
    }
}
