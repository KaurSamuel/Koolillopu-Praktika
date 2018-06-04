using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movment_player : MonoBehaviour {

    private Rigidbody2D player_rb;
    public float speed;
    private bool grounded = false;
   // public Transform ground;
    [HideInInspector]public bool jump = false;
    [HideInInspector] public bool facingRight = true;
    public float jumpforce= 1000f;
    public float moveForce = 365f;
    public float maxSpeed = 5f;

    // Use this for initialization
    void Start () {
        player_rb = GetComponent<Rigidbody2D>();
        
	}

    // Update is called once per frame
    private void Update()
    {
        //grounded = Physics2D.Linecast(transform.position, ground.position, 1 << LayerMask.NameToLayer("Ground"));

        if (Input.GetButtonDown("Jump"))
        {
            jump = true;
        }
    }

    void FixedUpdate () {

        float H = Input.GetAxis("Horizontal");


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
        }





        //float moveHorizontal = Input.GetAxis("Horizontal");
        //float moveVertical = Input.GetAxis("Vertical");
        //Vector2 movement = new Vector2(moveHorizontal, moveVertical);
        //player_rb.AddForce(movement * speed);
    }
    void Flip()
    {
        facingRight = !facingRight;
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }
}
