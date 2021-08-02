using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[Serializable]
public class EntityClass
{
    public string Name;
    public List<string> Alignments;
}

[Serializable]
public class EntityClasses
{
    public List<EntityClass> All;
}