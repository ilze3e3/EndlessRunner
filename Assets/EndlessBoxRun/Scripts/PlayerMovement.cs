using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    private Rigidbody2D rb;
    private float move;

    public float moveSpeed = 0;
    public float jumpHeight = 0;

    public bool player_dead = false;
   
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();     
        rb.constraints = RigidbodyConstraints2D.FreezePositionX | RigidbodyConstraints2D.FreezePositionY;
    }

    // Update is called once per frame
    void Update()
    {
        if (!player_dead)
        {
            move = Input.GetAxis("Horizontal") * moveSpeed;

            if (Input.GetButtonDown("Jump") /*&& grounded == true*/) //Checks if the button is pressed on that frame and "jump" is assigned to a keybinding
            {
                rb.velocity += Vector2.up * jumpHeight;

            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("Hit Rock");
        player_dead = true;
        GetComponent<Animator>().enabled = false;
    }

    public bool IsPlayerDead()
    {
        return player_dead;
    }

    public void IsGameStart(bool gs)
    {
        if(gs)
        {
            moveSpeed = 5;
            jumpHeight = 5;
            rb.constraints = RigidbodyConstraints2D.FreezePositionX;
        }
        if (!gs)
        {
            moveSpeed = 0;
            jumpHeight = 0;
            rb.constraints = RigidbodyConstraints2D.FreezePositionX | RigidbodyConstraints2D.FreezePositionY;
        }
    }
}
