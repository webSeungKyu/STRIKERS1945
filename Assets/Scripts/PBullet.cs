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
        //�̻��� ���� �������� �����̱�
        //�� ���� * ���ǵ� * Ÿ��
        transform.Translate(Vector2.up * Speed * Time.deltaTime);
    }

    //ȭ�� ������ ���� ���
    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Monster"))
        {
            //������ ����
            collision.gameObject.GetComponent<Monster>().ItemDrop();
            //���� ����
            Destroy(collision.gameObject);
            //������ �ֱ�

            //����Ʈ ����

            //�Ѿ� ����
            Destroy(gameObject);


        }
    }
}
