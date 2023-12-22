using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ExperienceComponent : CoreComponent
{
    public static Action<SFX> OnLevelUpSound;

    [Header("EXPERIENCE")]
    [SerializeField] private int currentLevel = 0;
    [SerializeField] private int currentExperience = 0;
    [SerializeField] private int targetExperience = 50;  // Initialize with the base target experience
    [SerializeField] private int nextTargetExperience = 0;  // New variable for the next target value
    [SerializeField] private int targetIncreasePercentage = 5;

    [SerializeField] private TextMeshProUGUI addedExperienceText;
    [SerializeField] private float addedExperienceShowTime = 1f;
    [Space]
    [Header("POINTS")]
    [SerializeField] private int pointsXLevel = 10;
    public int currentPoints {  get; private set; }

    private void OnEnable()
    {
        LifeComponent.OnEntityDeath += AddExperience;
        DiamondObject.OnDiamondPicked += AddExperience;
    }

    private void OnDisable()
    {
        LifeComponent.OnEntityDeath -= AddExperience;
        DiamondObject.OnDiamondPicked -= AddExperience;
    }
    private void Start()
    {
        currentPoints = 0;
        currentLevel = 0;
        nextTargetExperience = targetExperience;

        UIController.Instance.SetBarFillAmount(currentExperience, targetExperience, 0);
        UIController.Instance.SetCurrentPoints(currentPoints);
        addedExperienceText.transform.parent.gameObject.SetActive(false);
    }
    public void AddExperience(int experience)
    {
        currentExperience += experience;
        SetAddedExperience(experience);

        while (currentExperience >= nextTargetExperience)
        {
            if (nextTargetExperience > 0)
            {
                LevelUp();
            }
            else
            {
                break;
            }
        }

        UIController.Instance.SetCurrentPoints(currentPoints);
        UIController.Instance.SetBarFillAmount(currentExperience, targetExperience, currentLevel);
    }

    private void SetAddedExperience(int exp)
    {
        StopAllCoroutines();

        addedExperienceText.transform.parent.gameObject.SetActive(true);
        addedExperienceText.text = "+ " + exp.ToString();

        StartCoroutine(ShowAddedExperience());


    }
    IEnumerator ShowAddedExperience()
    {
        yield return new WaitForSeconds(addedExperienceShowTime);
        addedExperienceText.transform.parent.gameObject.SetActive(false);
    }
    private void LevelUp()
    {
        currentExperience -= nextTargetExperience;
        currentLevel++;
        targetExperience = nextTargetExperience;
        nextTargetExperience += targetExperience * targetIncreasePercentage / 100;
        currentPoints += pointsXLevel;
        OnLevelUpSound?.Invoke(SFX.LevelUp);
    }

    public bool CheckIfHasEnoughPoints()
    {
        if(currentPoints > 0)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
    public void ExpendPoint()
    {
        if(CheckIfHasEnoughPoints())
        {
            UIController.Instance.SetCurrentPoints(currentPoints);
            currentPoints--;
        }
    }
}
