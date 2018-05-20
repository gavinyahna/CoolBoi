using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseScreen : MonoBehaviour {


    GameObject[] pauseObjects;
	// Use this for initialization
	void Start () {
        Time.timeScale = 1;
        pauseObjects = GameObject.FindGameObjectsWithTag("PauseScreen");
        hidePaused();
    }
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (Time.timeScale == 1)
            {
                Time.timeScale = 0;
                showPaused();
            }
            else if (Time.timeScale == 0)
            {
                Time.timeScale = 1;
                hidePaused();
            }
        }
    }

    public void Resume()
    {
        Time.timeScale = 1;
        hidePaused();
    }

    public void Reload()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        CompletionScript.completed = 0;
    }

    public void LoadMenu()
    {
        SceneManager.LoadScene(0);
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
