using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CompletionScript : MonoBehaviour {

    private Text text;
    public static int completed;
    public int setTotal;
    public static int total;

    void Start()
    {
        text = GetComponent<Text>();
        total = setTotal;
    }

    void Update()
    {
        text.text = "Completion: " + completed + "/" + total;
    }
}
