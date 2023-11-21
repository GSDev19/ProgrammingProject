using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackComponent : CoreComponent
{
    public PrimaryData primaryAttackData;
    public SecondaryData secondaryAttackData;

    public float primaryTimer = 1f;
    public float secondaryTimer = 2f;
    public void HandlePrimaryAttack()
    {
        FireProjetiles(primaryAttackData);
    }
    public void HandleSecondaryAttack()
    {
        CreateAttackArea(secondaryAttackData);
    }

    private void FireProjetiles(PrimaryData data)
    {
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        // Calculate the direction from the player to the mouse position
        Vector3 direction = (mousePosition - transform.position).normalized;

        // Calculate the angle in degrees
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

        // Loop to instantiate and shoot multiple projectiles
        for (int i = 0; i < data.projectileAmount; i++)
        {
            // Create a projectile
            GameObject projectile = Instantiate(data.prefab, transform.position, Quaternion.Euler(0f, 0f, angle));

            projectile.GetComponent<Projectile>().SetProjectile(data.element, direction, data.speed, data.damage, data.enemyHits);
        }
    }

    private void CreateAttackArea(SecondaryData data)
    {
        GameObject areaDamage = Instantiate(data.prefab, transform.position, Quaternion.identity);
        areaDamage.GetComponent<AreaDamage>().SetAreaDamage(data.element,data.areaSize, data.duration, data.hitsXSecond, data.damage);
    }
}
