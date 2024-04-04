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
    public List<GameObject> items;
    public int monsterHp = 100;
    void Start()
    {
        //한 번 함수 호출
        Invoke("CreateBullet", delay);
    }

    void CreateBullet()
    {
        Instantiate(bullet, pos1.position, Quaternion.identity);
        Instantiate(bullet, pos2.position, Quaternion.identity);

        //재귀호출
        Invoke("CreateBullet", delay);
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

    /// <summary>
    /// 
    /// </summary>
    /// <param name="damage">int 데미지 </param>
    public void Attack(int damage)
    {
        monsterHp -= damage;

        if(monsterHp <= 0)
        {
            ItemDrop();
            Destroy(gameObject);
        }
    }

    /// <summary>
    /// 죽으면 아이템 생성 ( 확률 25% )
    /// </summary>
    public void ItemDrop()
    {
        int ran = Random.Range(0, 4);
        if (ran == 3)
        {
            Instantiate(items[Random.Range(0, items.Count)]);
        }
    }
    #region 주석 처리 후 플레이어 총알 스크립트에 구현함
    /*private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "PBullet")
        {
            Destroy(collision.gameObject);
            MonsterHp--;
            if (MonsterHp <= 0)
            {
                Destroy(gameObject);
                int ran = Random.Range(0, 4);
                if (ran == 3)
                {
                    Instantiate(items[Random.Range(0, items.Count)]);
                }
            }
        }

    }*/
    #endregion
}
