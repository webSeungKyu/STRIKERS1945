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
    private Color originalColor;
    private SpriteRenderer spriteRenderer;
    void Start()
    {
        //한 번 함수 호출
        Invoke("CreateBullet", delay);
        spriteRenderer = GetComponent<SpriteRenderer>();
        originalColor = spriteRenderer.color;

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
    /// 공격을 받으면 체력 감소
    /// </summary>
    /// <param name="damage">int 데미지 </param>
    public void Attack(int damage)
    {
        StartCoroutine("ChangeColor");
        monsterHp -= damage;

        if(monsterHp <= 0)
        {
            ItemDrop();
            Destroy(gameObject);
        }
    }

    IEnumerator ChangeColor()
    {
        spriteRenderer.color = Color.red;
        yield return new WaitForSeconds(0.2f);
        spriteRenderer.color = originalColor;
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
