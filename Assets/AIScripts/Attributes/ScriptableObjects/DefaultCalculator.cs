using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "DefaultCalculator", menuName = "ICS_RandomAdventure/DefaultCalculator", order = 0)]
public class DefaultCalculator : CustomCalculator
{
    protected override int InternalCalculate(AttributeBase attribute, int level)
    {
        return Random.Range(attribute.min*level, attribute.max*level);
    }
}
