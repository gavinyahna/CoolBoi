using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class ResetPopup : MonoBehaviour
{
    public GameObject[] resetObjects;
    public static int numberOfLevels;

    private void Start()
    {
        //resetObjects = GameObject.FindGameObjectsWithTag("Reset");
        hideWindow();
        numberOfLevels = 6;
    }

    // Make the contents of the window.
    public void showWindow()
    {
        print("Show");
        foreach (GameObject obj in resetObjects)
        {
            obj.SetActive(true);
            print("Show");
        }
    }

    public void hideWindow()
    {
        foreach (GameObject obj in resetObjects)
        {
            obj.SetActive(false);
        }
    }

    public void resetData()
    {
        hideWindow();
        for (int i = 1; i < numberOfLevels + 1; i++)
        {
            PlayerPrefs.SetInt("Score " + i, 0);
            PlayerPrefs.SetFloat("Time " + i, 0.0f);
        }
        SceneManager.LoadScene(0);
    }
}