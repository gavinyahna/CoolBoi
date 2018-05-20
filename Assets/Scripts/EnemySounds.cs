using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySounds : MonoBehaviour {
    public int counter;
    SpriteRenderer spriteRenderer;

    private void Start()
    {
        counter = 0;
        spriteRenderer = GetComponent<SpriteRenderer>();
    }
    // Update is called once per frame
    void Update () {
        counter++;
        if(spriteRenderer.sprite.name == "Attack1_3" && counter > 5)
        {
            AudioManager.instance.PlaySound("Sword Swing", transform.position);
            counter = 0;
        }
	}
}
