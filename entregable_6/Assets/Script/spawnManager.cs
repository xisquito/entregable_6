using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawnManager : MonoBehaviour
{

    public GameObject[] bombPrefabs;
    private Vector3 spawnPosLeft;
    private Vector3 spawnPosRight;
    private float randomY;
    private float limY = 15f;
    
    
    private float startDelay = 2.5f;
    private float repeatRate = 1.5f;
    private playerController playerControllerScript;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SpawnObstacle", startDelay, repeatRate);
        playerControllerScript = GameObject.Find("Player").GetComponent<playerController>();

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SpawnRandomPrefab()
    {
        if (!playerControllerScript.gameOver)
        {
            randomY = Random.Range(0, limY);
            spawnPosRight = new Vector3(20, randomY, 0);
            spawnPosLeft = new Vector3(-20, randomY, 0);


            int randNum = Random.Range(0, 2);

            if (randNum == 0)
            {
                Instantiate(bombPrefabs[0], spawnPosLeft, bombPrefabs[0].transform.rotation);
            }

            if (randNum == 1)
            {
                Instantiate(bombPrefabs[1], spawnPosRight, bombPrefabs[1].transform.rotation);
            }
        }

    }
}
