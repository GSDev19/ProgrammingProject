using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Utilities;

public class GameData : MonoBehaviour
{
    public static GameData Instance { get; private set; }
    //[Header("GENERAL")]
    //public UDictionary<Element, Color> elementColors = new UDictionary<Element, Color>();

    [Space]
    [Header("ATTACKS")]
    public UDictionary<Element, Sprite> elementSprites = new UDictionary<Element, Sprite>();
    public UDictionary<Element, PrimaryData> primaryDatas = new UDictionary<Element, PrimaryData>();
    public UDictionary<Element, SecondaryData> secondaryDatas = new UDictionary<Element, SecondaryData>();
    [Space]
    [Header("ATTACK SPRITES")]
    public UDictionary<Element, Sprite> areaDamageSprites = new UDictionary<Element, Sprite>();
    public UDictionary<Element, Sprite> projectileSprites = new UDictionary<Element, Sprite>();
    [Space]
    [Header("ATTACKS MODIFIER")]
    public UDictionary<Element, float> fireDamage = new UDictionary<Element, float>();
    public UDictionary<Element, float> waterDamage = new UDictionary<Element, float>();
    public UDictionary<Element, float> plantDamage = new UDictionary<Element, float>();
    public UDictionary<Element, float> electricDamage = new UDictionary<Element, float>();
    public UDictionary<Element, float> earthDamage = new UDictionary<Element, float>();
    [Space]
    [Space]
    [Header("ENEMY SPRITES")]
    public UDictionary<int, Sprite> fireEnemies = new UDictionary<int, Sprite>();
    public UDictionary<int, Sprite> waterEnemies = new UDictionary<int, Sprite>();
    public UDictionary<int, Sprite> plantEnemies = new UDictionary<int, Sprite>();
    public UDictionary<int, Sprite> electricEnemies = new UDictionary<int, Sprite>();
    public UDictionary<int, Sprite> rockEnemies = new UDictionary<int, Sprite>();

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
    private void Start()
    {
        ResetAllDatas();
    }

    private void ResetAllDatas()
    {
        foreach (var data in primaryDatas.Values)
        {
            data.damageStat.Reset();
            data.cooldownStat.Reset();
            data.speedStat.Reset();
            data.enemyHitsStat.Reset();
            data.projectileAmountStat.Reset();
        }

        foreach (var data in secondaryDatas.Values)
        {
            data.damageStat.Reset();
            data.cooldownStat.Reset();
            data.areaSizeStat.Reset();
            data.durationStat.Reset();
            data.hitsXSecondStat.Reset();
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

    public Sprite GetAreaDamageSprite(Element element)
    {
        Sprite selected = null;
        foreach (Element key in areaDamageSprites.Keys)
        {
            if (key == element)
            {
                selected = areaDamageSprites[key];
            }
        }
        return selected;
    }

    public Sprite GetProjectileSprite(Element element)
    {
        Sprite selected = null;
        foreach (Element key in projectileSprites.Keys)
        {
            if (key == element)
            {
                selected = projectileSprites[key];
            }
        }
        return selected;
    }

    public Sprite GetEnemySprite(Element element, int level)
    {
        Sprite selectedSprite = null;

        if(element == Element.Fire)
        {
            foreach (int key in fireEnemies.Keys)
            {
                if(key == level)
                {
                    selectedSprite = fireEnemies[key];
                }
            }
        }
        else if(element == Element.Water)
        {
            foreach (int key in waterEnemies.Keys)
            {
                if (key == level)
                {
                    selectedSprite = waterEnemies[key];
                }
            }
        }
        else if (element == Element.Plant)
        {
            foreach (int key in plantEnemies.Keys)
            {
                if (key == level)
                {
                    selectedSprite = plantEnemies[key];
                }
            }
        }
        else if (element == Element.Electric)
        {
            foreach (int key in electricEnemies.Keys)
            {
                if (key == level)
                {
                    selectedSprite = electricEnemies[key];
                }
            }
        }
        else if (element == Element.Rock)
        {
            foreach (int key in rockEnemies.Keys)
            {
                if (key == level)
                {
                    selectedSprite = rockEnemies[key];
                }
            }
        }

        return selectedSprite;
    }
    //public Color GetColor(Element element)
    //{
    //    Color selected = Color.white;
    //    foreach (Element key in elementColors.Keys)
    //    {
    //        if (key == element)
    //        {
    //            selected = elementColors[key];
    //        }
    //    }
    //    return selected;
    //}    

    public float GetDamageModifier(Element attackElement, Element targetElement)
    {
        float mod = 1;
        if(attackElement == Element.Fire)
        {
            mod = GetModifierFromDictionary(fireDamage, targetElement);
        }
        else if(attackElement == Element.Water)
        {
            mod = GetModifierFromDictionary(waterDamage, targetElement);
        }
        else if(attackElement == Element.Plant)
        {
            mod = GetModifierFromDictionary(plantDamage, targetElement);
        }
        else if(attackElement == Element.Electric)
        {
            mod = GetModifierFromDictionary(electricDamage, targetElement);
        }
        else if(attackElement == Element.Rock)
        {
            mod = GetModifierFromDictionary(earthDamage, targetElement);
        }
        else
        {
            return mod;
        }
        return mod;
    }
    private float GetModifierFromDictionary(UDictionary<Element, float>  dictionary, Element targetElement)
    {
        float mod = 1f;
        foreach(Element key in dictionary.Keys)
        {
            if (key == targetElement)
            {
                mod = dictionary[key];                
            }
        }
        return mod;
    }
    //public EntityData GetEnemy1Data(Element element)
    //{
    //    EntityData selected = null;
    //    foreach (Element key in enemy1Datas.Keys)
    //    {
    //        if (key == element)
    //        {
    //            selected = enemy1Datas[key];
    //        }
    //    }
    //    return selected;
    //}
    public Element GetRandomElement(List<Element> listedElements)
    {
        if(listedElements.Count > 0)
        {
            int randomIndex = UnityEngine.Random.Range(0, listedElements.Count -1);

            return listedElements[randomIndex];
        }
        else
        {
            return Element.None;
        }
        
       
        //Element[] elements = Enum.GetValues(typeof(Element))
        //                         .Cast<Element>()
        //                         .Where(e => e != Element.None)
        //                         .ToArray();

        //int randomIndex = UnityEngine.Random.Range(0, elements.Length);

        //return elements[randomIndex];
    }
}
public enum Element
{
    Fire,
    Water,
    Plant,
    Electric,
    Rock,
    None
}
