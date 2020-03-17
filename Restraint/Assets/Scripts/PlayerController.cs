using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float movespeed = 10;

    float horizontal, vertical;

    Animator playerAnim;
    Rigidbody2D body;

    void Start()
    {
        body = GetComponent<Rigidbody2D>();
        playerAnim = GetComponent<Animator>();
    }

    void Update()
    {
        horizontal = Input.GetAxisRaw("Horizontal");
        vertical = Input.GetAxisRaw("Vertical");

        // Animator = Setting a float between 1 and -1 for X and Y
        playerAnim.SetFloat("MoveX", body.velocity.x);
        playerAnim.SetFloat("MoveY", body.velocity.y);

        if (Input.GetAxisRaw("Horizontal") == 1 || Input.GetAxisRaw("Horizontal") == -1 || Input.GetAxisRaw("Vertical") == 1 || Input.GetAxisRaw("Vertical") == -1)
        {
            playerAnim.SetFloat("LastMoveX", Input.GetAxisRaw("Horizontal"));
            playerAnim.SetFloat("LastMoveY", Input.GetAxisRaw("Vertical"));
        }
    }

    private void FixedUpdate()
    {
        body.velocity = new Vector2(horizontal, vertical) * movespeed * Time.deltaTime;
    }
}
