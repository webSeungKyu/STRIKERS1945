using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour
{
    [Header("몬스터 생성 x값 처음과 끝")]
    public float startX = -2;
    public float endX = 2;
    [Header("몬스터 생성 시간")]
    public float startTime = 1;
    public float endTime = 20;
    //public List<GameObject> monsterList;

    [Header("몬스터와 생성 스위치")]
    [SerializeField] private GameObject monster;
    public bool spawnSwitch = true;
    
    void Start()
    {
        StartCoroutine("RandomSpawn");
        Invoke("StopSpawn", endTime);
        //InvokeRepeating("MonsterSpawn", 3f, 1f);
    }

    IEnumerator RandomSpawn()
    {
        while (spawnSwitch)
        {
            yield return new WaitForSeconds(startTime);
            float x = Random.Range(startX, endX);
            Vector2 r = new Vector2 (x, transform.position.y);

            //몬스터 생성
            Instantiate(monster, r, Quaternion.identity);
        }
    }

    void StopSpawn()
    {
        spawnSwitch = false;
        StopCoroutine("RandomSpawn");

        //두 번째 몬스터
    }
    


    void Update()
    {
        
    }

    /*void MonsterSpawn()
    {
        Instantiate(monsterList[Random.Range(0, monsterList.Count)], new Vector2(Random.Range(-2, 3), transform.position.y), Quaternion.identity);
    }*/
}
