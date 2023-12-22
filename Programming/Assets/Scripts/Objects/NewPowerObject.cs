using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewPowerObject : MonoBehaviour
{
    public static Action<Element> OnPickedNewPower;
    public Element element;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            OnPickedNewPower.Invoke(element);
            this.gameObject.SetActive(false);
        }
    }

}
