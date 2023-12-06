using System.Collections;
using System.Collections.Generic;
using System.Xml.Linq;
using UnityEngine;

public class DiamondObject : MonoBehaviour
{
    private void Start()
    {
        GameManager.Instance.AddTargetDiamond();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            GameManager.Instance.AddCurrentDiamond();
            this.gameObject.SetActive(false);
        }
    }
}
