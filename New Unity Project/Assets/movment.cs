﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movment : MonoBehaviour {


    private Rigidbody2D rb2d;
    public float speed;
    // Use this for initialization
    void Start ()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }
	
	// Update is called once per frame
	void FixedUpdate ()
    {
		
	}
}
