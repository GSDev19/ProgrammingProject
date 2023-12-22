
using System;
using UnityEngine;

public class DiamondObject : MonoBehaviour
{
    public static Action OnDiamondStart;
    public static Action<int> OnDiamondPicked;
    public static Action<SFX> OnDiamondPickedSound;

    [SerializeField] private int diamondExperience = 2000;
    private void Start()
    {
        OnDiamondStart?.Invoke();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            OnDiamondPicked?.Invoke(diamondExperience);
            OnDiamondPickedSound?.Invoke(SFX.PickDiamond);
            this.gameObject.SetActive(false);
        }
    }
}
