using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class AttributesManager : MonoBehaviour
{
    public List<AttributeBase> Attributes;
    private static AttributesManager _instance;

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

    public List<AttributeBase> RequestAttributes()
    {
        return Attributes;
    }


}
