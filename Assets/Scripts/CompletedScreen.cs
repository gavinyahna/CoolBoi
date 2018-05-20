using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CompletedScreen : MonoBehaviour
{


    GameObject[] pauseObjects;
    public static bool isCompleted;
    // Use this for initialization
    void Start()
    {
        //Time.timeScale = 1;
        pauseObjects = GameObject.FindGameObjectsWithTag("Completed Screen");
        isCompleted = false;
        hidePaused();
    }

    // Update is called once per frame
    void Update()
    {
        if (isCompleted)
        {
            if (Time.timeScale == 1)
            {
                FinalScore.levelCompleted = true;
                print("level Completed");
                Time.timeScale = 0;
                showPaused();
                AudioManager.instance.PlaySound2D("Finished Level");
            }
        }
    }

    public void Next()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        hidePaused();
        CompletionScript.completed = 0;
    }

    //shows objects with ShowOnPause tag
    public void showPaused()
    {
        GameObject.FindGameObjectWithTag("Genji").GetComponent<Genji>().active = false;
        foreach (GameObject obj in pauseObjects)
        {
            obj.SetActive(true);
        }
    }

    //hides objects with ShowOnPause tag
    public void hidePaused()
    {
        GameObject.FindGameObjectWithTag("Genji").GetComponent<Genji>().active = true;
        foreach (GameObject obj in pauseObjects)
        {
            obj.SetActive(false);
        }
    }
}
