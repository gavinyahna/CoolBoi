using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Border : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerExit2D(Collider2D collider)
    {
        if(collider.gameObject.tag != "Genji")
        {
            GameObject.Destroy(collider.gameObject);
        }
        else
        {
            Genji.lives = 0;
        } 
    }
}
