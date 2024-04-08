using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : MonoBehaviour
{
    public GameObject missile;
    public GameObject missile2;
    public Transform pos1;
    public Transform pos2;

    int flag = 1;
    int speed = 2;

    void Start()
    {
        Invoke("Hide", 1.19f);
        StartCoroutine("BossMissile");
        StartCoroutine("BossCircleMissile");
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
        //�߻�ü ���� ����
        int count = 30;
        //�߻�ü ���� ����
        float intervalAngle = 360 / count;
        //���ߵǴ� ����(�׻� ���� ��ġ�� �߻����� �ʵ��� ����)
        float weightAngle = 0f;

        //�� ���·� �߻��ϴ� �̻��� ����
        while (true)
        {
            for(int i = 0; i < count; i++)
            {
                GameObject newMissile = Instantiate(missile2, transform.position, Quaternion.identity);

                //�߻�ü �̵� ����(����)
                float angle = weightAngle + intervalAngle * i;
                //�߻�ü �̵� ����(����) 
                //Cos(����)���� ������ ���� ǥ���� ���� pi / 180�� ����
                float x = Mathf.Cos(angle * Mathf.Deg2Rad);
                //SIn(����)���� ������ ���� ǥ���� ���� pi / 100�� ����
                float y = Mathf.Sin(angle * Mathf.Deg2Rad);

                //�߻�ü �̵� ���� ����
                newMissile.GetComponent<BossBullet>().Move(new Vector2(x, y));
            }
            //�߻�ü�� �����Ǵ� ���� ���� ������ ���� ����
            weightAngle += 1;

            //4.2�ʸ��� �̻��� �߻�
            yield return new WaitForSeconds(4.2f);
        }

    }

    void Update()
    {
        #region �¿��̵�
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
