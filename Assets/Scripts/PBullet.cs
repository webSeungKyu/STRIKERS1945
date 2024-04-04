using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PBullet : MonoBehaviour
{
    public float Speed = 6f;


    void Start()
    {
        
    }

    void Update()
    {
        //미사일 위쪽 방향으로 움직이기
        //위 방향 * 스피드 * 타임
        transform.Translate(Vector2.up * Speed * Time.deltaTime);
    }

    //화면 밖으로 나갈 경우
    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Monster"))
        {
            //아이템 생성
            collision.gameObject.GetComponent<Monster>().ItemDrop();
            //몬스터 삭제
            Destroy(collision.gameObject);
            //데미지 주기

            //이펙트 생성

            //총알 삭제
            Destroy(gameObject);


        }
    }
}
