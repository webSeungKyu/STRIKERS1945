using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster : MonoBehaviour
{
    public float moveSpeed = 1;
    public float delay = 3f;
    public Transform pos1;
    public Transform pos2;
    public GameObject bullet;
    void Start()
    {
        //�� �� �Լ� ȣ��
        Invoke("CreateBullet", delay);
    }

    void CreateBullet()
    {
        Instantiate(bullet, pos1.position, Quaternion.identity);
        Instantiate(bullet, pos2.position, Quaternion.identity);

        //���ȣ��
        Invoke("CreateBullet", delay);
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
