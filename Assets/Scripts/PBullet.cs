using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Timeline;

public class PBullet : MonoBehaviour
{
    public float Speed = 6f;
    public int damage = 10;
    public GameObject effect;
    public GameObject effect2;


    void Start()
    {
        //총알이 생성될 때마다 너무 소리가 시끄러워서 일정 확률로만 소리 나오게 조정함
        if(Random.Range(0, 3) == 1)
        {
            GameManager.Instance.AudioPlay(3);
        }
        
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
            collision.gameObject.GetComponent<Monster>().Attack(damage);
            GameObject newEffect = Instantiate(effect2, transform.position, Quaternion.identity);
            Destroy(newEffect, 1.119f);
            Destroy(gameObject);


        }

        if (collision.CompareTag("Boss"))
        {
            collision.gameObject.GetComponent<Boss>().Attack(damage);
            GameObject newEffect = Instantiate(effect, transform.position, Quaternion.identity);
            Destroy(newEffect, 0.42f);
            Destroy(gameObject);
        }
    }
}
