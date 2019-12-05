using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn_Manager : MonoBehaviour
{
    
    private Vector3 spawnPos = new Vector3(30, 0, 0);
    private Vector3 spawnPosBarrier = new Vector3(30, 1, 4);
    public GameObject[] obstacles;
    public int obstaclesindex;
    public int obstacleDestroyedCount;

    private float startDelay = 2;
    private float repeatRate = 0.8f;

    private Player_Controler Player_ControlerScript;
    
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SpawnObstacle", startDelay, repeatRate);
        Player_ControlerScript = GameObject.Find("Player").GetComponent<Player_Controler>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void SpawnObstacle()
    {
        if (!Player_ControlerScript.isGameOver)
        {
            int obstaclesindex = Random.Range(0, obstacles.Length);
            //GameObject obstacle = Instantiate(obstacles[obstaclesindex], spawnPos, obstacles[obstaclesindex].transform.rotation);
           
            if (obstaclesindex == 2)
            {
                GameObject obstacle = Instantiate(obstacles[obstaclesindex], spawnPosBarrier, obstacles[obstaclesindex].transform.rotation);
                Move_Front obsSrcipt = obstacle.GetComponent<Move_Front>();
                obsSrcipt.speed = obsSrcipt.speed + (float)obstacleDestroyedCount;
            }
            else
            {
                GameObject obstacle = Instantiate(obstacles[obstaclesindex], spawnPos, obstacles[obstaclesindex].transform.rotation);
                Move_Left obsSrcipt = obstacle.GetComponent<Move_Left>();
                obsSrcipt.speed = obsSrcipt.speed + (float)obstacleDestroyedCount;
            }
             
        }
    }
}
