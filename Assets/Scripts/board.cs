using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class board : MonoBehaviour
{
    public dice dice;
    public turns turns;
    public UIScript uiScript;
    public UITurns uiTurns;

    public TextAsset positionsJSON;

    [System.Serializable]public class PositionInfo
    {
        public string name;
        public string type;
        public int rent;
        public int price;
        public int housePrice;
        public int rentOneHouse;
        public int rentTwoHouse;
        public int rentThreeHouse;
        public int rentFourHouse;
        public int rentHotel;
        public bool isOwned;
        public int owner;
        public int tileXPos;
        public int tileYPos;
    }

    [System.Serializable]public class PositionList
    {
        public PositionInfo[] position;
    }

    public PositionList positionList = new PositionList();

    public void Awake()
    {  
        positionList = JsonUtility.FromJson<PositionList>(positionsJSON.text);  
    }




}
