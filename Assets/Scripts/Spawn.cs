using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour
{
    [Header("���� ���� x�� ó���� ��")]
    public float startX = -2;
    public float endX = 2;
    [Header("���� ���� �ð�")]
    public float startTime = 1;
    public float endTime = 10;
    //public List<GameObject> monsterList;

    [Header("���� ����ġ")]
    public bool spawnSwitch = true;
    public bool spawnSwitch2 = true;
    [Header("����")]
    [SerializeField] private GameObject monster;
    [SerializeField] private GameObject monster2;


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

            //���� ����
            Instantiate(monster, r, Quaternion.identity);
        }
    }

    IEnumerator RandomSpawn2()
    {
        while (spawnSwitch2)
        {
            yield return new WaitForSeconds(startTime +2);
            float x = Random.Range(startX, endX);
            Vector2 r = new Vector2(x, transform.position.y);

            //���� ����
            Instantiate(monster2, r, Quaternion.identity);
        }
    }

    void StopSpawn()
    {
        spawnSwitch = false;
        StopCoroutine("RandomSpawn");

        //�� ��° ����
        StartCoroutine("RandomSpawn2");
        Invoke("StopSpawn2", endTime);

    }

    void StopSpawn2()
    {
        spawnSwitch2 = false;
        StopCoroutine("RandomSpawn2");

        //���� ����
    }
    


    void Update()
    {
        
    }

    /*void MonsterSpawn()
    {
        Instantiate(monsterList[Random.Range(0, monsterList.Count)], new Vector2(Random.Range(-2, 3), transform.position.y), Quaternion.identity);
    }*/
}
