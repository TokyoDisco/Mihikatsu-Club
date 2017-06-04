using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class OnMouseTrigger : MonoBehaviour, IPointerEnterHandler,IPointerExitHandler{
    public GameObject Selector;
    public Vector3 MoveTo;
    public bool isOver;

    public void OnPointerEnter(PointerEventData eventData)
    {
        Selector.SetActive(true);
        Selector.GetComponent<Transform>().position = MoveTo;
        
        isOver = true;
    }

    public void OnPointerExit(PointerEventData eventData)
    {

        Selector.SetActive(false);
        isOver = false;
    }
}
