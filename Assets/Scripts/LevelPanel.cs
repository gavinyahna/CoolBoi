using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelPanel : MonoBehaviour {
    public int thisLevel;
    public int score;
    public Sprite normal;
    public Sprite selected;
    public SpriteRenderer spriteRenderer;
    GameObject scoreObject;
    GameObject timeObject;
    GameObject lockObject;
    // Use this for initialization
    void Start() {
        scoreObject = transform.GetChild(1).gameObject;
        timeObject = transform.GetChild(2).gameObject;
        lockObject = transform.GetChild(3).gameObject;
        spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
	}

    // Update is called once per frame
    void Update() {
        if (thisLevel == MenuScript.level)
        {
            spriteRenderer.sprite = selected;
            transform.localScale = new Vector3(0.55F, 0.73f, 0);
            timeObject.SetActive(true);
        } else
        {
            spriteRenderer.sprite = normal;
            transform.localScale = new Vector3(0.46F, 0.61f, 0);
            timeObject.SetActive(false);
        }
        score = PlayerPrefs.GetInt("Score " + (thisLevel-1));
        if (score > 0)
        { 
            scoreObject.SetActive(true);
            lockObject.SetActive(false);
        }
        
	}
}
