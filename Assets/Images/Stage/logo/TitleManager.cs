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
        StartCoroutine("StartText", "시작하려면\n[ S P A C E ]를\n눌러주세요!");
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
        barUnderText.text = "초보자를 위한\n 루키 모드를 켜는 중..";
        while (barImage.fillAmount != 1 && spaceSwitch)
        {
            barImage.fillAmount += 0.97f * Time.deltaTime;
            yield return new WaitForSeconds(0.1f);
            if(barImage.fillAmount <= 0.4f && barImage.fillAmount >= 0.15f)
            {
                barUnderText.text = "폭탄은 SPACE 로 사용이 가능합니다!";
            }else if(barImage.fillAmount >= 0.4f && barImage.fillAmount <= 0.6f)
            {
                barUnderText.text = "게이지를 끝까지 채우고\n SPACE를 눌러보세요!";
            }else if(barImage.fillAmount <= 0.85f && barImage.fillAmount >= 0.6f)
            {
                barUnderText.text = "곧 시작합니다!!";
                barImage.fillAmount += 0.15f;
            }
        }
        if (barImage.fillAmount == 1)
        {
            SceneManager.LoadScene("SampleScene");
        }

    }
}
