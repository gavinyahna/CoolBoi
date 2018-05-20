using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuText : MonoBehaviour {

    public bool isStart;
    public bool isQuit;
    public bool isSettings;
    public bool isHovering;
    public MeshRenderer menuRenderer;
    public Material cloud;
    public Material darkCloud;
    GameObject[] settingsObjects;
    GameObject[] menuObjects;

    public static MenuText instance;
    

	// Use this for initialization
	void Start () {
        menuRenderer = GetComponent<MeshRenderer>();
        settingsObjects = GameObject.FindGameObjectsWithTag("Settings");
        menuObjects = GameObject.FindGameObjectsWithTag("Menu");
        hideSettings();
        instance = this;
        isHovering = false;
    }

    private void OnMouseOver()
    {
        menuRenderer.material = darkCloud;
        if (!isHovering)
        {
            isHovering = true;
            AudioManager.instance.PlaySound2D("Boop(hover)");
        }
        

    }

    private void OnMouseExit()
    {
        menuRenderer.material = cloud;
        isHovering = false;
    }

    private void OnMouseUp()
    {
        AudioManager.instance.PlaySound2D("Click");
        if (isStart)
        {
            SceneManager.LoadScene(MenuScript.level);
        }
        if (isQuit)
        {
            Application.Quit();
        }
        if (isSettings)
        {
            hideMenu();
            showSettings();
        }
        menuRenderer.material = cloud;
        isHovering = false;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            hideSettings();
            showMenu();
        }
    }

    public void showSettings()
    {
        foreach (GameObject obj in settingsObjects)
        {
            obj.SetActive(true);
        }
    }

    public void hideSettings()
    {
        foreach (GameObject obj in settingsObjects)
        {
            obj.SetActive(false);
        }
    }

    public void showMenu()
    {
        foreach (GameObject obj in menuObjects)
        {
            obj.SetActive(true);
        }
    }

    public void hideMenu()
    {
        foreach (GameObject obj in menuObjects)
        {
            obj.SetActive(false);
        }
    }
}
