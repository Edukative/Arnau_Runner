using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Controler : MonoBehaviour
{
    private Rigidbody playerRB;

    public float jumpForce;
    public float GravityModifier;

    public bool IsOnGround = true;
    public bool isGameOver = false;

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

            explosion.Play();
            isGameOver = true; 
            Debug.Log("Game Over you noob");
            playerAim.SetBool("Death_b", true);
            playerAudio.PlayOneShot(crashSound);
            playerAim.SetInteger("DeathType_int", 1);
        }
    }

}
