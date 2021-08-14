using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "AttributeBase", menuName = "ICS_RandomAdventure/AttributeBase", order = 0)]
public class AttributeBase : ScriptableObject
{
    public CustomCalculator CustomCalculator;

    public string Name;

    [HideInInspector]
    public int Value;
    public int min;
    public int max;

    public List<string> ValidEntities;
    public List<string> InvalidEntities;

    public Stat Calculate(int level)
    {
        return CustomCalculator.Calculate(this, level);
    }

    public bool IsValidForEntity(GeneratedEntity entity)
    {
        var entityType = entity.GetEntityType();
        if (ValidEntities.Count > 0 && !ValidEntities.Contains(entityType))
        {
            return false;
        }
        if (InvalidEntities.Contains(entityType))
        {
            return false;
        }
        //maybe add custom logic here?
        return true;
    }
}
