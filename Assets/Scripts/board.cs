using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class board : MonoBehaviour
{
    public dice dice;
    public turns turns;
    public buttons buttons;

    public GameObject playerOne;
    public GameObject playerTwo;
    public GameObject playerThree;
    public GameObject playerFour;
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

    [ContextMenu("Randomly Move Player")]
    void Start()
    {
        GameObject[] playerCounterArray = new GameObject[] {playerOne,playerTwo,playerThree,playerFour};
        positionList = JsonUtility.FromJson<PositionList>(positionsJSON.text);

        turns.playerPositions[0] = Random.Range(0,40);

        Debug.Log(positionList.position[turns.playerPositions[0]].name);

        playerCounterArray[turns.currentPlayerForArrays].transform.localPosition = new Vector2(positionList.position[turns.playerPositions[0]].tileXPos,positionList.position[turns.playerPositions[0]].tileYPos);
        
    }



}
