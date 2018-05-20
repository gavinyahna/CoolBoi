using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Script : MonoBehaviour {

    public float speed;

    // Use this for initialization
    void Start () {
        speed = 2.6f;
	}
	
	// Update is called once per frame
	void Update () {
            transform.Translate(Vector3.right * speed * Time.deltaTime);
	}

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Shuriken")
        {
            Destroy(gameObject);
        }
        if (collision.gameObject.tag == "Wall" || collision.gameObject.tag == "Enemy")
        {
            turnAround();
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Enemy" || collision.gameObject.tag == "Wall")
        {
            turnAround();
        }
    }

    private void turnAround()
    {
        speed = -1 * speed;
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }
}
