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
        //�� �� �Լ� ȣ��
        Invoke("CreateBullet", delay);
        spriteRenderer = GetComponent<SpriteRenderer>();
        originalColor = spriteRenderer.color;

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

    /// <summary>
    /// ������ ������ ü�� ����
    /// </summary>
    /// <param name="damage">int ������ </param>
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
    /// ������ ������ ���� ( Ȯ�� 25% )
    /// </summary>
    public void ItemDrop()
    {
        int ran = Random.Range(0, 4);
        if (ran == 3)
        {
            Instantiate(items[Random.Range(0, items.Count)]);
        }
    }
    #region �ּ� ó�� �� �÷��̾� �Ѿ� ��ũ��Ʈ�� ������
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
