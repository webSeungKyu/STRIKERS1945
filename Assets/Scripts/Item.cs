using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    #region ���� ������ �Ӹ�Ƽ���� �ٿ�� ƨ��� �Ͽ����Ƿ� �Ʒ� �ڵ�� �ּ� ó��
    //public float moveSpeed = 1f;
    //Vector2 randomMove;
    #endregion
    Rigidbody2D rb = null;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.AddForce(new Vector3(Random.Range(42f, 97f), Random.Range(42f, 97f), 0f));
        #region ���� ������ �Ӹ�Ƽ���� �ٿ�� ƨ��� �Ͽ����Ƿ� �Ʒ� �ڵ�� �ּ� ó��
        /*randomMove = new Vector2(Random.Range(-1f, 2f), Random.Range(-1f, 2f));
        while (randomMove.x == 0 && randomMove.y == 0)
        {
            randomMove = new Vector2(Random.Range(-1f, 2f), Random.Range(-1f, 2f));
        }*/
        #endregion

    }

    void Update()
    {
        //���� ������ �Ӹ�Ƽ���� �ٿ�� ƨ��� �Ͽ����Ƿ� �Ʒ� �ڵ�� �ּ� ó��
        //transform.Translate(randomMove * moveSpeed * Time.deltaTime);
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        #region ���� ������ ƨ��� �±׷� ���� > ��Ƽ������ �ٿ�� ����
        //
        /*if (collision.CompareTag("LRWall"))
        {
            randomMove.x = randomMove.x * -1;
        }
        else if (collision.CompareTag("UDWall"))
        {
            randomMove.y = randomMove.y * -1;
        }*/
        #endregion

        #region ������ �Ծ��� �� > �÷��̾� ��ũ��Ʈ�� �ִ� ������ �����Ͽ���
        /*if(collision.CompareTag("Player") && gameObject.CompareTag("Power"))
        {
            Player.power++;
            Destroy(gameObject);
            Debug.Log(Player.power);
        }
        else if(collision.CompareTag("Player") && gameObject.CompareTag("Bomb"))
        {
            Player.bomb++;
            Destroy(gameObject);
            Debug.Log(Player.bomb);
        }*/
        #endregion
    }





}
