using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spanw_Manager : MonoBehaviour
{
    public GameObject obstalePrefab;
    private Vector3 spawnPos = new Vector3(30, 0, 0);
    public GameObject[] obstacles;
    public int obstaclesindex;

    private float startDelay = 1.5f;
    private float repeatRate = 0.7f;

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
            Instantiate(obstacles[obstaclesindex], spawnPos, obstalePrefab.transform.rotation);
        }
    }
}
