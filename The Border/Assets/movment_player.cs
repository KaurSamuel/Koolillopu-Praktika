using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movment_player : MonoBehaviour {

    private Rigidbody2D player_rb;
    public float speed;
	// Use this for initialization
	void Start () {
        player_rb = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");
        Vector2 movement = new Vector2(moveHorizontal, moveVertical);
        player_rb.AddForce(movement * speed);
    }
}
