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
        //�Ʒ� �������� �����̱�
        transform.Translate(Vector2.down * moveSpeed * Time.deltaTime);
    }

    //ȭ�� ������ ���� ���
    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
}
