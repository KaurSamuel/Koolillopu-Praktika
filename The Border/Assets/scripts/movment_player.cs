﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movment_player : MonoBehaviour {

    private Rigidbody2D player_rb;
    public float speed;
    //public bool grounded = false;
    public Transform groundCheck;
    [HideInInspector] public bool jump = false;
    [HideInInspector] public bool facingRight = true;
    public float jumpforce = 1000f;
    public float moveForce = 365f;
    public float maxSpeed = 5f;
    public float jumptimer = 1;
    [HideInInspector] public float jumptimeruptate;
    bool isgrounded = true;
    private bool grounded = false;
    Animator anim;
    public static bool Colexists = false;
    



    // Use this for initialization
    void Start() {
        player_rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        jumptimeruptate = jumptimer;
    }

    // Update is called once per frame
    private void Update()
    {

        grounded = Physics2D.Linecast(transform.position, groundCheck.position, 1 << LayerMask.NameToLayer("Ground"));
        jumptimeruptate -= Time.deltaTime;
        if (Input.GetButtonDown("Jump") && jumptimeruptate < 0)
        {
            jump = true;
            jumptimeruptate = jumptimer;
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag=="enemy")
        {
            Destroy(this);
        }
    }
    void FixedUpdate() { 

        float H = Input.GetAxis("Horizontal");
        anim.SetFloat("speed", Mathf.Abs(H));

        if (H * player_rb.velocity.x < maxSpeed)
            player_rb.AddForce(Vector2.right * H * moveForce);

        if (Mathf.Abs(player_rb.velocity.x) > maxSpeed)
            player_rb.velocity = new Vector2(Mathf.Sign(player_rb.velocity.x) * maxSpeed, player_rb.velocity.y);

        if (H > 0 && !facingRight)
            Flip();
        else if (H < 0 && facingRight)
            Flip();


        if (jump)
        {

            player_rb.AddForce(new Vector2(0f, jumpforce));
            jump = false;
            // jumpforce = 1000f;
        }
    }
    
    void Flip()
    {
        facingRight = !facingRight;
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }
}
