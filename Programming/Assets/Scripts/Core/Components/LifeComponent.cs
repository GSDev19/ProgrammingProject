using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LifeComponent : CoreComponent
{
    [SerializeField] private int currentHealth;

    public int GetInitialEntityHealth()
    {
        return GetComponentInParent<Entity>().EntityData.entityHealth;
    }
    private void Start()
    {
        currentHealth = GetInitialEntityHealth();
    }
    public void HandleDamage(int damage)
    {
        currentHealth -= damage;

        Debug.Log(currentHealth);
        if(currentHealth <= 0)
        {
            Entity entity  = GetComponentInParent<Entity>();
            if(entity != null)
            {
                entity.gameObject.SetActive(false);
            }

        }
    }
}
