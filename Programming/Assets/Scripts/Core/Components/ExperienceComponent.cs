using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExperienceComponent : CoreComponent
{
    public int currentLevel = 0;
    public int currentExperience = 0;
    public int targetExperience = 100;
    public int targerIncreasePercentaje = 5;
    private void Start()
    {
        currentLevel = 0;
        targetExperience = 100;
        UIController.Instance.SetBarFillAmount(currentExperience, targetExperience, 0);
    }
    public void AddExperience(int experience)
    {
        currentExperience += experience;

        if (currentExperience >= targetExperience)
        {
            currentExperience = 0;
            currentLevel++;
            targetExperience += targetExperience + targetExperience * (targerIncreasePercentaje / 100);
        }

        UIController.Instance.SetBarFillAmount(currentExperience, targetExperience, currentLevel);
    }
}
