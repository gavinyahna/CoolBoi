using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class MusicManager : MonoBehaviour
{
    public AudioClip mainTheme;
    public AudioClip menuTheme;

    public int level;
    public int currentLevel;

    void Start()
    {
        level = -1;
    }

    void Update()
    {
        currentLevel = SceneManager.GetActiveScene().buildIndex;
        if (currentLevel != level)
        {
            if(currentLevel == 0)
            {
                AudioManager.instance.PlayMusic(menuTheme);
            }
            else if (currentLevel == 1)
            {
                AudioManager.instance.PlayMusic(mainTheme);
            }
            level = currentLevel;
        }
    }
}