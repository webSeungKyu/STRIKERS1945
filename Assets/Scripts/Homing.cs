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

        //A - B �ϸ� A�� �ٶ󺸴� ���Ͱ� ����
        dir = target.transform.transform.position - transform.position;
        //���� ���͸� ���ϱ� ���� ���� 1�� ũ��� �����
        dirNo = dir.normalized;

        //���� �Ʒ��� ��� ����
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
