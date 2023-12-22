using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class EnemyAttackComponent : AttackComponent
{
    public bool canDamage;
    public float damageCooldown = 1;
    public override void Awake()
    {
        base.Awake();

    }
    private void Start()
    {
        canDamage = true;
        damageCooldown = Core.Enemy1.data.damageCooldown;
    }
    private void Update()
    {
        if(canDamage)
        {
            if(CheckPlayerDistance(Core.Enemy1.data))
            {
                HandleDamageToPlayer(Core.Enemy1.data);
            }
        }        
    }
    private IEnumerator DamageCooldow()
    {
        yield return new WaitForSeconds(damageCooldown);
        canDamage = true;
    }
    private bool CheckPlayerDistance(Enemy1Data data)
    {
        float distance = Vector3.Distance(PlayerController.Instance.transform.position, transform.position);

        if (distance < data.damageRadious)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
    private void HandleDamageToPlayer(Enemy1Data data)
    {
        canDamage = false;
        PlayerController.Instance.Core.Life.HandleDamage(data.damage, Core.Entity.currentElement);
        StartCoroutine(DamageCooldow());
    }
}

