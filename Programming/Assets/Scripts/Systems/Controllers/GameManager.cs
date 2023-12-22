using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Utilities;

public class GameManager : MonoBehaviour
{
    public static Action<Music> OnGameStarted;

    public static GameManager Instance;
    public UDictionary<Element, bool> unlockedElements = new UDictionary<Element, bool>();

    public int targetDiamonds = 0;
    public int currentDiamonds = 0;

    private void OnEnable()
    {
        DiamondObject.OnDiamondStart += HandleDiamondStart;
        DiamondObject.OnDiamondPicked += HandleDiamondPicked;

        NewPowerObject.OnPickedNewPower += HandleUnlockedElements;
    }

    private void OnDisable()
    {

        DiamondObject.OnDiamondStart -= HandleDiamondStart;
        DiamondObject.OnDiamondPicked -= HandleDiamondPicked;

        NewPowerObject.OnPickedNewPower -= HandleUnlockedElements;
    }

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

        targetDiamonds = 0;
        currentDiamonds = 0;
    }
    private void Start()
    {
        UIController.Instance.UpdateDiamondsAmount(currentDiamonds);

        OnGameStarted?.Invoke(Music.GameMusic);

    }

    public void HandleDiamondStart()
    {
        targetDiamonds++;
        UIController.Instance.SetTargetDiamonds(targetDiamonds);
    }

    public void HandleDiamondPicked()
    {
        currentDiamonds++;
        UIController.Instance.UpdateDiamondsAmount(currentDiamonds);
        CheckIfGameWon();
    }

    private void CheckIfGameWon()
    {
        if(currentDiamonds == targetDiamonds)
        {
            UIController.Instance.ShowWinPanel(true);
        }
    }
    public void HandleUnlockedElements(Element element)
    {
        foreach(Element key in unlockedElements.Keys)
        {
            if(key == element)
            {
                unlockedElements[key] = true;
            }
        }
    }
}

