using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class board : MonoBehaviour
{
    public dice dice;
    public turns turns;
    public tiles tiles;

    public TextAsset tilesJSON;

    [System.Serializable]
    public class Tile
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
    }

    [System.Serializable]
    public class TileList
    {
        public Tile[] tile;
    }

    public TileList tileList = new TileList();

    void Start()
    {
        tileList = JsonUtility.FromJson<TileList>(tilesJSON.text);
    }


    public int[] playerPositions = new int[] {0,0,0,0,0,0};
    public bool[] playerIsInJail = new bool[] {false,false,false,false,false,false};



}
