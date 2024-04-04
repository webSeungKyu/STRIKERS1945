using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Homing : MonoBehaviour
{
    GameObject target;
    public float moveSpeed = 3f;
    Vector2 dir;
    Vector2 dirNo;
    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player");

        //A - B 하면 A를 바라보는 벡터가 나옴
        dir = target.transform.transform.position - transform.position;
        //방향 벡터만 구하기 단위 벡터 1의 크기로 만들기
        dirNo = dir.normalized;

        //위는 아래로 사용 가능
        //Vector3.MoveTowards()
    }

    void Update()
    {
        transform.Translate(dirNo * moveSpeed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Destroy(gameObject);
        }
    }

    private void OnBecameInvisible()
    {
        Destroy (gameObject);
    }
}
