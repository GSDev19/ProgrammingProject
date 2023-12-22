using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Utilities;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public UDictionary<Element, bool> unlockedElements = new UDictionary<Element, bool>();

    public int targetDiamonds = 0;
    public int currentDiamonds = 0;

    public bool gameWon = false;

    private void OnEnable()
    {
        NewPowerObject.OnPickedNewPower += HandleUnlockedElements;
    }

    private void OnDisable()
    {
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
        gameWon = false;
    }
    private void Start()
    {
        UIController.Instance.UpdateDiamondsAmount(currentDiamonds);

        if(AudioController.Instance != null)
        {
            AudioController.Instance.PlayMusic(AudioController.Instance.gameMusic);
        }
    }

    public void AddTargetDiamond()
    {
        targetDiamonds++;
        UIController.Instance.SetTargetDiamonds(targetDiamonds);
    }

    public void AddCurrentDiamond()
    {
        currentDiamonds++;
        UIController.Instance.UpdateDiamondsAmount(currentDiamonds);
        CheckIfGameWon();
    }

    public void CheckIfGameWon()
    {
        if(currentDiamonds == targetDiamonds)
        {
            gameWon = true;
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

