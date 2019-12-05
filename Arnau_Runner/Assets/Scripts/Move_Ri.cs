using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move_Ri : MonoBehaviour
{
    public float speed;
    private Player_Controler Player_ControlerScript;
    private float rightBound = -15;

    Spawn_Manager spawnM;

    // Start is called before the first frame update
    void Start()
    {
        Player_ControlerScript = GameObject.Find("Player").GetComponent<Player_Controler>();
        spawnM = GameObject.Find("Spawn_Manager").GetComponent<Spawn_Manager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!Player_ControlerScript.isGameOver)
        {
            transform.Translate(Vector3.right * Time.deltaTime * speed);

        }
        if (transform.position.x < rightBound && gameObject.CompareTag("Obstacle"))
        {
            spawnM.obstacleDestroyedCount++;
            Destroy(gameObject);
        }
    }
}
