
using System;
using UnityEngine;

public class DiamondObject : MonoBehaviour
{
    public static Action OnDiamondStart;
    public static Action OnDiamondPicked;
    private void Start()
    {
        OnDiamondStart.Invoke();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            OnDiamondPicked.Invoke();
            this.gameObject.SetActive(false);
        }
    }
}
