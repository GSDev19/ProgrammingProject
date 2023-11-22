using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Utilities;

public class GameData : MonoBehaviour
{
    public static GameData Instance { get; private set; }

    public UDictionary<Element, Sprite> elementSprites = new UDictionary<Element, Sprite>();

    private void Awake()
    {
        if (!Instance)
        {
            Instance = this;
        }
        else if (Instance != this)
        {
            Destroy(this.gameObject);
        }
    }

    public Sprite GetElementSprite(Element element)
    {
        Sprite selected = null;
        foreach (Element key in elementSprites.Keys)
        {
            if(key == element)
            {
                selected = elementSprites[key];
            }
        }
        return selected;
    }
}
