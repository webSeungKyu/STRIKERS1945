using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lazer2 : MonoBehaviour
{
    public GameObject effect;
    Transform pos;
    int damage = 1;

    void Start()
    {
        pos = GameObject.Find("Player").GetComponent<Player>().pos;
        
    }

    
    void Update()
    {
        transform.position = pos.position;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Monster"))
        {
            collision.gameObject.GetComponent<Monster>().Attack(damage);
            GameObject newEffect = Instantiate(effect, collision.transform.position, Quaternion.identity);
            Destroy(newEffect, 1.19f);
        }

        if (collision.CompareTag("Boss"))
        {
            GameObject newEffect = Instantiate(effect, collision.transform.position, Quaternion.identity);
            Destroy(newEffect, 1.19f);
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Monster"))
        {
            collision.gameObject.GetComponent<Monster>().Attack(damage);
            GameObject newEffect = Instantiate(effect, collision.transform.position, Quaternion.identity);
            Destroy(newEffect, 1.19f);
        }

        if (collision.CompareTag("Boss"))
        {
            GameObject newEffect = Instantiate(effect, collision.transform.position, Quaternion.identity);
            Destroy(newEffect, 1.19f);
        }
    }
}
