using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FinalScore : MonoBehaviour {
    public int level;
    public int lives;
    public Text score;
    public int completed;
    public static bool levelCompleted;
    int total;
    public float time;
    // Use this for initialization
    void Start()
    {
        score = GetComponent<Text>();
        completed = 0;
    }

    // Update is called once per frame
    void Update()
    {
        completed = CompletionScript.completed;
        total = CompletionScript.total;
        time = Timer.timenew;
        score.text = "You're Score: " + System.Environment.NewLine +
        completed + "/" + total + System.Environment.NewLine +
        string.Format("{0:#.00} Seconds", time);
        if (levelCompleted) {
            setFinalScore();
            levelCompleted = false;
        }
    }

    public void setFinalScore()
    {
        print("score: " + completed);
        int currentScore = PlayerPrefs.GetInt("Score " + level);
        float bestTime = PlayerPrefs.GetFloat("Time " + level);
        if(currentScore < completed)
        {
            PlayerPrefs.SetInt("Score " + level, completed);
            PlayerPrefs.SetFloat("Time " + level, time);
        } else if (currentScore == completed)
        {
            if (time < bestTime)
            {
                PlayerPrefs.SetFloat("Time " + level, time);
            }
        }
        print("Setting Score");
        for (int i = 1; i < 4; i++)
        {
            print("Score " + i + ": " + PlayerPrefs.GetInt("Score " + i));
        }
    }
}
