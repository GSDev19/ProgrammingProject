using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Windows;

public class MovementComponent : CoreComponent
{
    private Vector2 workspace;

    public override void Awake()
    {
        base.Awake();

    }

    public void SetDirectionVelocity(Vector2 dir, float velocity)
    {
        workspace.Set(dir.x * velocity, dir.y * velocity);
        Core.RB.velocity = workspace;
    }
    public void SetInputVelocity(int xInput, int yInput, float velocity)
    {
        workspace.Set(xInput * velocity, yInput * velocity);
        Core.RB.velocity = workspace;
    }
    public void SetVelocityZero()
    {
        workspace = Vector2.zero;
        Core.RB.velocity = workspace;
    }
}
