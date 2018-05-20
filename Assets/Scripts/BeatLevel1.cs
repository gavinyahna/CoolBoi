using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BeatLevel1 : MonoBehaviour
{

    public int currentPosition;
    public float delay;
    public bool beat;
    public string message;
    public Text text;
    // Use this for initialization
    void Start()
    {
        currentPosition = 0;
        delay = .02f;
        beat = false;
        text = GetComponent<Text>();
        message = "You made it through the tutorial...";
    }

    // Update is called once per frame
    void Update()
    {
        if (beat)
        {
            StartCoroutine(write());
            beat = false;
        }
    }

    private IEnumerator write()
    {
        foreach (char letter in message.ToCharArray())
        {
            text.text += letter;
            yield return new WaitForSeconds(delay);
        }
    }


}



