using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lazer : MonoBehaviour
{
    GameObject player;
    public List<GameObject> effect;
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    private void Update()
    {
        gameObject.transform.position = new Vector2(player.transform.position.x, player.transform.position.y + 2.5f);
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Monster"))
        {

            collision.gameObject.GetComponent<Monster>().Attack(200);
            GameObject newEffect = Instantiate(effect[0], collision.transform.position, Quaternion.identity);
            Destroy(newEffect, 0.42f);



        }

        if (collision.CompareTag("Boss"))
        {
            GameObject newEffect = Instantiate(effect[1], collision.transform.position, Quaternion.identity);
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