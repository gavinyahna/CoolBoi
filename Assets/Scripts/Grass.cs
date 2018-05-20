using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grass : MonoBehaviour
{

    public MeshRenderer grassRenderer;
    public Material grass;
    public Material ice;
    public bool done;
    public bool isShootable;

    void Start()
    {
        grassRenderer = GetComponent<MeshRenderer>();
        grassRenderer.material = grass;
        done = false;
    }

    void Update()
    {

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if ((collision.gameObject.tag == "Genji" || collision.gameObject.tag == "Shuriken" && isShootable) && !done)
        {
            grassRenderer.material = ice;
            CompletionScript.completed += 1;
            done = true;
            AudioManager.instance.PlaySound("Beep", transform.position);
        }
    }
}
