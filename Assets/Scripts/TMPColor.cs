using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TMPColor : MonoBehaviour
{
    [SerializeField]
    float lerpTime = 0.1f;
    TextMeshProUGUI textBossWarning;

    //��ü�� ��Ȱ��ȭ �Ҷ��� start�Լ�
    private void Awake()
    {
        //ĳ��
        textBossWarning = GetComponent<TextMeshProUGUI>();
    }

    //Ȱ��ȭ���Ǹ�
    private void OnEnable()
    {
        //�ڷ�ƾ ����
        StartCoroutine("ColorLerpLoop");
    }


    IEnumerator ColorLerpLoop()
    {
        while (true)
        {
            //������ �Ͼ������ ����������
            yield return StartCoroutine(ColorLerp(Color.white, Color.red));
            //������ ���������� �Ͼ������
            yield return StartCoroutine(ColorLerp(Color.red, Color.white));
        }
    }

    //�ڷ�ƾ�Լ� ������ �ε巴�� �ٲٴ� �Լ�
    IEnumerator ColorLerp(Color startColor, Color endColor)
    {
        float currentTime = 0.0f;
        float percent = 0.0f;

        while (percent < 4.2f)
        {
            //lerpTime �ð����� while()�ݺ��� ����
            currentTime += Time.deltaTime;
            percent = currentTime / lerpTime;
            //��Ʈ ������ Start���� End�� ����
            textBossWarning.color = Color.Lerp(startColor, endColor, percent);

            //���������� ��ٸ�
            yield return null;
        }
    }














}
