using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spanw_Manager : MonoBehaviour
{
    public GameObject obstalePrefab;
    private Vector3 spawnPos = new Vector3(35, 0, 0);

    private float startDelay = 2;
    private float repeatRate = 2;
    
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
        Instantiate(obstalePrefab, spawnPos, obstalePrefab.transform.rotation);
    }
}
