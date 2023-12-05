using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExperienceComponent : CoreComponent
{
    [Header("EXPERIENCE")]
    public int currentLevel = 0;
    public int currentExperience = 0;
    public int initialTargetExperience = 50;
    private int targetExperience = 0;
    public int targerIncreasePercentaje = 5;
    [Space]
    [Header("POINTS")]
    public int currentPoints = 0;
    public int pointsXLevel = 2;
    private void Start()
    {
        currentLevel = 0;
        targetExperience = initialTargetExperience;
        UIController.Instance.SetBarFillAmount(currentExperience, targetExperience, 0);
        UIController.Instance.SetCurrentPoints(currentPoints);
    }
    public void AddExperience(int experience)
    {
        currentExperience += experience;

        if (currentExperience >= targetExperience)
        {
            currentExperience = 0;
            currentLevel++;
            initialTargetExperience += targetExperience + targetExperience * (targerIncreasePercentaje / 100);
            currentPoints += pointsXLevel;
        }
        UIController.Instance.SetCurrentPoints(currentPoints);
        UIController.Instance.SetBarFillAmount(currentExperience, targetExperience, currentLevel);
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
