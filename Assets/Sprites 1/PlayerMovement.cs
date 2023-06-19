using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public Rigidbody2D playerRigidbody2D;
    public float speed = .5f;
    public float jumpSpeed=300;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        playerRigidbody2D.velocity = new Vector2(Input.GetAxis("Horizontal")*speed,playerRigidbody2D.velocity.y);
        if (Input.GetKeyDown(KeyCode.Space))
        {
            playerRigidbody2D.AddForce(Vector2.up * jumpSpeed);
        }
    }
}
