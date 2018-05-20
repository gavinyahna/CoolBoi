using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextTyper : MonoBehaviour
{

    public int currentPosition;
    public float delay;
    public string message;
    public Text text;

    // Use this for initialization
    void Start()
    {
        currentPosition = 0;
        delay = .02f;
        text = GetComponent<Text>();
    }

    public IEnumerator write(string message, Text text)
    {
        foreach (char letter in message.ToCharArray())
        {
            text.text += letter;
            yield return new WaitForSeconds(delay);
        }
    }


}



