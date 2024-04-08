using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.PlayerSettings;

public class Helper : MonoBehaviour
{
    public GameObject bullet;
    public bool atkOnOff = false;
    private float atkSpeed = 0.42f;
    void Start()
    {
        atkSpeed = 0.42f;
        StartCoroutine("ShotBulletCoroutine", atkSpeed);
        atkOnOff = false;
    }
    IEnumerator ShotBulletCoroutine(float speed)
    {
        while (true)
        {
            yield return new WaitForSeconds(speed);
            Instantiate(bullet, gameObject.transform.position, Quaternion.identity);
        }
    }

    void Update()
    {
        if (atkOnOff)
        {
            StartCoroutine("ShotBulletCoroutine", 0.1);
            gameObject.GetComponent<SpriteRenderer>().color = Color.red;
            atkOnOff = false;
        }
    }

}
