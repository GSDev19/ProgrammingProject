using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewPowerObject : MonoBehaviour
{
    public Element element;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            GameManager.Instance.HandleUnlockedElements(element, true);
            this.gameObject.SetActive(false);
        }
    }

}
