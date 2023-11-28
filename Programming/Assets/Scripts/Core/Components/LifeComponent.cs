using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class LifeComponent : CoreComponent
{
    [SerializeField] private int currentHealth;
    [SerializeField] private TextMeshProUGUI damageText;
    [SerializeField] private float displayTime = 0.2f;

    private void Start()
    {
        damageText.gameObject.SetActive(false);
    }
    public void SetInitialEntityHealth(int health)
    {
        currentHealth = health;
        damageText.gameObject.SetActive(false);
    }
    public void HandleDamage(int damage)
    {
        currentHealth -= damage;

        Entity entity = GetComponentInParent<Entity>();

        if(entity != null)
        {
            if (entity.gameObject.activeSelf)
            {                
                DisplayDamage(damage);

                if (currentHealth <= 0)
                {
                    StopAllCoroutines();
                    entity.gameObject.SetActive(false);

                    if(entity != PlayerController.Instance)
                    {
                        PlayerController.Instance.Core.Experience.AddExperience(entity.EntityData.entityExp);
                    }
                    else
                    {
                        Debug.Log("DEAD PLAYER");
                    }
                }
            }
        }


    }
    public void ResetLife()
    {

    }
    private void DisplayDamage(int damage)
    {
        damageText.text = damage.ToString();
        StartCoroutine(ShowDamage());
    }
    private IEnumerator ShowDamage()
    {
        damageText.gameObject.SetActive(true);
        yield return new WaitForSeconds(displayTime);
        damageText.gameObject.SetActive(false);
    }
}
