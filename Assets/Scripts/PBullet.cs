using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PBullet : MonoBehaviour
{
    public float Speed = 6f;
    public int damage = 10;
    public GameObject effect;
    public GameObject effect2;


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
            /*//������ ����
            collision.gameObject.GetComponent<Monster>().ItemDrop();
            //���� ����
            Destroy(collision.gameObject);*/

            //������ �ֱ�
            collision.gameObject.GetComponent<Monster>().Attack(damage);

            //����Ʈ ����
            GameObject newEffect = Instantiate(effect2, transform.position, Quaternion.identity);
            Destroy(newEffect, 1.119f);
            //�Ѿ� ����
            Destroy(gameObject);


        }

        if (collision.CompareTag("Boss"))
        {
            GameObject newEffect = Instantiate(effect, transform.position, Quaternion.identity);
            Destroy(newEffect, 0.42f);
            Destroy(gameObject);
        }
    }
}
