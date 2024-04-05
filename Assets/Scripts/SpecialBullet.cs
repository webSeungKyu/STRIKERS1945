using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpecialBullet : MonoBehaviour
{
    [SerializeField][Range(1.19f, 4.2f)] float Speed;
    public int damage = 119;
    public GameObject effect;

    void Start()
    {
        Invoke("DestroyMe", 9.7f);
    }

    void DestroyMe()
    {
        Destroy(gameObject);
    }

    void Update()
    {
        transform.Translate(Vector2.up * Speed * Time.deltaTime);
        //transform.Rotate(new Vector3(0, Speed, 402f * Time.deltaTime)); 회전을 넣어봤지만, 이상하므로 주석처리..
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Monster"))
        {
            collision.gameObject.GetComponent<Monster>().Attack(damage);
            GameObject newEffect = Instantiate(effect, transform.position, Quaternion.identity);
            Destroy(newEffect, 1f);
            Destroy(gameObject);
        }
        if (collision.CompareTag("Boss"))
        {
            GameObject newEffect = Instantiate(effect, transform.position, Quaternion.identity);
            StartCoroutine("EffectCoroutine", newEffect);
            newEffect.GetComponent<SpriteRenderer>().color = new Color(255, 255, 255, 0);
            Destroy(newEffect, 0.42f);
            Destroy(gameObject, 0.42f);
        }

    }

    IEnumerator EffectCoroutine(GameObject gameObject)
    {
        GameObject newEffect1 = Instantiate(gameObject, new Vector3(transform.position.x + 0.42f, transform.position.y + 0.42f, 0), Quaternion.identity);
        GameObject newEffect2 = Instantiate(gameObject, new Vector3(transform.position.x + 0.42f, transform.position.y - 0.42f, 0), Quaternion.identity);
        GameObject newEffect3 = Instantiate(gameObject, new Vector3(transform.position.x - 0.42f, transform.position.y + 0.42f, 0), Quaternion.identity);
        GameObject newEffect4 = Instantiate(gameObject, new Vector3(transform.position.x - 0.42f, transform.position.y - 0.42f, 0), Quaternion.identity);
        yield return new WaitForSeconds(0.3f);
        gameObject.GetComponent<SpriteRenderer>().color = new Color(255, 255, 255, 255);    
        Destroy(newEffect1, 0.42f);
        Destroy(newEffect2, 0.42f);
        Destroy(newEffect3, 0.42f);
        Destroy(newEffect4, 0.42f);

    }
}
