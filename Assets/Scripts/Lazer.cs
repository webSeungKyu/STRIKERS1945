using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lazer : MonoBehaviour
{
    GameObject player;
    public List<GameObject> effect = new List<GameObject>();
    void Start()
    {
        GameManager.Instance.AudioPlay(2);
        player = GameObject.FindGameObjectWithTag("Player");
    }

    private void Update()
    {
        gameObject.transform.position = new Vector2(player.transform.position.x, player.transform.position.y + 2.5f);
        

    }
    int temp = 0;
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Monster"))
        {
            Debug.Log("몬스터 스테이");
            GameManager.Instance.AudioPlay(0);
            GameManager.Instance.AudioPlay(2);

            collision.gameObject.GetComponent<Monster>().Attack(200);
            GameObject newEffect = Instantiate(effect[0], collision.transform.position, Quaternion.identity);
            Destroy(newEffect, 0.42f);



        }
        
        if (collision.CompareTag("Boss"))
        {
            GameObject miniEffect = effect[2];
            
            temp++;
            if(temp > 50) 
            {
                Debug.Log("보스 스테이");

                temp = 0;
                GameManager.Instance.AudioPlay(0);
                GameManager.Instance.AudioPlay(2);
            }

            collision.gameObject.GetComponent<Boss>().Attack(100);

            int ran = Random.Range(0, 4);
            switch (ran)
            {
                case 0: miniEffect.GetComponent<SpriteRenderer>().flipX = false;
                    break;
                case 1:
                    miniEffect.GetComponent<SpriteRenderer>().flipY = false;
                    break;
                case 2:
                    miniEffect.GetComponent<SpriteRenderer>().flipX = true;
                    break;
                case 3:
                    miniEffect.GetComponent<SpriteRenderer>().flipY = true;
                    break;
            }
            miniEffect.GetComponent<SpriteRenderer>().sortingOrder = 2;
            miniEffect.transform.localScale = new Vector3(0.5f, 0.5f);
            GameObject newEffect = Instantiate(miniEffect, collision.transform.position, Quaternion.identity);

            Destroy(newEffect, 0.42f);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("MBullet"))
        {
            Destroy(collision.gameObject);
        }
    }
}