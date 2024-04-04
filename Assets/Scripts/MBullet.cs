using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MBullet : MonoBehaviour
{
    public float moveSpeed = 4f;
    void Start()
    {
        
    }

    void Update()
    {
        transform.Translate(Vector2.down * moveSpeed * Time.deltaTime);
    }

    //화면 밖으로 나갈 경우
    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }

    //충돌처리
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            //플레이어 지우기


            //미사일 지우기
            Destroy(gameObject);
        }
    }

}
