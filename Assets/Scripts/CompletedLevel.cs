using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class CompletedLevel : MonoBehaviour {

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {

	}

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Finish")
        {
            GetComponent<Genji>().active = false;

            Invoke("StartLevel2", 3);
        }
    }

    private void StartLevel2()
    {
        SceneManager.LoadScene(2);
    }
}
