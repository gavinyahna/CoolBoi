using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartBlock : MonoBehaviour {
    public float speed;
    public bool moving;

	// Use this for initialization
	void Start () {
        speed = 2.0f;
        moving = true;
	}
	
	// Update is called once per frame
	void Update () {
        if(moving)
        {
            transform.Translate(Vector3.right * speed * Time.deltaTime);
        }
        
	}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Wall")
        {
            moving = false;
        }
    }
}
