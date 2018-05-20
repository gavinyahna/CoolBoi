using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;

public class ButtonSounds: MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerUpHandler
{

    public bool isHovering;


    // Use this for initialization
    void Start()
    {
        isHovering = false;
    }

    public void OnPointerEnter(PointerEventData data)
    {
        if (!isHovering)
        {
            isHovering = true;
            AudioManager.instance.PlaySound2D("Boop(hover)");
        }
    }

    public void OnPointerExit(PointerEventData data)
    {
        isHovering = false;
    }

    public void OnPointerUp(PointerEventData data)
    {
        AudioManager.instance.PlaySound2D("Click");
    }
}
