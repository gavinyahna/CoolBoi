using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinishBlock : MonoBehaviour {

    public float speed = 2.0f;
    private bool moveForward;

	// Use this for initialization
	void Start () {
        moveForward = false;
	}
	
	// Update is called once per frame
	void Update () {
		if(moveForward)
        {
            transform.Translate(Vector3.right * speed * Time.deltaTime);
        }
	}

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Invoke("moveForwardTrue", 1);
        CompletedScreen.isCompleted = true;
    }

    private void moveForwardTrue()
    {
        moveForward = true;
    }
}
