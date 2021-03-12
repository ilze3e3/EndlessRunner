using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    private Rigidbody2D rb;
    private float move;

    public float moveSpeed = 5;
    public float jumpHeight = 5;
    public float sprintMulti = 2;

    //private bool grounded;
   
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();     
    }

    // Update is called once per frame
    void Update()
    {
        move = Input.GetAxis("Horizontal") * moveSpeed;

        if (Input.GetButtonDown("Jump") /*&& grounded == true*/) //Checks if the button is pressed on that frame and "jump" is assigned to a keybinding
        {
            rb.velocity += Vector2.up * jumpHeight;

        }
        if (Input.GetKey(KeyCode.LeftShift)) //Checks if the key is pressed at all and lets you hold
        {

            move *= sprintMulti;
        }

    }
    /*
    private void FixedUpdate()
    {
        rb.velocity = new Vector2(move, rb.velocity.y);  // Easier customisation compared to manually hardcoding vector2.left and vector2.right
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            grounded = true;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            grounded = false;
        }
    }
    */
}
