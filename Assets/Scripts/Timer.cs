using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour {

    Text text;
    public static float timenew;

	// Use this for initialization
	void Start () {
        text = GetComponent<Text>();
        timenew = 0f;
    }
	
	// Update is called once per frame
	void Update () {

        timenew += Time.deltaTime;
        text.text = string.Format("Time: {0:#.0}", timenew);
    }
}
