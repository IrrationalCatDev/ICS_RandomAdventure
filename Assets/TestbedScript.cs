using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestbedScript : MonoBehaviour
{
    public Object AdventurerPrefab;
    public Object EnemyPrefab;
    // Start is called before the first frame update
    void Start()
    {
        GeneratedEntity.InstantiateEntity(AdventurerPrefab,this.gameObject,1);
        GeneratedEntity.InstantiateEntity(EnemyPrefab,this.gameObject,1);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
