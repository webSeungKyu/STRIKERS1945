using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossBullet : MonoBehaviour
{
    public float moveSpeed = 3f;
    Vector2 vec2 = Vector2.down;
    
    /// <summary>
    /// ������ �����ϴ� �Լ�
    /// </summary>
    /// <param name="vec">����</param>
    public void Move(Vector2 vec)
    {
        vec2 = vec;
    }

    void Update()
    {
        transform.Translate(vec2 * moveSpeed * Time.deltaTime);
    }

    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Destroy(gameObject);
        }
    }

}
