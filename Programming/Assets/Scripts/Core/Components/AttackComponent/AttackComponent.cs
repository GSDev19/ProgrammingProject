using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackComponent : CoreComponent
{
    public Element currentPrimaryElement;
    public Element currentSecondaryElement;

    [SerializeField] protected PrimaryData primaryAttackData;
    [SerializeField] protected SecondaryData secondaryAttackData;

    protected float currentPrimaryReloadTime;
    protected float currentSecondaryReloadTime;

    public bool canPrimaryAttack;
    public bool canSecondaryAttack;

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
        //CheckIfSameElement();
    }
    public void SetSecondaryData(Element element)
    {
        currentSecondaryElement = element;
        secondaryAttackData = GameData.Instance.GetSecondaryData(element);
        UIController.Instance.ChangeSecondarySprite(GameData.Instance.GetElementSprite(element));
        //CheckIfSameElement();
    }
    public void HandlePrimaryAttack()
    {
        if(canPrimaryAttack)
        {
            canPrimaryAttack = false;
            FireProjetiles(primaryAttackData);
            StartCoroutine(PrimaryCooldown(primaryAttackData.cooldownStat.currentValue));
        }
    }
    public void HandleSecondaryAttack()
    {
        if(canSecondaryAttack)
        {
            canSecondaryAttack = false;
            CreateAttackArea(secondaryAttackData);
            Debug.Log(secondaryAttackData);
            Debug.Log(secondaryAttackData.cooldownStat.currentValue);

            StartCoroutine(SecondaryCooldown(secondaryAttackData.cooldownStat.currentValue));
        }
    }

    protected void FireProjetiles(PrimaryData data)
    {
        Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        Vector2 direction = (mousePosition - (Vector2)transform.position).normalized;

        Vector2 perpendicularVector = new Vector2(-direction.y, direction.x).normalized;

        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

        for (int i = 0; i < data.projectileAmountStat.currentValue; i++)
        {
            Vector2 normalizedDirection = direction.normalized;

            Vector2 spawnPosition = (Vector2)transform.position + perpendicularVector * (i - (data.projectileAmountStat.currentValue - 1) / 2f) * 0.5f;

            GameObject projectile = SpawnController.Instance.projectilePool.Spawn(spawnPosition, Quaternion.Euler(0f, 0f, angle));

            projectile.GetComponent<Projectile>().SetProjectile(data.element, normalizedDirection, data.speedStat.currentValue, data.damageStat.currentValue, data.enemyHitsStat.currentValue);
        }
    }
    protected void CreateAttackArea(SecondaryData data)
    {
        //GameObject areaDamage = Instantiate(data.prefab, transform.position, Quaternion.identity);
        GameObject areaDamage = SpawnController.Instance.areaDamagePool.Spawn(transform.position, Quaternion.identity);
        areaDamage.GetComponent<AreaDamage>().SetAreaDamage(data.element,data.areaSizeStat.currentValue, data.durationStat.currentValue, data.hitsXSecondStat.currentValue, data.damageStat.currentValue);
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
