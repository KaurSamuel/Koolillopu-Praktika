using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraFollow : MonoBehaviour {

    public Transform Player;
    //public GameObject Player;       //Public variable to store a reference to the player game object


    public Vector3 offset;         //Private variable to store the offset distance between the player and camera
                                    
    // Use this for initialization
    void Start () {
        offset = transform.position - Player.transform.position;
    }
	
	// Update is called once per frame
	void Update () {
        transform.position = Player.transform.position+offset;
    }
}
