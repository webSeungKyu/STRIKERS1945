using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    public float moveSpeed = 5f;

    Animator animator;

    [Header("총알과 발사 위치")]
    //public List<GameObject> bullet;
    public List<GameObject> bullet = new List<GameObject>();//미리 할당
    public List<GameObject> specialBullet = new List<GameObject>();//미리 할당
    public Transform pos = null;
    [Header("총알과 폭탄 카운트")]
    public int power = 0;
    public int bomb = 0;
    [Header("아이템 획득 이펙트")]
    public GameObject powerUpEffect;
    public GameObject powerUpMaxEffect;
    public GameObject bombUpEffect;
    [Header("에너지 폭탄 UI")]
    public Slider sliderEnergy;
    public Image imageBoom;
    public List<Sprite> imageEnergys = new List<Sprite>();//미리 할당
    public List<Sprite> imageBooms = new List<Sprite>();//미리 할당
    int energyLv = 1;

    int helperLv = 0;
    public Image helpBar;
    public bool helpOnOff = true;
    public GameObject help1;
    public GameObject help2;
    


    private void Awake()
    {
        StartCoroutine("HelpOff");
    }

    IEnumerator HelpOff()
    {
        if (energyLv == 4)
        {
            helperLv = 0;
        }
        help1.SetActive(false);
        help2.SetActive(false);
        helpBar.fillAmount = 0;

            yield return null;
    }

    public bool startShot = true;
    void Start()
    {
        sliderEnergy.value = 0;
        animator = GetComponent<Animator>();
        //InvokeRepeating("ShotBullet", 1f, 0.1f);
        InvokeRepeating("EnergyUp", 1f, 1f);
        StartCoroutine("ShotBulletCoroutine");
    }
    
    IEnumerator ShotBulletCoroutine()
    {
        while (startShot) 
        {
            yield return new WaitForSeconds(0.1f);
            Instantiate(bullet[power], pos.position, Quaternion.identity);
        }
    }

    void StartShot()
    {
        startShot = true;
        StartCoroutine("ShotBulletCoroutine");
    }
    



    void EnergyUp()
    {
        if(energyLv < 4)
        {
            sliderEnergy.value += 25;
        }
        

        if(energyLv == 1 && sliderEnergy.value >= 100)
        {
            energyLv++;
            sliderEnergy.GetComponentInChildren<CanvasRenderer>().GetComponent<Image>().sprite = imageEnergys[1];
            sliderEnergy.value = 0;
        }else if (energyLv == 2 && sliderEnergy.value >= 100)
        {
            energyLv++;
            sliderEnergy.GetComponentInChildren<CanvasRenderer>().GetComponent<Image>().sprite = imageEnergys[2];
            sliderEnergy.value = 0;
        }
        else if (energyLv == 3 && sliderEnergy.value >= 100)
        {
            energyLv++;
            sliderEnergy.GetComponentInChildren<CanvasRenderer>().GetComponent<Image>().sprite = imageEnergys[3];
            sliderEnergy.value = 0;
        }

    }

    void ShotBullet()
    {
        Instantiate(bullet[power], pos.position, Quaternion.identity);
    }

    /*IEnumerator CheckHelpLv(int lv)
    {
        switch (lv)
        {
            case 0: break;
            case 1:
                help1.SetActive(true);
                helpBar.fillAmount = 0;
                help1.GetComponent<Helper>().atkOnOff = true;
                help1.GetComponent<SpriteRenderer>().color = Color.red;
                GameObject helper1PowerUp = Instantiate(powerUpMaxEffect, transform.position, Quaternion.identity);
                yield return new WaitForSeconds(1f);
                Destroy(helper1PowerUp);
                break;
            case 2:
                help2.SetActive(true);
                helpBar.fillAmount = 0;
                help2.GetComponent<Helper>().atkOnOff = true;
                help2.GetComponent<SpriteRenderer>().color = Color.red;
                GameObject helper2PowerUp = Instantiate(powerUpMaxEffect, help2.transform.position, Quaternion.identity);
                yield return new WaitForSeconds(1f);
                Destroy(helper2PowerUp);
                break;
            default: break;
        }

        yield return null;
    }*/
    void Update()
    {
        if (helpOnOff)
        {
            helpBar.fillAmount += Time.deltaTime * 0.119f;

            if (helperLv == 2 && helpBar.fillAmount == 1)
            {
                helperLv++;
            }
            else if (helperLv == 1 && helpBar.fillAmount == 1)
            {
                helperLv++;
                help2.SetActive(true);
                helpBar.fillAmount = 0;
                help2.GetComponent<Helper>().atkOnOff = true;
            }
            else if (helperLv == 0 && helpBar.fillAmount == 1)
            {
                helperLv++;
                help1.SetActive(true);
                helpBar.fillAmount = 0;
                help1.GetComponent<Helper>().atkOnOff = true;
            }
        }
        

        #region 필살기
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (energyLv == 4)
            {
                StartCoroutine(HelpOff());
                energyLv = 1;
                GameObject newSpecialBullet = Instantiate(specialBullet[1], pos.position, Quaternion.identity);
                sliderEnergy.GetComponentInChildren<CanvasRenderer>().GetComponent<Image>().sprite = imageEnergys[0];
                
                startShot = false;//기본 총알 발사 끄기
                Invoke("StartShot", 9.7f);
                Destroy(newSpecialBullet, 9.7f);
                

            }
            else if (energyLv > 1 && energyLv <= 3 && bomb > 0)
            {   

                bomb--;
                if(bomb < 0)
                {
                    bomb = 0;
                }
                StartCoroutine("BombCheck", bomb);
                energyLv = 1;
                GameObject newSpecialBullet = Instantiate(specialBullet[0], pos.position, Quaternion.identity);
                sliderEnergy.GetComponentInChildren<CanvasRenderer>().GetComponent<Image>().sprite = imageEnergys[0];

            }

        }
        #endregion



        #region 움직임 및 애니메이션
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

/*        #region 총알 발사
        if (Input.GetKeyDown(KeyCode.Space))
        {
            //프리팹 위치 방향 생성
            Instantiate(bullet[power], pos.position, Quaternion.identity);
        }
        #endregion*/
        



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
            if (power >= 3)
            {
                power = 3;
            }

            Destroy(collision.gameObject);
        }
        if (collision.CompareTag("Bomb"))
        {
            
            bomb += 1;
            
            StartCoroutine("EffectBomb", bomb);
            StartCoroutine("BombCheck", bomb);
            if (bomb >= 5)
            {
                bomb = 5;
            }
            Destroy(collision.gameObject);
        }
    }
    IEnumerator BombCheck(int _bomb)
    {
        switch (_bomb)
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
        yield return null;
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
