using UnityEngine;

public class turns : MonoBehaviour
{
    public board board;

    public int totalPlayers = 4;
    public int currentPlayerTurn = 1;
    public int currentPlayerForArrays = 0;

    public int[] playerPositions = new int[] {0,0,0,0};
    public bool[] playerIsInJail = new bool[] {false,false,false,false};
    public int[] playerMoney = new int[] {1500,1500,1500,1500};
    public bool[] playerHasLost = new bool[] {false,false,false,false};
    public bool[] playerHasGetOutOfJailFreeCard = new bool[] {false, false, false, false};

    public int[] playerTotalHouses = new int[] {0,0,0,0};
    public int[] playerTotalHotels = new int[] {0,0,0,0};

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



    public string DetermineColourSet(int tileNumber)
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

    public void AddColourSet(int tileNumber, int playerToEdit)
    {
        if(board.positionList.position[tileNumber].colour == "Brown")
        {
            brownSetOwnership[playerToEdit] ++;
        }
        if(board.positionList.position[tileNumber].colour == "Blue")
        {
            blueSetOwnership[playerToEdit] ++;
        }
        if(board.positionList.position[tileNumber].colour == "Pink")
        {
            pinkSetOwnership[playerToEdit] ++;
        }
        if(board.positionList.position[tileNumber].colour == "Orange")
        {
            orangeSetOwnership[playerToEdit] ++;
        }
        if(board.positionList.position[tileNumber].colour == "Red")
        {
            redSetOwnership[playerToEdit] ++;
        }
        if(board.positionList.position[tileNumber].colour == "Yellow")
        {
            yellowSetOwnership[playerToEdit] ++;
        }
        if(board.positionList.position[tileNumber].colour == "Green")
        {
            greenSetOwnership[playerToEdit] ++;
        }
        if(board.positionList.position[tileNumber].colour == "Purple")
        {
            purpleSetOwnership[playerToEdit] ++;
        }
        if(board.positionList.position[tileNumber].colour == "Station")
        {
            stationOwnership[playerToEdit] ++;
        }
        if(board.positionList.position[tileNumber].colour == "Utility")
        {
            UtilityOwnership[playerToEdit] ++;
        }
    }

    public void RemoveColourSet(int tileNumber, int playerToEdit)
    {
        if(board.positionList.position[tileNumber].colour == "Brown")
        {
            brownSetOwnership[playerToEdit] --;
        }
        if(board.positionList.position[tileNumber].colour == "Blue")
        {
            blueSetOwnership[playerToEdit] --;
        }
        if(board.positionList.position[tileNumber].colour == "Pink")
        {
            pinkSetOwnership[playerToEdit] --;
        }
        if(board.positionList.position[tileNumber].colour == "Orange")
        {
            orangeSetOwnership[playerToEdit] --;
        }
        if(board.positionList.position[tileNumber].colour == "Red")
        {
            redSetOwnership[playerToEdit] --;
        }
        if(board.positionList.position[tileNumber].colour == "Yellow")
        {
            yellowSetOwnership[playerToEdit] --;
        }
        if(board.positionList.position[tileNumber].colour == "Green")
        {
            greenSetOwnership[playerToEdit] --;
        }
        if(board.positionList.position[tileNumber].colour == "Purple")
        {
            purpleSetOwnership[playerToEdit] --;
        }
        if(board.positionList.position[tileNumber].colour == "Station")
        {
            stationOwnership[playerToEdit] --;
        }
        if(board.positionList.position[tileNumber].colour == "Utility")
        {
            UtilityOwnership[playerToEdit] --;
        }
    }

    public bool PlayerOwnsEntireSet(int tileNumber, int playerToCheck)
    {
        if(board.positionList.position[tileNumber].colour == "Brown" && brownSetOwnership[playerToCheck] == 2)
        {
            return true;
        }
        if(board.positionList.position[tileNumber].colour == "Blue" && blueSetOwnership[playerToCheck] == 3)
        {
            return true;
        }
        if(board.positionList.position[tileNumber].colour == "Pink" && pinkSetOwnership[playerToCheck] == 3)
        {
            return true;
        }
        if(board.positionList.position[tileNumber].colour == "Orange" && brownSetOwnership[playerToCheck] == 3)
        {
            return true;
        }
        if(board.positionList.position[tileNumber].colour == "Red" && redSetOwnership[playerToCheck] == 3)
        {
            return true;
        }
        if(board.positionList.position[tileNumber].colour == "Yellow" && yellowSetOwnership[playerToCheck] == 3)
        {
            return true;
        }
        if(board.positionList.position[tileNumber].colour == "Green" && greenSetOwnership[playerToCheck] == 3)
        {
            return true;
        }
        if(board.positionList.position[tileNumber].colour == "Purple" && purpleSetOwnership[playerToCheck] == 2)
        {
            return true;
        }
        else return false;
    }

}
