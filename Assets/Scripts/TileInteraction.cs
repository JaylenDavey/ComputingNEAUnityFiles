using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class TileInteraction : MonoBehaviour, IPointerEnterHandler
{
    public board board;
    public dice dice;
    public turns turns;
    public UIScript uiScript;
    
    public int tileNumber;

    public void OnPointerEnter(PointerEventData eventData)
    {   
        Debug.Log("Mouse is over GameObject.");
        uiScript.UpdatePropertyInformation(tileNumber);
    }   
}
