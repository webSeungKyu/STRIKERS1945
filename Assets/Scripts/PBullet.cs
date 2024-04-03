using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PBullet : MonoBehaviour
{
    public float Speed = 4.0f;


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
}
