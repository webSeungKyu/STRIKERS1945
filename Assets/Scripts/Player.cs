using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float moveSpeed = 5f;

    Animator animator;

    [Header("총알과 발사 위치")]
    //public List<GameObject> bullet;
    public List<GameObject> bullet = new List<GameObject>();//미리 할당

    public Transform pos = null;
    [Header("총알과 폭탄 카운트")]
    public int power = 0;
    public int bomb = 0;
    [Header("아이템 획득 이미지")]
    public GameObject powerUpEffect;
    public GameObject powerUpMaxEffect;
    public GameObject bombUpEffect;






    void Start()
    {
        animator = GetComponent<Animator>();
        InvokeRepeating("ShotBullet", 1f, 0.1f);
    }

    void ShotBullet()
    {
        Instantiate(bullet[power], pos.position, Quaternion.identity);
    }
    
    void Update()
    {
        #region 움직임 및 애니메이션
        float moveX = moveSpeed * Time.deltaTime * Input.GetAxis("Horizontal");
        float moveY = moveSpeed * Time.deltaTime * Input.GetAxis("Vertical");

        if(Input.GetAxis("Horizontal") <= -0.5f)
        {
            animator.SetBool("left", true);
        }
        else
        {
            animator.SetBool("left", false);
        }

        if (Input.GetAxis("Horizontal") >= 0.5f)
        {
            animator.SetBool("right", true);
        }
        else
        {
            animator.SetBool("right", false);
        }

        if (Input.GetAxis("Vertical") >= 0.5f)
        {
            animator.SetBool("up", true);
        }
        else
        {
            animator.SetBool("up", false);
        }

        #region 총알 발사
        if (Input.GetKeyDown(KeyCode.Space))
        {
            //프리팹 위치 방향 생성
            Instantiate(bullet[power], pos.position, Quaternion.identity);
        }
        #endregion

        transform.Translate(moveX, moveY, 0);
        #endregion

        #region 맵 밖으로 못 나가게
        //캐릭터의 월드 좌표를 뷰포트 좌표계로 변환해준다.
        Vector3 viewPos = Camera.main.WorldToViewportPoint(transform.position);
        viewPos.x = Mathf.Clamp01(viewPos.x); //x값을 0이상, 1이하로 제한한다.
        viewPos.y = Mathf.Clamp01(viewPos.y); //y값을 0이상, 1이하로 제한한다.
        Vector3 worldPos = Camera.main.ViewportToWorldPoint(viewPos);//다시월드좌표로 변환
        transform.position = worldPos; //좌표를 적용한다.
        #endregion


    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Power"))
        {
            power += 1;
            StartCoroutine("EffectPower", power);
            if(power >= 3)
            {
                power = 3;
            }

            Destroy(collision.gameObject);
        }
        if (collision.CompareTag("Bomb"))
        {
            bomb += 1;
            StartCoroutine("EffectBomb", bomb);
            if (bomb >= 5)
            {
                bomb = 5;
            }
            Destroy(collision.gameObject);
        }
    }

    IEnumerator EffectPower(int power)
    {
        GameObject powerUpEffectNew;
        if (power >= 3)
        {
            powerUpEffectNew = Instantiate(powerUpMaxEffect, transform.position, Quaternion.identity);
        }
        else
        {
            powerUpEffectNew = Instantiate(powerUpEffect, transform.position, Quaternion.identity);
        }

        yield return new WaitForSeconds(1f);
        Destroy(powerUpEffectNew);
    }
    IEnumerator EffectBomb(int bomb)
    {
        GameObject bombUpEffectNew = Instantiate(bombUpEffect, transform.position, Quaternion.identity);
        yield return new WaitForSeconds(1f);
        Destroy(bombUpEffectNew);
    }

}
