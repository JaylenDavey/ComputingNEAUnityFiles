using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class TileInteraction : MonoBehaviour, IPointerEnterHandler, IPointerClickHandler
{
    public UIScript uiScript;
    public board board;
    public UITurns UITurns;
    
    public int tileNumber;

    public void OnPointerEnter(PointerEventData eventData)
    {   
        uiScript.UpdateInformationUI(tileNumber);
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        UITurns.selectedTile = tileNumber;
        Debug.Log(tileNumber + " Selected: " + board.positionList.position[tileNumber].name);
    }   
}
