using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class TitleManager : MonoBehaviour
{
    public TextMeshProUGUI startText;
    public Image blackImage;
    public Image barImage;
    bool spaceSwitch = false;
    public TextMeshProUGUI barUnderText;
    void Start()
    {
        barImage.fillAmount = 0;
        StartCoroutine("StartText", "�����Ϸ���\n[ S P A C E ]��\n�����ּ���!");
    }

    IEnumerator StartText(string text)
    {
        while (true)
        {
            startText.text = "";
            for (int i  = 0; i < text.Length; i++)
            {
                startText.text += text[i];
                yield return new WaitForSeconds(0.119f);
            }
            yield return new WaitForSeconds(1.19f);

        }
        
    }

    
    void Update()
    {
        if(Input.GetKey(KeyCode.Space) && spaceSwitch.Equals(false)) 
        {
            spaceSwitch = true;
            StartCoroutine("LoadingStart");
        }
    }

    IEnumerator LoadingStart()
    {
        
        blackImage.color = Color.black;
        barUnderText.text = "�ʺ��ڸ� ����\n ��Ű ��带 �Ѵ� ��..";
        while (barImage.fillAmount != 1 && spaceSwitch)
        {
            barImage.fillAmount += 0.97f * Time.deltaTime;
            yield return new WaitForSeconds(0.1f);
            if(barImage.fillAmount <= 0.4f && barImage.fillAmount >= 0.15f)
            {
                barUnderText.text = "��ź�� SPACE �� ����� �����մϴ�!";
            }else if(barImage.fillAmount >= 0.4f && barImage.fillAmount <= 0.6f)
            {
                barUnderText.text = "�������� ������ ä���\n SPACE�� ����������!";
            }else if(barImage.fillAmount <= 0.85f && barImage.fillAmount >= 0.6f)
            {
                barUnderText.text = "�� �����մϴ�!!";
                barImage.fillAmount += 0.15f;
            }
        }
        if (barImage.fillAmount == 1)
        {
            SceneManager.LoadScene("SampleScene");
        }

    }
}
