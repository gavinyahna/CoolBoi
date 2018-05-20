using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimeScore : MonoBehaviour
{
    public int level;
    public float time;
    TextMesh text;
    // Use this for initialization
    void Start()
    {
        text = GetComponent<TextMesh>();
    }

    // Update is called once per frame
    void Update()
    {
        time = PlayerPrefs.GetFloat("Time " + level);
        text.text = string.Format("{0:#.00} Seconds", time);
    }
}
