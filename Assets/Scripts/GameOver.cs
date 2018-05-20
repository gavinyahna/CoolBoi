using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameOver : MonoBehaviour {
    public int lives;
    public Text text;
    // Use this for initialization
    void Start () {
        text = GetComponent<Text>();

    }
	
	// Update is called once per frame
	void Update () {
        lives = Genji.lives;
        if (lives < 1)
        {
            text.text = "Game Over";
        }
    }
}
