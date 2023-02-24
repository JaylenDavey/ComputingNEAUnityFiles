using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UITurns : MonoBehaviour
{
    public turns turns;
    public dice dice;
    public board board;
    public UIScript uiScript;

    public Text playerTurn;

    public GameObject[] playerCounters;

    public int selectedTile;

    public void Awake()
    {
        GameObject playerOne = GameObject.Find("PlayerCounter 1");
        GameObject playerTwo = GameObject.Find("PlayerCounter 2");
        GameObject playerThree = GameObject.Find("PlayerCounter 3");
        GameObject playerFour = GameObject.Find("PlayerCounter 4");

        playerCounters = new GameObject[] {playerOne, playerTwo, playerThree, playerFour};
    }

    public void EndTurn()
    {
        turns.currentPlayerTurn ++;
        if(turns.currentPlayerTurn == 5)turns.currentPlayerTurn=1;
        turns.currentPlayerForArrays = turns.currentPlayerTurn - 1;
        playerTurn.text = "Player " + turns.currentPlayerTurn.ToString();

        Debug.Log(turns.currentPlayerTurn.ToString() + turns.currentPlayerForArrays.ToString()); 
    }

    public void RollDice()
    {
        int diceroll = dice.RollDice();
        turns.playerPositions[turns.currentPlayerForArrays] += diceroll;
        if(turns.playerPositions[turns.currentPlayerForArrays] > 39)
        {
            turns.playerPositions[turns.currentPlayerForArrays] -= 40;
            turns.playerMoney[turns.currentPlayerForArrays] += 200;
            uiScript.MoneyInterfaceUpdater();
        }
        playerCounters[turns.currentPlayerForArrays].transform.localPosition = new Vector2(board.positionList.position[turns.playerPositions[turns.currentPlayerForArrays]].tileXPos,board.positionList.position[turns.playerPositions[turns.currentPlayerForArrays]].tileYPos);

        if(GetTileType() == "Property")
        {
            if(TileIsOwnedByAnotherPlayer())
            {
                ChargeRent();
                uiScript.MoneyInterfaceUpdater();
            }
        }
        if(GetTileType() == "Station")
        {
            Debug.Log("Landed On Station");
            if(TileIsOwnedByAnotherPlayer())
            {
                Debug.Log("Landed On Owned Station");
                ChargeStationRent();
                uiScript.MoneyInterfaceUpdater();
            }
        }

        if(GetTileType() == "Tax")
        {
            turns.playerMoney[turns.currentPlayerForArrays] -= board.positionList.position[turns.playerPositions[turns.currentPlayerForArrays]].rent;
            uiScript.MoneyInterfaceUpdater();

        }  
    }

    public void BuyProperty()
    {
        if(turns.playerMoney[turns.currentPlayerForArrays]>=board.positionList.position[turns.playerPositions[turns.currentPlayerForArrays]].price && !board.positionList.position[turns.playerPositions[turns.currentPlayerForArrays]].isOwned)
        {
            Debug.Log("Bought");
            board.positionList.position[turns.playerPositions[turns.currentPlayerForArrays]].isOwned = true;
            board.positionList.position[turns.playerPositions[turns.currentPlayerForArrays]].owner = turns.currentPlayerTurn;
            turns.playerMoney[turns.currentPlayerForArrays] -= board.positionList.position[turns.playerPositions[turns.currentPlayerForArrays]].price;
            turns.AddColourSet(turns.playerPositions[turns.currentPlayerForArrays], turns.currentPlayerForArrays);

            uiScript.MoneyInterfaceUpdater();

        }
        if(board.positionList.position[turns.playerPositions[turns.currentPlayerForArrays]].isOwned)
        {
            Debug.Log("Is Owned");
        }
        if(board.positionList.position[turns.playerPositions[turns.currentPlayerForArrays]].price > turns.playerMoney[turns.currentPlayerForArrays])
        {
            Debug.Log("Poor Bastard");
        }
    }

    public void UpgradeProperty()
    {
        if(UpgradeRequirementsCheck())
        {
            turns.playerMoney[turns.currentPlayerForArrays] -= board.positionList.position[selectedTile].price;
            board.positionList.position[selectedTile].housesNumber ++;
            uiScript.MoneyInterfaceUpdater();
        }
    }

    string GetTileType()
    {
        string type = board.positionList.position[turns.playerPositions[turns.currentPlayerForArrays]].type;

        return type;
    }

    bool UpgradeRequirementsCheck() // Checks if the player owns the tile and its set, and checks if the player can afford to upgrade, as well as checking if the tile has less than 5 houses.
    {
        if(board.positionList.position[selectedTile].owner == turns.currentPlayerTurn && turns.PlayerOwnsEntireSet(selectedTile, turns.currentPlayerForArrays) && turns.playerMoney[turns.currentPlayerForArrays] > board.positionList.position[selectedTile].housePrice && board.positionList.position[selectedTile].housesNumber < 5)return true;
        else return false;
    }





    int NumberOfHouses()
    {
        return board.positionList.position[turns.playerPositions[turns.currentPlayerForArrays]].housesNumber;
    }

    int NumberOfOwnedStations()
    {
        return turns.stationOwnership[board.positionList.position[turns.playerPositions[turns.currentPlayerForArrays]].owner - 1];
    }

    bool TileIsOwnedByAnotherPlayer()
    {
        return board.positionList.position[turns.playerPositions[turns.currentPlayerForArrays]].isOwned && board.positionList.position[turns.playerPositions[turns.currentPlayerForArrays]].owner != turns.currentPlayerTurn;
    }

    void ChargeStationRent()
    {
                Debug.Log("Attempting To Charge Rent");
                Debug.Log(NumberOfOwnedStations());
                if(NumberOfOwnedStations() == 1)
                {
                    turns.playerMoney[turns.currentPlayerForArrays] -= board.positionList.position[turns.playerPositions[turns.currentPlayerForArrays]].rentOneHouse;
                    turns.playerMoney[board.positionList.position[turns.playerPositions[turns.currentPlayerForArrays]].owner - 1] += board.positionList.position[turns.playerPositions[turns.currentPlayerForArrays]].rentOneHouse;
                }
                if(NumberOfOwnedStations() == 2)
                {
                    turns.playerMoney[turns.currentPlayerForArrays] -= board.positionList.position[turns.playerPositions[turns.currentPlayerForArrays]].rentTwoHouse;
                    turns.playerMoney[board.positionList.position[turns.playerPositions[turns.currentPlayerForArrays]].owner - 1] += board.positionList.position[turns.playerPositions[turns.currentPlayerForArrays]].rentTwoHouse;
                }
                if(NumberOfOwnedStations() == 3)
                {
                    turns.playerMoney[turns.currentPlayerForArrays] -= board.positionList.position[turns.playerPositions[turns.currentPlayerForArrays]].rentThreeHouse;
                    turns.playerMoney[board.positionList.position[turns.playerPositions[turns.currentPlayerForArrays]].owner - 1] += board.positionList.position[turns.playerPositions[turns.currentPlayerForArrays]].rentThreeHouse;
                }
                if(NumberOfOwnedStations() == 4)
                {
                    turns.playerMoney[turns.currentPlayerForArrays] -= board.positionList.position[turns.playerPositions[turns.currentPlayerForArrays]].rentFourHouse;
                    turns.playerMoney[board.positionList.position[turns.playerPositions[turns.currentPlayerForArrays]].owner - 1] += board.positionList.position[turns.playerPositions[turns.currentPlayerForArrays]].rentFourHouse;
                }     
    }

    void ChargeRent()
    {
                if(NumberOfHouses() == 0)
                {
                    turns.playerMoney[turns.currentPlayerForArrays] -= board.positionList.position[turns.playerPositions[turns.currentPlayerForArrays]].rent;
                    turns.playerMoney[board.positionList.position[turns.playerPositions[turns.currentPlayerForArrays]].owner - 1] += board.positionList.position[turns.playerPositions[turns.currentPlayerForArrays]].rent;
                }
                if(NumberOfHouses() == 1)
                {
                    turns.playerMoney[turns.currentPlayerForArrays] -= board.positionList.position[turns.playerPositions[turns.currentPlayerForArrays]].rentOneHouse;
                    turns.playerMoney[board.positionList.position[turns.playerPositions[turns.currentPlayerForArrays]].owner - 1] += board.positionList.position[turns.playerPositions[turns.currentPlayerForArrays]].rentOneHouse;
                }
                if(NumberOfHouses() == 2)
                {
                    turns.playerMoney[turns.currentPlayerForArrays] -= board.positionList.position[turns.playerPositions[turns.currentPlayerForArrays]].rentTwoHouse;
                    turns.playerMoney[board.positionList.position[turns.playerPositions[turns.currentPlayerForArrays]].owner - 1] += board.positionList.position[turns.playerPositions[turns.currentPlayerForArrays]].rentTwoHouse;
                }
                if(NumberOfHouses() == 3)
                {
                    turns.playerMoney[turns.currentPlayerForArrays] -= board.positionList.position[turns.playerPositions[turns.currentPlayerForArrays]].rentThreeHouse;
                    turns.playerMoney[board.positionList.position[turns.playerPositions[turns.currentPlayerForArrays]].owner - 1] += board.positionList.position[turns.playerPositions[turns.currentPlayerForArrays]].rentThreeHouse;
                }
                if(NumberOfHouses() == 4)
                {
                    turns.playerMoney[turns.currentPlayerForArrays] -= board.positionList.position[turns.playerPositions[turns.currentPlayerForArrays]].rentFourHouse;
                    turns.playerMoney[board.positionList.position[turns.playerPositions[turns.currentPlayerForArrays]].owner - 1] += board.positionList.position[turns.playerPositions[turns.currentPlayerForArrays]].rentFourHouse;
                }
                if(NumberOfHouses() == 5)
                {
                    turns.playerMoney[turns.currentPlayerForArrays] -= board.positionList.position[turns.playerPositions[turns.currentPlayerForArrays]].rentHotel;
                    turns.playerMoney[board.positionList.position[turns.playerPositions[turns.currentPlayerForArrays]].owner - 1] += board.positionList.position[turns.playerPositions[turns.currentPlayerForArrays]].rentHotel;
                }        
    }
}

