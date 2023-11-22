using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public Element projectileElement;
    [SerializeField] private List<GameObject> hitted;
    [SerializeField] private Rigidbody2D RB;
    [SerializeField] private int damage = 0;
    [SerializeField] private int currentHits = 0;
    [SerializeField] private int maxHits = 0;
    private void Awake()
    {
        RB = GetComponent<Rigidbody2D>();
        hitted = new List<GameObject>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Enemy")
        {
            Entity entity = collision.gameObject.GetComponent<Entity>();

            if(entity.currentElement != projectileElement)
            {
                LifeComponent life = entity.Core.Life;

                if (life != null && !hitted.Contains(collision.gameObject))
                {
                    hitted.Add(collision.gameObject);
                    currentHits++;
                    HandleHit(life);
                }
            }


        }
    }
    public void SetProjectile(Element element, Vector3 direction, float projectileSpeed, int dmg, int hits)
    {
        projectileElement = element;
        RB.velocity = direction * projectileSpeed;
        damage = dmg;
        currentHits = 0;
        maxHits = hits;
    }

    private void HandleHit(LifeComponent life)
    {
        life.HandleDamage(damage);

        if(currentHits >= maxHits)
        {
            gameObject.SetActive(false);
        }

    }
}
