using UnityEngine;

public class CustomCalculator : ScriptableObject
{
    public Stat Calculate(AttributeBase attribute, int level)
    {
        Stat newStat = new Stat();
        newStat.Name = attribute.Name;
        newStat.Value = InternalCalculate(attribute, level);
        return newStat;
    }

    protected virtual int InternalCalculate(AttributeBase attribute, int level)
    {
        return 0;
    }
    
}