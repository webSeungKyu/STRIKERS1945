using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster : MonoBehaviour
{
    public float moveSpeed = 3;
    void Start()
    {
        
    }


    void Update()
    {
        //아래 방향으로 움직이기
        transform.Translate(Vector2.down * moveSpeed * Time.deltaTime);
    }

    //화면 밖으로 나갈 경우
    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
}
