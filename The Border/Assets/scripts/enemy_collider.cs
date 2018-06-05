using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy_collider : MonoBehaviour
{

    public static Vector3 touched_object;
    public static bool Colexists = false;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "cactus")
        {
            Colexists = true;
            Destroy(this.gameObject);
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        Colexists = false;
        Debug.Log("Collission does not exist");
    }
}
