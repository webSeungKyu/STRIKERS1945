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

    //ȭ�� ������ ���� ���
    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }

    //�浹ó��

}
