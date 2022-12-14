using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class board : MonoBehaviour
{
    public dice dice;
    public turns turns;

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
    }

    [System.Serializable]public class PositionList
    {
        public PositionInfo[] position;
    }

    public PositionList positionList = new PositionList();

    [ContextMenu("Randomly Move Player")]
    void Start()
    {
        positionList = JsonUtility.FromJson<PositionList>(positionsJSON.text);

        turns.playerPositions[0] = Random.Range(0,40);
        Debug.Log(positionList.position[turns.playerPositions[0]].name);
    }



}
