using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Utilities;

public class GameData : MonoBehaviour
{
    public static GameData Instance { get; private set; }

    public UDictionary<Element, Sprite> elementSprites = new UDictionary<Element, Sprite>();
    public UDictionary<Element, PrimaryData> primaryDatas = new UDictionary<Element, PrimaryData>();
    public UDictionary<Element, SecondaryData> secondaryDatas = new UDictionary<Element, SecondaryData>();

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
    public PrimaryData GetPrimaryData(Element element)
    {
        PrimaryData selected = null;
        foreach (Element key in primaryDatas.Keys)
        {
            if (key == element)
            {
                selected = primaryDatas[key];
            }
        }
        return selected;
    }
    public SecondaryData GetSecondaryData(Element element)
    {
        SecondaryData selected = null;
        foreach (Element key in secondaryDatas.Keys)
        {
            if (key == element)
            {
                selected = secondaryDatas[key];
            }
        }
        return selected;
    }
}
