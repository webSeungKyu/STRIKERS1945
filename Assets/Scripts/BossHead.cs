using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossHead : MonoBehaviour
{

    [SerializeField] GameObject bossBullet;
    [SerializeField] GameObject bossBullet2;

    //애니메이션에서 함수 사용하기
    public void RightDownLaunch()
    {
        GameObject newBullet = Instantiate(bossBullet, transform.position, Quaternion.identity);

        newBullet.GetComponent<BossBullet>().Move(new Vector2(1, -1));
    }

    public void LeftDownLaunch()
    {
        GameObject newBullet = Instantiate(bossBullet, transform.position, Quaternion.identity);

        newBullet.GetComponent<BossBullet>().Move(new Vector2(-1, -1));
    }

    public void DownDownLaunch()
    {
        GameObject newBullet = Instantiate(bossBullet2, transform.position, Quaternion.identity);

        newBullet.GetComponent<BossBullet>().Move(new Vector2(0, -1));
    }


    
}
