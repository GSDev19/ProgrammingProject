using System.Collections;

[System.Serializable]
public class AttackStat 
{
    public float initialValue = 0;
    public float currentValue = 0;
    public float incrementPercentaje = 0.1f;
    public int incrementAmount = 1;
    public int timesIncremented = 0;

    public AttackStat(float initialValue)
    {
        this.initialValue = initialValue;
        this.currentValue = initialValue;
        this.incrementPercentaje = 0.1f;
        this.incrementAmount = 1;
        this.timesIncremented = 0;
    }

    public void Reset()
    {
        currentValue = initialValue;
        timesIncremented = 0;
    }

}
