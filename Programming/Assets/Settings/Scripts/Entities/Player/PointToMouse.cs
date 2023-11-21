using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointToMouse : MonoBehaviour
{
    private void Update()
    {
        // Get the mouse position in world coordinates
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        // Calculate the direction from the player to the mouse position
        Vector3 direction = (mousePosition - transform.position).normalized;

        // Calculate the angle in degrees
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

        // Set the rotation of the player to face the mouse position
        transform.rotation = Quaternion.Euler(new Vector3(0f, 0f, angle - 90f));
    }
}
