using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointToMouse : MonoBehaviour
{
    private Animator animator;
    private float angle;
    private void Start()
    {
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        Vector3 direction = (mousePosition - transform.position).normalized;

        angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

        angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

        SetAnimationState();
    }

    void SetAnimationState()
    {
        angle = (angle + 360) % 360;

        if (angle >= 315 || angle < 45)
        {
            SetAnimatorState("Right");
        }
        else if (angle >= 45 && angle < 135)
        {
            SetAnimatorState("Up");
        }
        else if (angle >= 135 && angle < 225)
        {
            SetAnimatorState("Left");
        }
        else if (angle >= 225 && angle < 315)
        {
            SetAnimatorState("Down");
        }
    }

    void SetAnimatorState(string state)
    {
        if (animator != null)
        {
            animator.Play(state);
        }
    }
}
