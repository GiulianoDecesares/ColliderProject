using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class InputController : MonoBehaviour, IPointerClickHandler, IDragHandler
{
    public void OnPointerClick(PointerEventData eventData)
    {
        // This method will be executed when clicking over the InputController object in the PlayDialog
        // Al the touch related information is in the parameter eventData

        Debug.Log("Pointer click detected");
        Debug.Log("Click position is " + eventData.position);
    }

    public void OnDrag(PointerEventData eventData)
    {
        // Same as the previous method

        Debug.Log("Pointer dragging detected");
        Debug.Log("Dragging position is " + eventData.position);
    }
}
