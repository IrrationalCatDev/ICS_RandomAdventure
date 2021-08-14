using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public abstract class GeneratedEntity : MonoBehaviour 
{
    public static void InstantiateEntity(Object prefab, GameObject parent, int level)
    {
        var a = Instantiate(prefab) as GameObject;
        var entity = a.GetComponent<GeneratedEntity>();
        entity.Level = level;
        entity.Initialize();
        a.transform.parent = parent.transform;
    }

    public void Initialize()
    {
        Class = GenerateClass();
        //load possible attributes
        var possibleAttributes = AttributesManager.Instance.RequestAttributes();
        //filter attributes based on class/level/alignment etc.
        var filteredAttributes = possibleAttributes.FindAll(x => x.IsValidForEntity(this));
        //generate value for attribute
        foreach (var possibleAttribute in filteredAttributes)
        {
            var level = Level;
            var stat = possibleAttribute.Calculate(level);
            Attributes.Insert(Attributes.Count,stat);
        }
    }

    public abstract string GetEntityType();

    public EntityClass GenerateClass()
    {
        return new EntityClass();
    }

    public EntityClass Class;

    public List<Stat> Attributes = new List<Stat>();

    public int Level;


}