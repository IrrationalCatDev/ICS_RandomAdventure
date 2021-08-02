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
        entity.Initialize(level);
        a.transform.parent = parent.transform;
    }

    public void Initialize(int level)
    {
        Class = GenerateClass();
        //load possible attributes
        var possibleAttributes = AttributesManager.Instance.RequestAttributes();
        //generate value for attribute
        for (int i = 0; i < possibleAttributes.Count; ++i)
        {
            //filter attributes based on class/level/alignment etc.
            Attribute newAttribute = new Attribute();
            newAttribute.Convert(possibleAttributes[i],level);
            Attributes.Insert(Attributes.Count,newAttribute);
        }

    }

    public abstract string GetClassFile();

    public EntityClass GenerateClass()
    {
        StreamReader reader = new StreamReader(GetClassFile());
        string json = reader.ReadToEnd();
        var allClasses = JsonUtility.FromJson<EntityClasses>(json);
        return allClasses.All[Random.Range(0,allClasses.All.Count)];
    }

    public EntityClass Class;

    public List<Attribute> Attributes;


}