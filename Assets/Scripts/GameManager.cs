using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public List<GameObject> gameObjects = new List<GameObject>();
    public AudioSource gameAudioSource = new AudioSource();
    public List<AudioClip> audioClipList = new List<AudioClip>();


    /// <summary>
    /// 폭탄 : 0, 아이템 : 1, 레이저 : 2, 미사일 : 3
    /// </summary>
    /// <param name="i"></param>
    public void AudioPlay(int i)
    {
        switch (i)
        {
            case 0:
                gameAudioSource.PlayOneShot(audioClipList[0]);
                break;
                case 1:
                gameAudioSource.PlayOneShot(audioClipList[1]);
                break;
            case 2:
                gameAudioSource.PlayOneShot(audioClipList[2], 0.7f);
                break;
            case 3:
                gameAudioSource.PlayOneShot(audioClipList[3]);
                break;

        }
    }

    public void StageClear(bool clear)
    {
        if (clear)
        {
            foreach (GameObject gameObject in gameObjects)
            {
                gameObject.SetActive(true);
            }
        }
        else if (!clear)
        {
            foreach (GameObject gameObject in gameObjects)
            {
                gameObject.SetActive(false);
            }

        }
    }

    
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        StageClear(false);
        GameObject.Find("BossWarning").SetActive(false);

        gameAudioSource = GetComponent<AudioSource>();
    }

    void Start()
    {
        
    }

    public bool bossDie = false;
    void Update()
    {
        if (bossDie)
        {
            StartCoroutine("PlayerNext");
            bossDie = false;
        }
        if(Input.GetKeyDown(KeyCode.R))
        {
            bossDie = true;
        }
    }
    IEnumerator PlayerNext()
    {
        yield return new WaitForSeconds(1f);
        GameObject palyer = GameObject.FindGameObjectWithTag("Player");
        palyer.GetComponent<CircleCollider2D>().enabled = false;
        palyer.transform.position = new Vector3(0, -3.5f, 0);
        palyer.transform.localScale = new Vector3(3, 3, 3);
        yield return new WaitForSeconds(2f);
        palyer.GetComponent<Rigidbody2D>().velocity = Vector3.zero;
        palyer.GetComponent<Rigidbody2D>().gravityScale = 2;
        yield return new WaitForSeconds(0.5f);
        palyer.GetComponent<Rigidbody2D>().AddForce(new Vector2(0, 42f), ForceMode2D.Impulse);
        yield return new WaitForSeconds(0.5f);
        palyer.GetComponent<SpriteRenderer>().color = new Color(0, 0, 0, 0);
        SceneManager.LoadScene("Title");
        
    }



}
