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
    
    public Image playerOne,playerTwo,playerThree,playerFour,UIColor,UIColor2;

    public GameObject[] playerCounters;

    public int selectedTile;

    public void Awake()
    {
        GameObject playerOne = GameObject.Find("PlayerCounter 1");
        GameObject playerTwo = GameObject.Find("PlayerCounter 2");
        GameObject playerThree = GameObject.Find("PlayerCounter 3");
        GameObject playerFour = GameObject.Find("PlayerCounter 4");

        playerCounters = new GameObject[] {playerOne, playerTwo, playerThree, playerFour};

        ChangeUIColour();
    }

    public void EndTurn()
    {
        turns.currentPlayerTurn ++;
        if(turns.currentPlayerTurn == 5)turns.currentPlayerTurn=1;
        turns.currentPlayerForArrays = turns.currentPlayerTurn - 1;
        playerTurn.text = "Player " + turns.currentPlayerTurn.ToString();

        ChangeUIColour();

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
        MovePlayer(diceroll);
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
            if(board.positionList.position[selectedTile].housesNumber < 5)turns.playerTotalHouses[turns.currentPlayerForArrays] ++;
            if(board.positionList.position[selectedTile].housesNumber == 5)turns.playerTotalHotels[turns.currentPlayerForArrays] ++;
            uiScript.MoneyInterfaceUpdater();
        }
    }

    public void DowngradeProperty()
    {
        if(DowngradeRequirementsCheck())
        {
            turns.playerMoney[turns.currentPlayerForArrays] += board.positionList.position[selectedTile].price;
            board.positionList.position[selectedTile].housesNumber --;
            if(board.positionList.position[selectedTile].housesNumber < 5)turns.playerTotalHouses[turns.currentPlayerForArrays] --;
            if(board.positionList.position[selectedTile].housesNumber == 5)turns.playerTotalHotels[turns.currentPlayerForArrays] --;
            
            uiScript.MoneyInterfaceUpdater();
        }
    }

    public void MortgageProperty()
    {
            board.positionList.position[turns.playerPositions[turns.currentPlayerForArrays]].isOwned = false;
            board.positionList.position[turns.playerPositions[turns.currentPlayerForArrays]].owner = turns.currentPlayerTurn;
            turns.playerMoney[turns.currentPlayerForArrays] += board.positionList.position[turns.playerPositions[turns.currentPlayerForArrays]].price/2;
    }

    public void UnMortgageProperty()
    {
        if(turns.playerMoney[turns.currentPlayerForArrays]>=board.positionList.position[turns.playerPositions[turns.currentPlayerForArrays]].price/2)
        {
            board.positionList.position[turns.playerPositions[turns.currentPlayerForArrays]].isOwned = true;
            board.positionList.position[turns.playerPositions[turns.currentPlayerForArrays]].owner = turns.currentPlayerTurn;
            turns.playerMoney[turns.currentPlayerForArrays] -= board.positionList.position[turns.playerPositions[turns.currentPlayerForArrays]].price/2;
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

    bool DowngradeRequirementsCheck() // Checks if the player owns the tile and its set, as well as checking if the tile has more than 0 houses.
    {
        if(board.positionList.position[selectedTile].owner == turns.currentPlayerTurn && turns.PlayerOwnsEntireSet(selectedTile, turns.currentPlayerForArrays) && board.positionList.position[selectedTile].housesNumber < 0)return true;
        else return false;
    }



    void ChangeUIColour()
    {
        if(turns.currentPlayerTurn == 1)
        {
            UIColor.color = playerOne.color;
            UIColor2.color = playerOne.color;
        }
        if(turns.currentPlayerTurn == 2)
        {
            UIColor.color = playerTwo.color;
            UIColor2.color = playerTwo.color;
        }
        if(turns.currentPlayerTurn == 3)
        {
            UIColor.color = playerThree.color;
            UIColor2.color = playerThree.color;
        }
        if(turns.currentPlayerTurn == 4)
        {
            UIColor.color = playerFour.color;
            UIColor2.color = playerFour.color;
        }
    }

    int NumberOfHouses()
    {
        return board.positionList.position[turns.playerPositions[turns.currentPlayerForArrays]].housesNumber;
    }

    int NumberOfOwnedStations()
    {
        return turns.stationOwnership[board.positionList.position[turns.playerPositions[turns.currentPlayerForArrays]].owner - 1];
    }

    int NumberOfOwnedUtilities()
    {
        return turns.UtilityOwnership[board.positionList.position[turns.playerPositions[turns.currentPlayerForArrays]].owner - 1];
    }

    bool TileIsOwnedByAnotherPlayer()
    {
        return board.positionList.position[turns.playerPositions[turns.currentPlayerForArrays]].isOwned && board.positionList.position[turns.playerPositions[turns.currentPlayerForArrays]].owner != turns.currentPlayerTurn;
    }

    void ChargeStationRent()
    {
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

    void ChargeUtilityRent(int diceroll)
    {
                if(NumberOfOwnedUtilities() == 1)
                {
                    turns.playerMoney[turns.currentPlayerForArrays] -= 4 * diceroll;
                    turns.playerMoney[board.positionList.position[turns.playerPositions[turns.currentPlayerForArrays]].owner - 1] += 4 * diceroll;
                }
                if(NumberOfOwnedUtilities() == 2)
                {
                    turns.playerMoney[turns.currentPlayerForArrays] -= 10 * diceroll;
                    turns.playerMoney[board.positionList.position[turns.playerPositions[turns.currentPlayerForArrays]].owner - 1] += 10 * diceroll;
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

    public void MovePlayer(int diceroll)
    {
        playerCounters[turns.currentPlayerForArrays].transform.localPosition = new Vector2(board.positionList.position[turns.playerPositions[turns.currentPlayerForArrays]].tileXPos,board.positionList.position[turns.playerPositions[turns.currentPlayerForArrays]].tileYPos);
        if(TileIsOwnedByAnotherPlayer())
        {
            if(GetTileType() == "Property")
            {            
                ChargeRent();
                uiScript.MoneyInterfaceUpdater();
            }
            if(GetTileType() == "Station")
            {
                ChargeStationRent();
                uiScript.MoneyInterfaceUpdater(); 
            }
            if(GetTileType() == "Utility")
            {
                ChargeUtilityRent(diceroll);
                uiScript.MoneyInterfaceUpdater(); 
            }
        }

        if(GetTileType() == "Tax")
        {
            turns.playerMoney[turns.currentPlayerForArrays] -= board.positionList.position[turns.playerPositions[turns.currentPlayerForArrays]].rent;
            uiScript.MoneyInterfaceUpdater();

        }  
    }

}

