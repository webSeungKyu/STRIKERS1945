using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    public float moveSpeed = 5f;

    Animator animator;

    [Header("�Ѿ˰� �߻� ��ġ")]
    //public List<GameObject> bullet;
    public List<GameObject> bullet = new List<GameObject>();//�̸� �Ҵ�

    public Transform pos = null;
    [Header("�Ѿ˰� ��ź ī��Ʈ")]
    public int power = 0;
    public int bomb = 0;
    [Header("������ ȹ�� ����Ʈ")]
    public GameObject powerUpEffect;
    public GameObject powerUpMaxEffect;
    public GameObject bombUpEffect;
    [Header("������ ��ź UI")]
    public Image imageBoom;
    public List<Sprite> imageEnergys = new List<Sprite>();//�̸� �Ҵ�
    public List<Sprite> imageBooms = new List<Sprite>();//�̸� �Ҵ�
    





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
        #region ������ �� �ִϸ��̼�
        float moveX = moveSpeed * Time.deltaTime * Input.GetAxis("Horizontal");
        float moveY = moveSpeed * Time.deltaTime * Input.GetAxis("Vertical");

        if (Input.GetAxis("Horizontal") <= -0.5f)
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
            Instantiate(bullet[power], pos.position, Quaternion.identity);
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
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Power"))
        {
            power += 1;
            StartCoroutine("EffectPower", power);
            if (power >= 3)
            {
                power = 3;
            }

            Destroy(collision.gameObject);
        }
        if (collision.CompareTag("Bomb"))
        {

            bomb += 1;
            switch (bomb)
            {
                case 0:
                    imageBoom.color = new Color(255, 255, 255, 0);
                     break;
                case 1:
                    imageBoom.color = new Color(255, 255, 255, 255);
                    imageBoom.sprite = imageBooms[0];
                    break;
                case 2: imageBoom.sprite = imageBooms[1]; break;
                case 3: imageBoom.sprite = imageBooms[2]; break;
                case 4: imageBoom.sprite = imageBooms[3]; break;
                case 5: imageBoom.sprite = imageBooms[4]; break;
            }
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
