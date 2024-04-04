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
    public float endTime = 20;
    //public List<GameObject> monsterList;

    [Header("���Ϳ� ���� ����ġ")]
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

            //���� ����
            Instantiate(monster, r, Quaternion.identity);
        }
    }

    void StopSpawn()
    {
        spawnSwitch = false;
        StopCoroutine("RandomSpawn");

        //�� ��° ����
    }
    


    void Update()
    {
        
    }

    /*void MonsterSpawn()
    {
        Instantiate(monsterList[Random.Range(0, monsterList.Count)], new Vector2(Random.Range(-2, 3), transform.position.y), Quaternion.identity);
    }*/
}
