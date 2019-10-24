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
    
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SpawnObstacle", startDelay, repeatRate);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void SpawnObstacle()
    {
        int obstaclesindex = Random.Range(0, obstacles.Length);
        Instantiate(obstacles[obstaclesindex], spawnPos, obstalePrefab.transform.rotation);
    }
}
