using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackComponent : CoreComponent
{
    public PrimaryData primaryAttackData;
    public SecondaryData secondaryAttackData;

    public float currentPrimaryReloadTime = 0f;
    public float currentSecondaryReloadTime = 0f;

    public bool canPrimaryAttack;
    public bool canSecondaryAttack;

    private void Start()
    {
        canPrimaryAttack = true;
        canSecondaryAttack = true;

        SetPrimarySprite();
        SetSecondarySprite();
    }

    private void SetPrimarySprite()
    {
        Debug.Log("1 =" + primaryAttackData.element);
        UIController.Instance.ChangePrimarySprite(GameData.Instance.GetElementSprite(primaryAttackData.element));
    }
    private void SetSecondarySprite()
    {
        Debug.Log("2 =" + secondaryAttackData.element);
        UIController.Instance.ChangeSecondarySprite(GameData.Instance.GetElementSprite(secondaryAttackData.element));

    }
    public void HandlePrimaryAttack()
    {
        if(canPrimaryAttack)
        {
            canPrimaryAttack = false;
            FireProjetiles(primaryAttackData);
            StartCoroutine(PrimaryCooldown(primaryAttackData.cooldown));
        }
    }
    public void HandleSecondaryAttack()
    {
        if(canSecondaryAttack)
        {
            canSecondaryAttack = false;
            CreateAttackArea(secondaryAttackData);
            StartCoroutine(SecondaryCooldown(secondaryAttackData.cooldown));
        }
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
    private IEnumerator PrimaryCooldown(float cooldown)
    {
        currentPrimaryReloadTime = 0f;

        while (currentPrimaryReloadTime < cooldown)
        {
            currentPrimaryReloadTime += Time.deltaTime;
            UIController.Instance.SetPrimaryBlockerValue(currentPrimaryReloadTime, cooldown);
            yield return null;
        }
        currentPrimaryReloadTime = cooldown;
        UIController.Instance.SetPrimaryBlockerValue(currentPrimaryReloadTime, cooldown);
        canPrimaryAttack = true;
    }
    private IEnumerator SecondaryCooldown(float cooldown)
    {
        currentSecondaryReloadTime = 0f;

        while (currentSecondaryReloadTime < cooldown)
        {
            currentSecondaryReloadTime += Time.deltaTime;
            UIController.Instance.SetSecondaryBlockerValue(currentSecondaryReloadTime, cooldown);

            yield return null;
        }
        currentPrimaryReloadTime = cooldown;
        UIController.Instance.SetSecondaryBlockerValue(currentSecondaryReloadTime, cooldown);
        canSecondaryAttack = true;
    }
}
