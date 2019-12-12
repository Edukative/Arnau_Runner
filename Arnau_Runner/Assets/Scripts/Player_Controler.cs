using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; 

public class Player_Controler : MonoBehaviour
{
    private Rigidbody playerRB;

    public float jumpForce;
    public float GravityModifier;

    public bool IsOnGround = true;
    public bool isGameOver = false;
    public bool restart = false;

    public int hp;

    private SpriteRenderer hp1;
    private SpriteRenderer hp2;
    private SpriteRenderer hp3;

    private Animator playerAim;

    public ParticleSystem explosion;
    public ParticleSystem dirt;

    private AudioSource playerAudio;

    public AudioClip jumpSound;
    public AudioClip crashSound;


    // Start is called before the first frame update
    void Start()
    {
        playerRB = GetComponent<Rigidbody>();
        playerRB.AddForce(Vector3.up * 500);

        Physics.gravity *= GravityModifier;

        playerAim = GetComponent<Animator>();
        playerAudio = GetComponent<AudioSource>();

        GameObject canvas = GameObject.Find("Canvas");
        hp1 = canvas.transform.GetChild(0).GetComponent<SpriteRenderer>();
        hp2 = canvas.transform.GetChild(1).GetComponent<SpriteRenderer>();
        hp3 = canvas.transform.GetChild(2).GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
                if (Input.GetKeyDown(KeyCode.Mouse1) && IsOnGround && !isGameOver)
        {
            playerRB.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            IsOnGround = false;

            playerAim.SetTrigger("Jump_trig");

            dirt.Stop();

            playerAudio.PlayOneShot(jumpSound);
        } 
                
                else if (isGameOver && Input.GetKeyDown(KeyCode.Space))
        {
            isGameOver = false;
            restart = true;
            hp = 4;
            LoseHP();
            playerAim.SetBool("Death_b", false);
        }
    }
    void LoseHP()
    {
        if (hp >= 0)
        {
            hp--;
            switch (hp)
            {
                case 2: hp3.gameObject.SetActive(false);
                    break;
                case 1: hp2.gameObject.SetActive(false);
                    break;
                case 0:
                    hp1.gameObject.SetActive(false);
                    isGameOver = true;

                    playerAim.SetBool("Death_b", true);
                    playerAim.SetInteger("DeathType_int", 1);

                    explosion.Play();
                    dirt.Stop();

                    playerAudio.PlayOneShot(crashSound);

                    break;
                default: hp3.gameObject.SetActive(true);
                         hp2.gameObject.SetActive(true);
                         hp1.gameObject.SetActive(true);
                    break;
            }
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))//if the player collides with yeh ground
        {
            IsOnGround = true;
            dirt.Play();
        }
        else if (collision.gameObject.CompareTag("Obstacle"))//or the player collides with an obstacle        
        {
            LoseHP();
            Destroy(collision.gameObject);
        }
    }

    
}
