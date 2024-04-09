using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public List<GameObject> gameObjects = new List<GameObject>();

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


    }

    void Start()
    {
        
    }

    public bool bossDie = false;
    void Update()
    {
        if(bossDie)
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
