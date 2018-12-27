using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeverState : MonoBehaviour {
    public Sprite up;
    public Sprite down;
    public SpriteRenderer spriteRenderer;
    public GameObject block;
    private bool rotate;
    private int angle;
    public int maxAngle;
    public int direction;
    public float speed;

	// Use this for initialization
	void Start () {
        spriteRenderer.sprite = up;
        rotate = false;
        angle = 0;
        maxAngle = 90;
        speed *= direction;
	}
	
	// Update is called once per frame
	void Update () {
		if(rotate == true && angle < maxAngle)
        {
            block.transform.Rotate(0, 0, speed);
            angle++;
        }
	}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        spriteRenderer.sprite = down;
        rotate = true;
    }
}
