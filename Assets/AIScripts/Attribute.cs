using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[Serializable]
public class Attribute
{
    public string Name;
    public int Value;
    public void Convert(AttributeBase other, int level)
    {
        other.Calculate(level);
        Name = other.Name;
        Value = other.Value;
    }
}

[Serializable]
public class AttributeBase
{
    public string Name;
    public int Value;
    public string Class;
    public int min;
    public int max;
    public void Calculate(int level)
    {
        Value = UnityEngine.Random.Range(min*level,max*level);
    }
}

[Serializable]
public class Attributes
{
    public List<AttributeBase> All;
}