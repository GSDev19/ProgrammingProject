using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AreaDamage : MonoBehaviour
{
    public Element areaElement;
    [SerializeField] private SpriteRenderer spriteRenderer;
    [SerializeField] private List<GameObject> enemiesInside = new List<GameObject>();
    [SerializeField] private float initalSize = 5f;
    [SerializeField] private float hitXSecond = 1f;
    [SerializeField] private float duration= 1f;
    [SerializeField] private float damage = 0;

    public void SetAreaDamage(Element element, float size, float totalDuration, float rate, float dmg)
    {
        spriteRenderer.color = GameData.Instance.GetColor(element);
        areaElement = element;
        transform.localScale = Vector3.one * (initalSize + initalSize * size);
        duration = totalDuration;
        hitXSecond = 1 / rate;
        damage = dmg;
        StartCoroutine(Damage());
        StartCoroutine(DestoryAreaDamage());
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            if (!enemiesInside.Contains(collision.gameObject))
            {
                enemiesInside.Add(collision.gameObject);
            }
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            if (enemiesInside.Contains(collision.gameObject))
            {
                enemiesInside.Remove(collision.gameObject);
            }
        }
    }
    private List<GameObject> GetEnemies()
    {
        return enemiesInside;
    }
    IEnumerator Damage()
    {
        HandleDamage();
        yield return new WaitForSeconds(hitXSecond);
        StartCoroutine(Damage());
    }
    private void HandleDamage()
    {
        List<GameObject> enemiesCopy = new List<GameObject>(GetEnemies());

        foreach (GameObject obj in enemiesCopy)
        {
            if (obj != null)
            {
                Entity entity = obj.GetComponent<Entity>();

                LifeComponent life = entity.Core.Life;

                if (life != null)
                {
                    life.HandleDamage(damage, areaElement);
                }
            }
        }
    }
    private IEnumerator DestoryAreaDamage()
    {
        yield return new WaitForSeconds(duration);
        StopCoroutine(Damage());
        gameObject.SetActive(false);
    }
}
