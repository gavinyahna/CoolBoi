using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuScript : MonoBehaviour {
    public static int level;
    public Transform[] spots;
    int[] levelScore;
    bool[] locks;
    Transform destination;
    bool moving;
    public bool reverseInputs;

	// Use this for initialization
	void Start () {
        Time.timeScale = 1;
        level = 1;
        moving = false;
        destination = spots[1];
        levelScore = new int[12];
        for(int i = 1; i < 12; i++)
        {
            levelScore[i] = PlayerPrefs.GetInt("Score " + i);
        }
        reverseInputs = false;
	}

    // Update is called once per frame
    void Update() {
        if (reverseInputs)
        {
            if ((Input.GetKeyDown(KeyCode.DownArrow) || Input.GetKeyDown(KeyCode.LeftArrow)) && level > 1)
            {
                level -= 1;
            }
            else if ((Input.GetKeyDown(KeyCode.RightArrow) || Input.GetKeyDown(KeyCode.UpArrow)) && levelScore[level] > 0)
            {
                level += 1;
            }
        } else
        {
            if ((Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.LeftArrow)) && level > 1)
            {
                level -= 1;
            }
            else if ((Input.GetKeyDown(KeyCode.RightArrow) || Input.GetKeyDown(KeyCode.DownArrow)) && levelScore[level] > 0)
            {
                level += 1;
            }
        }
        //Determines position
        if (!moving)
        {
            destination = spots[level-1];
        }
        move(destination);
        checkIfMoving();
	}

    void checkIfMoving()
    {
        moving = true;
        foreach (Transform spot in spots){
            if(transform.position == spot.position)
            {
                moving = false;
            }
        }
    }

    void move(Transform spot)
    {
        float step = 10.0f * Time.deltaTime;
        transform.position = Vector3.MoveTowards(transform.position, spot.position, step);
    }
}
