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
    public void GoToPlayer(Transform playerTransform, Transform enemyTransform, float movementSpeed, float rotationSpeed)
    {
        // Calculate the direction from the enemy to the player
        Vector3 direction = (playerTransform.position - enemyTransform.position).normalized;

        // Calculate the angle in degrees
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

        // Create a rotation to face the player
        Quaternion targetRotation = Quaternion.Euler(new Vector3(0f, 0f, angle - 90f));

        // Rotate the enemy towards the player
        enemyTransform.rotation = Quaternion.Slerp(enemyTransform.rotation, targetRotation, rotationSpeed * Time.deltaTime);

        // Move the enemy towards the player
        enemyTransform.Translate(Vector3.up * movementSpeed * Time.deltaTime);
    }
}
