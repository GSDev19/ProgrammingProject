using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackComponent : CoreComponent
{
    public Element currentPrimaryElement;
    public Element currentSecondaryElement;

    private PrimaryData primaryAttackData;
    private SecondaryData secondaryAttackData;

    private float currentPrimaryReloadTime;
    private float currentSecondaryReloadTime;

    private bool canPrimaryAttack;
    private bool canSecondaryAttack;

    private void Start()
    {
        canPrimaryAttack = true;
        canSecondaryAttack = true;

        SetPrimaryData(currentPrimaryElement);
        SetSecondaryData(currentSecondaryElement);
    }

    public void SetPrimaryData(Element element)
    {
        currentPrimaryElement = element;
        primaryAttackData = GameData.Instance.GetPrimaryData(element);
        UIController.Instance.ChangePrimarySprite(GameData.Instance.GetElementSprite(element));
        CheckIfSameElement();
    }
    public void SetSecondaryData(Element element)
    {
        currentSecondaryElement = element;
        secondaryAttackData = GameData.Instance.GetSecondaryData(element);
        UIController.Instance.ChangeSecondarySprite(GameData.Instance.GetElementSprite(element));
        CheckIfSameElement();
    }

    private void CheckIfSameElement()
    {
        if(currentPrimaryElement == currentSecondaryElement)
        {
            PlayerController.Instance.ChangeElement(currentPrimaryElement);
        }
        else
        {
            PlayerController.Instance.ChangeElement(Element.None);
        }
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

        Vector3 perpendicularVector = new Vector3(-direction.y, direction.x, 0f).normalized;

        // Calculate the angle in degrees
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

        // Loop to instantiate and shoot multiple projectiles
        for (int i = 0; i < data.projectileAmount; i++)
        {
            // Create a projectile
            //GameObject projectile = Instantiate(data.prefab, transform.position, Quaternion.Euler(0f, 0f, angle));
            Vector3 spawnPosition = transform.position + perpendicularVector * (i - (data.projectileAmount - 1) / 2f) * 0.5f;

            GameObject projectile = SpawnController.Instance.projectilePool.Spawn(spawnPosition, Quaternion.Euler(0f, 0f, angle));

            projectile.GetComponent<Projectile>().SetProjectile(data.element, direction, data.speed, data.damage, data.enemyHits);
        }
    }
    private void CreateAttackArea(SecondaryData data)
    {
        //GameObject areaDamage = Instantiate(data.prefab, transform.position, Quaternion.identity);
        GameObject areaDamage = SpawnController.Instance.areaDamagePool.Spawn(transform.position, Quaternion.identity);
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
