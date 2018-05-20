using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shuriken : MonoBehaviour {
    public Rigidbody2D rb;
    public float xSpeed;
    public float ySpeed;
    public bool facingRight;

    public AudioClip snowSound;
	// Use this for initialization
	void Start () {
        rb = GetComponent<Rigidbody2D>();
        gameObject.tag = "Shuriken";
    }
	
	// Update is called once per frame
	void Update () {
        transform.Translate(Vector3.right * xSpeed * Time.deltaTime);
        transform.Translate(Vector3.up * ySpeed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        AudioManager.instance.PlaySound("Snowball Impact", transform.position);
        if (collider.gameObject.tag == "Enemy")
        {
            //Destroys enemy
            Destroy(collider.gameObject);
            CompletionScript.completed += 1;
        }
        if (collider.gameObject.tag != "Shuriken" && collider.gameObject.tag != "Boundary" && collider.gameObject.tag != "Genji")
        {
            Destroy(gameObject);
        }

    }
}
