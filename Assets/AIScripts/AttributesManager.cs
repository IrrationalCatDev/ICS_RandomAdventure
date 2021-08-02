using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class AttributesManager : MonoBehaviour
{
    private Attributes LoadedAttributes;
    private static AttributesManager _instance;
    public string FilePath = "Assets/Data/Attributes.json";

    public static AttributesManager Instance
    {
        get { return _instance; }
    }

    private void Awake()
    {
        if (_instance != null && _instance != this)
        {
            Destroy(this.gameObject);
        }        
        else
        {
            _instance = this;
        }
    }

    private void LoadAttributes()
    {
        StreamReader reader = new StreamReader(FilePath);
        string json = reader.ReadToEnd();
        LoadedAttributes = JsonUtility.FromJson<Attributes>(json);
    }

    public List<AttributeBase> RequestAttributes()
    {
        if (LoadedAttributes == null)
        {
            LoadAttributes();
        }
        return LoadedAttributes.All;
    }


}
