using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float moveSpeed = 5f;

    Animator animator;

    [Header("�Ѿ˰� �߻� ��ġ")]
    public GameObject bullet;
    public Transform pos = null;
    
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    
    void Update()
    {
        #region ������ �� �ִϸ��̼�
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

        #region �Ѿ� �߻�
        if (Input.GetKeyDown(KeyCode.Space))
        {
            //������ ��ġ ���� ����
            Instantiate(bullet, pos.position, Quaternion.identity);
        }
        #endregion

        transform.Translate(moveX, moveY, 0);
        #endregion

        #region �� ������ �� ������
        //ĳ������ ���� ��ǥ�� ����Ʈ ��ǥ��� ��ȯ���ش�.
        Vector3 viewPos = Camera.main.WorldToViewportPoint(transform.position);
        viewPos.x = Mathf.Clamp01(viewPos.x); //x���� 0�̻�, 1���Ϸ� �����Ѵ�.
        viewPos.y = Mathf.Clamp01(viewPos.y); //y���� 0�̻�, 1���Ϸ� �����Ѵ�.
        Vector3 worldPos = Camera.main.ViewportToWorldPoint(viewPos);//�ٽÿ�����ǥ�� ��ȯ
        transform.position = worldPos; //��ǥ�� �����Ѵ�.
        #endregion


    }
}
