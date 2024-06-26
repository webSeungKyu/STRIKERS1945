using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : MonoBehaviour
{
    public GameObject missile;
    public GameObject missile2;
    public Transform pos1;
    public Transform pos2;
    public GameObject dieEffect;
    int flag = 1;
    int speed = 2;
    public int bossHp = 30000;
    private Color originalColor;
    private SpriteRenderer spriteRenderer;

    void Start()
    {
        Invoke("Hide", 1.19f);
        StartCoroutine("BossMissile");
        StartCoroutine("BossCircleMissile");
        spriteRenderer = GetComponent<SpriteRenderer>();
        originalColor = spriteRenderer.color;

    }
    IEnumerator Die()
    {
        for (int i = 0; i < 10; i++)
        {
            GameObject effect = Instantiate(dieEffect, new Vector2(
                transform.position.x + Random.Range(-1f, 1f), transform.position.y + Random.Range(-1f, 1f)), Quaternion.identity);
            yield return new WaitForSeconds(0.2f);
            Destroy(effect);

        }
        yield return new WaitForSeconds(0.2f);
        GameManager.Instance.StageClear(true);
        GameManager.Instance.bossDie = true;
        Destroy(gameObject);
    }



    void Hide()
    {
        GameObject.Find("BossWarning").SetActive(false);
    }

    IEnumerator BossMissile()
    {
        while (true)
        {
            Instantiate(missile, pos1.position, Quaternion.identity);
            Instantiate(missile, pos2.position, Quaternion.identity);
            yield return new WaitForSeconds(0.97f);
        }
    }

    IEnumerator BossCircleMissile()
    {
        //발사체 생성 개수
        int count = 30;
        //발사체 간격 각도
        float intervalAngle = 360 / count;
        //가중되는 각도(항상 같은 위치로 발사하지 않도록 설정)
        float weightAngle = 0f;

        //원 형태로 발사하는 미사일 생성
        while (true)
        {
            for(int i = 0; i < count; i++)
            {
                GameObject newMissile = Instantiate(missile2, transform.position, Quaternion.identity);

                //발사체 이동 방향(각도)
                float angle = weightAngle + intervalAngle * i;
                //발사체 이동 방향(벡터) 
                //Cos(각도)라디안 단위의 각도 표현을 위해 pi / 180을 곱함
                float x = Mathf.Cos(angle * Mathf.Deg2Rad);
                //SIn(각도)라디안 단위의 각도 표현을 위해 pi / 100을 곱함
                float y = Mathf.Sin(angle * Mathf.Deg2Rad);

                //발사체 이동 방향 설정
                newMissile.GetComponent<BossBullet>().Move(new Vector2(x, y));
            }
            //발사체가 생성되는 시작 각도 설정을 위한 변수
            weightAngle += 1;

            //4.2초마다 미사일 발사
            yield return new WaitForSeconds(4.2f);
        }

    }
    public void Attack(int damage)
    {
        StartCoroutine("ChangeColor");
        bossHp -= damage;

        if (bossHp <= 0)
        {
            StartCoroutine("Die");
        }
    }
    IEnumerator ChangeColor()
    {
        spriteRenderer.color = Color.red;
        yield return new WaitForSeconds(0.1f);
        spriteRenderer.color = originalColor;
    }

    void Update()
    {

        #region 좌우이동
        if (transform.position.x > 0.6)
        {
            flag *= -1;
        }
        if(transform.position.x < -0.6)
        {
            flag *= -1;
        }

        transform.Translate(flag * speed * Time.deltaTime, 0, 0);
        #endregion
    }
}
