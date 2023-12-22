using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class LifeComponent : CoreComponent
{
    public static Action OnPlayerDeath;
    public static Action<int> OnEntityDeath;
    public static Action<SFX> OnEntityDeathSound;

    [SerializeField] private float currentHealth;
    [SerializeField] private Image damageImage;
    [SerializeField] private TextMeshProUGUI damageText;
    [SerializeField] private float displayTime = 0.2f;


    [SerializeField] private float maxHealth;
    [SerializeField] private Image lifeBar;

    private void Start()
    {
        damageText.gameObject.SetActive(false);
        damageImage.gameObject.SetActive(false);

    }
    public void SetInitialEntityHealth(float health)
    {
        maxHealth = health;
        currentHealth = maxHealth;
        SetLifeBar();
        damageText.gameObject.SetActive(false);
        damageImage.gameObject.SetActive(false);
    }
    public void HandleDamage(float damage, Element attackElement)
    {
        int dmg = (int)damage * (int)GameData.Instance.GetDamageModifier(attackElement, Core.Entity.currentElement);
        currentHealth -= dmg;

        Entity entity = Core.Entity;

        if(entity != null)
        {
            if (entity.gameObject.activeSelf)
            {                
                DisplayDamage(dmg);
                SetLifeBar();

                if (currentHealth <= 0)
                {
                    currentHealth = 0;
                    StopAllCoroutines();
                    entity.gameObject.SetActive(false);

                    if (entity != PlayerController.Instance)
                    {
                        OnEntityDeath?.Invoke(Core.Entity.EntityData.entityExp);
                        OnEntityDeathSound?.Invoke(SFX.KillEnemy);
                    }
                    else
                    {
                        OnPlayerDeath?.Invoke();

                        UIController.Instance.ShowDeadPanel(true);
                    }
                }
            }
        }


    }

    private void SetLifeBar()
    {
        if(lifeBar != null)
        {
            lifeBar.gameObject.SetActive(true);
            float value = (float)currentHealth / (float)maxHealth;

            if(currentHealth >= maxHealth * 0.5f)
            {
                lifeBar.color = Color.green;
            }
            else if(currentHealth < maxHealth * 0.5f && currentHealth >= maxHealth * 0.3f)
            {
                lifeBar.color = Color.yellow;
            }
            else
            {
                lifeBar.color = Color.red;
            }

            lifeBar.fillAmount = value;
        }
    }
    private void DisplayDamage(int damage)
    {
        damageImage.gameObject.SetActive(true);
        damageText.text = damage.ToString();
        StartCoroutine(ShowDamage());
    }
    private IEnumerator ShowDamage()
    {
        damageText.gameObject.SetActive(true);
        damageImage.gameObject.SetActive(true);
        yield return new WaitForSeconds(displayTime);
        damageText.gameObject.SetActive(false);
        damageImage.gameObject.SetActive(false);
    }
}
