using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
            Debug.Log("º¸½º »ç¸Á..!");
        }
    }

}
