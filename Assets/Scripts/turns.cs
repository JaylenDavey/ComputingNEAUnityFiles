using UnityEngine;

public class turns : MonoBehaviour
{
    public dice dice;
    public board board;
    public UIScript uiScript;


    public int totalPlayers = 4;
    public int currentPlayerTurn = 1;
    public int currentPlayerForArrays = 0;

    public int[] playerPositions = new int[] {0,0,0,0};
    public bool[] playerIsInJail = new bool[] {false,false,false,false};
    public int[] playerMoney = new int[] {1500,1500,1500,1500};
    public bool[] playerHasLost = new bool[] {false,false,false,false};

    public int[] brownSetOwnership = new int[] {0,0,0,0};
    public int[] blueSetOwnership = new int[] {0,0,0,0};
    public int[] pinkSetOwnership = new int[] {0,0,0,0};
    public int[] orangeSetOwnership = new int[] {0,0,0,0};
    public int[] redSetOwnership = new int[] {0,0,0,0};
    public int[] yellowSetOwnership = new int[] {0,0,0,0};
    public int[] greenSetOwnership = new int[] {0,0,0,0};
    public int[] purpleSetOwnership = new int[] {0,0,0,0};
    public int[] stationOwnership = new int[] {0,0,0,0};
    public int[] UtilityOwnership = new int[] {0,0,0,0};



    string DetermineColourSet(int tileNumber)
    {
        if(board.positionList.position[tileNumber].colour == "Brown")
        {
            return "Brown";
        }
        if(board.positionList.position[tileNumber].colour == "Blue")
        {
            return "Blue";
        }
        if(board.positionList.position[tileNumber].colour == "Pink")
        {
            return "Pink";
        }
        if(board.positionList.position[tileNumber].colour == "Orange")
        {
            return "Orange";
        }        if(board.positionList.position[tileNumber].colour == "Red")
        {
            return "Red";
        }
        if(board.positionList.position[tileNumber].colour == "Yellow")
        {
            return "Yellow";
        }
        if(board.positionList.position[tileNumber].colour == "Green")
        {
            return "Green";
        }
        if(board.positionList.position[tileNumber].colour == "Purple")
        {
            return "Purple";
        }
        if(board.positionList.position[tileNumber].colour == "Station")
        {
            return "Station";
        }
        if(board.positionList.position[tileNumber].colour == "Utility")
        {
            return "Utility";
        }
        else return null;
    }

    void AddColourSet(int tileNumber, int playerToAddTo)
    {
        if(board.positionList.position[tileNumber].colour == "Brown")
        {
            brownSetOwnership[playerToAddTo] ++;
        }
        if(board.positionList.position[tileNumber].colour == "Blue")
        {
            blueSetOwnership[playerToAddTo] ++;
        }
        if(board.positionList.position[tileNumber].colour == "Pink")
        {
            pinkSetOwnership[playerToAddTo] ++;
        }
        if(board.positionList.position[tileNumber].colour == "Orange")
        {
            orangeSetOwnership[playerToAddTo] ++;
        }
        if(board.positionList.position[tileNumber].colour == "Red")
        {
            redSetOwnership[playerToAddTo] ++;
        }
        if(board.positionList.position[tileNumber].colour == "Yellow")
        {
            yellowSetOwnership[playerToAddTo] ++;
        }
        if(board.positionList.position[tileNumber].colour == "Green")
        {
            greenSetOwnership[playerToAddTo] ++;
        }
        if(board.positionList.position[tileNumber].colour == "Purple")
        {
            purpleSetOwnership[playerToAddTo] ++;
        }
        if(board.positionList.position[tileNumber].colour == "Station")
        {
            stationOwnership[playerToAddTo] ++;
        }
        if(board.positionList.position[tileNumber].colour == "Utility")
        {
            UtilityOwnership[playerToAddTo] ++;
        }
    }

}
