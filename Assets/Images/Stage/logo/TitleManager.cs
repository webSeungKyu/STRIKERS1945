using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TitleManager : MonoBehaviour
{
    public TextMeshProUGUI startText;
    void Start()
    {
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
            
        }
        
    }

    
    void Update()
    {
        
    }
}
