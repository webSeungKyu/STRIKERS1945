using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    #region 벽에 닿으면 머리티얼의 바운스로 튕기게 하였으므로 아래 코드는 주석 처리
    //public float moveSpeed = 1f;
    //Vector2 randomMove;
    #endregion
    Rigidbody2D rb = null;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.AddForce(new Vector3(Random.Range(42f, 97f), Random.Range(42f, 97f), 0f));
        #region 벽에 닿으면 머리티얼의 바운스로 튕기게 하였으므로 아래 코드는 주석 처리
        /*randomMove = new Vector2(Random.Range(-1f, 2f), Random.Range(-1f, 2f));
        while (randomMove.x == 0 && randomMove.y == 0)
        {
            randomMove = new Vector2(Random.Range(-1f, 2f), Random.Range(-1f, 2f));
        }*/
        #endregion

    }

    void Update()
    {
        //벽에 닿으면 머리티얼의 바운스로 튕기게 하였으므로 아래 코드는 주석 처리
        //transform.Translate(randomMove * moveSpeed * Time.deltaTime);
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        #region 벽에 닿으면 튕기기 태그로 구현 > 머티리얼의 바운스로 수정
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

        #region 아이템 먹었을 때 > 플레이어 스크립트에 넣는 것으로 수정하였음
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
