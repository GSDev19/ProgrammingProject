using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class LifeComponent : CoreComponent
{
    [SerializeField] private float currentHealth;
    [SerializeField] private Image damageImage;
    [SerializeField] private TextMeshProUGUI damageText;
    [SerializeField] private float displayTime = 0.2f;

    private void Start()
    {
        damageText.gameObject.SetActive(false);
        damageImage.gameObject.SetActive(false);
    }
    public void SetInitialEntityHealth(float health)
    {
        currentHealth = health;
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

                if (currentHealth <= 0)
                {
                    currentHealth = 0;
                    StopAllCoroutines();
                    entity.gameObject.SetActive(false);

                    if (AudioController.Instance != null)
                    {
                        AudioController.Instance.PlaySound(AudioController.Instance.killEnemy);
                    }

                    if (entity != PlayerController.Instance)
                    {
                        
                        PlayerController.Instance.Core.Experience.AddExperience(Core.Enemy1.data.entityExp);
                    }
                    else
                    {
                        Debug.Log("DEAD PLAYER");
                    }
                }
            }
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
