using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    public float moveSpeed = 1f;
    Vector2 randomMove;

    void Start()
    {
        randomMove = new Vector2(Random.Range(-1f, 2f), Random.Range(-1f, 2f));
        while (randomMove.x == 0 && randomMove.y == 0)
        {
            randomMove = new Vector2(Random.Range(-1f, 2f), Random.Range(-1f, 2f));
        }

    }

    void Update()
    {
        transform.Translate(randomMove * moveSpeed * Time.deltaTime);
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "LRWall")
        {
            randomMove.x = randomMove.x * -1;
        }
        else if (collision.tag == "UDWall")
        {
            randomMove.y = randomMove.y * -1;
        }

    }





}
