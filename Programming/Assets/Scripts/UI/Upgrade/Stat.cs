using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Stat
{
    public float initialValue = 0;
    public float currentValue = 0;
    public int incrementAmount = 10;
    public int level = 0;

    public Stat(float initialValue)
    {
        this.initialValue = initialValue;
        this.currentValue = initialValue;
        this.incrementAmount = 1;
        this.level = 0;
    }

    public void Reset()
    {
        currentValue = initialValue;
        level = 0;
    }
}
