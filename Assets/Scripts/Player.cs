using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float moveSpeed = 5f;

    Animator animator;

    [Header("총알과 발사 위치")]
    public GameObject bullet;
    public Transform pos = null;
    
    void Start()
    {
        animator = GetComponent<Animator>();
        InvokeRepeating("ShotBullet", 1f, 0.1f);
    }

    void ShotBullet()
    {
        Instantiate(bullet, pos.position, Quaternion.identity);
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
            Instantiate(bullet, pos.position, Quaternion.identity);
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
}
