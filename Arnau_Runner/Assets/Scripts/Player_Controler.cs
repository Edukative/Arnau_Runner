using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Controler : MonoBehaviour
{
    private Rigidbody playerRB;

    public float jumpForce;
    public float GravityModifier;

    public bool IsOnGround = true;

    // Start is called before the first frame update
    void Start()
    {
        playerRB = GetComponent<Rigidbody>();
        playerRB.AddForce(Vector3.up * 500);

        Physics.gravity *= GravityModifier;
    }

    // Update is called once per frame
    void Update()
    {
      if (Input.GetKeyDown(KeyCode.Mouse0) && IsOnGround)
        {
            playerRB.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            IsOnGround = false;
        } 
    }

    private void OnCollisionEnter(Collision collision)
    {
        IsOnGround = true;
    }

}
