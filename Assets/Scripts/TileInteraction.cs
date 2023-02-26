using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class TileInteraction : MonoBehaviour, IPointerEnterHandler, IPointerClickHandler
{
    public UIScript uiScript;
    public board board;
    public UITurns UITurns;

    public Text houseNumberText;
    
    public int tileNumber;

    private void Start()
    {
        houseNumberText = GetComponentInChildren<Text>();
        if(board.positionList.position[tileNumber].type == "Property")
        {
            StartCoroutine("UpdatePropertyText");
        }
        else
        {
            houseNumberText.text = "";
        }
    }

    public void OnPointerEnter(PointerEventData eventData)
    {   
        uiScript.UpdateInformationUI(tileNumber);
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        UITurns.selectedTile = tileNumber;
        Debug.Log(tileNumber + " Selected: " + board.positionList.position[tileNumber].name);
    }


    IEnumerator UpdatePropertyText()
    {
        while(true)
        {
            if(board.positionList.position[tileNumber].housesNumber==0)
            {
                houseNumberText.text = "";
                yield return new WaitForSeconds(0.05f);
            }
            else
            {
                houseNumberText.text = board.positionList.position[tileNumber].housesNumber.ToString();
                yield return new WaitForSeconds(0.05f);
            }

        }
    }
    
}
