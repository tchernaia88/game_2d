using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public Rigidbody2D playerRigidbody2D;
    public float speed = .5f;
    public float jumpSpeed=300;
    bool isGrounded = true;
    public Animator animatorPlayer;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        playerRigidbody2D.velocity = new Vector2(Input.GetAxis("Horizontal")*speed,playerRigidbody2D.velocity.y);
        if (Input.GetAxis("Horizontal") == 0)
        {
            animatorPlayer.SetBool("isWalking",false);
        }
        else if (Input.GetAxis("Horizontal") < 0)
        {
            animatorPlayer.SetBool("isWalking", true);
            GetComponent<SpriteRenderer>().flipX = true;

        }
        else if (Input.GetAxis("Horizontal") > 0)
        {
            animatorPlayer.SetBool("isWalking", true);
            GetComponent<SpriteRenderer>().flipX = false;

        }
        if (isGrounded)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                playerRigidbody2D.AddForce(Vector2.up * jumpSpeed);
                isGrounded = false;
                animatorPlayer.SetTrigger("Jump");
            }
        }
        
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        }
    }
}
