using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EscapeButton : MonoBehaviour {

    public MeshRenderer menuRenderer;

    // Use this for initialization
    void Start () {
        menuRenderer = GetComponent<MeshRenderer>();
    }
	
	// Update is called once per frame
	void Update () {
        
    }

    private void OnMouseUp()
    {
        MenuText.instance.hideSettings();
        MenuText.instance.showMenu();
    }

    private void OnMouseOver()
    {
        menuRenderer.material.color = Color.gray;
    }

    private void OnMouseExit()
    {
        menuRenderer.material.color = Color.white;
    }
}
