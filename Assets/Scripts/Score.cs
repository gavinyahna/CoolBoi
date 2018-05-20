using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour {
    public int level;
    public int score;
    public int possibleScore;
    TextMesh text;
    // Use this for initialization
    void Start()
    {
        text = GetComponent<TextMesh>();
    }

    // Update is called once per frame
    void Update () {
        score = PlayerPrefs.GetInt("Score " + level);
        text.text = score + "/" + possibleScore;
    }
}
