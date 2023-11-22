using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Utilities;

public class GameData : MonoBehaviour
{
    public static GameData Instance { get; private set; }
    [Header("GENERAL")]
    public UDictionary<Element, Color> elementColors = new UDictionary<Element, Color>();

    [Space]
    [Header("ATTACKS")]
    public UDictionary<Element, Sprite> elementSprites = new UDictionary<Element, Sprite>();
    public UDictionary<Element, PrimaryData> primaryDatas = new UDictionary<Element, PrimaryData>();
    public UDictionary<Element, SecondaryData> secondaryDatas = new UDictionary<Element, SecondaryData>();

    [Space]
    [Header("ENEMIES")]
    public UDictionary<Element, EntityData> enemy1Datas = new UDictionary<Element, EntityData>();

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
    public Color GetColor(Element element)
    {
        Color selected = Color.white;
        foreach (Element key in elementColors.Keys)
        {
            if (key == element)
            {
                selected = elementColors[key];
            }
        }
        return selected;
    }    

    public EntityData GetEnemy1Data(Element element)
    {
        EntityData selected = null;
        foreach (Element key in enemy1Datas.Keys)
        {
            if (key == element)
            {
                selected = enemy1Datas[key];
            }
        }
        return selected;
    }
    public Element GetRandomElement()
    {
        Element[] elements = Enum.GetValues(typeof(Element))
                                 .Cast<Element>()
                                 .Where(e => e != Element.None)
                                 .ToArray();

        int randomIndex = UnityEngine.Random.Range(0, elements.Length);

        return elements[randomIndex];
    }
}
public enum Element
{
    Fire,
    Water,
    Plant,
    Electric,
    Earth,
    None
}
