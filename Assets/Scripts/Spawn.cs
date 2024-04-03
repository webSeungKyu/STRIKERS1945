using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour
{
    public List<GameObject> monsterList;

    void Start()
    {
        InvokeRepeating("MonsterSpawn", 3f, 1f);
    }

    void Update()
    {
        
    }

    void MonsterSpawn()
    {
        Instantiate(monsterList[Random.Range(0, monsterList.Count)], new Vector2(Random.Range(-2, 3), transform.position.y), Quaternion.identity);
    }
}
