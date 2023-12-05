using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Utilities;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public UDictionary<Element, bool> unlockedElements = new UDictionary<Element, bool>();

    private void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
        }
        else if(Instance != this)
        {
            Destroy(this.gameObject);
        }
    }
    private void Start()
    {
        if(AudioController.Instance != null)
        {
            AudioController.Instance.PlayMusic(AudioController.Instance.gameMusic);
        }
    }

    public void HandleUnlockedElements(Element element, bool newValue)
    {
        foreach(Element key in unlockedElements.Keys)
        {
            if(key == element)
            {
                unlockedElements[key] = newValue;
            }
        }
    }
}

