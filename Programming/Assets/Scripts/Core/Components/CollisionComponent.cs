using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionComponent : CoreComponent
{
    public bool CheckDistanceToPlayer(Transform playerTransform, Transform enemyTransform, float detectionRange)
    {
        float distanceToPlayer = Vector3.Distance(enemyTransform.position, playerTransform.position);

        // Check if the player is within the detection range
        return distanceToPlayer <= detectionRange;
    }
}
