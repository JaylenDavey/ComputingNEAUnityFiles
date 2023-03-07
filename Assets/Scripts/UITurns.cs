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
    public ChanceAndCommunityChest chanceAndCommunityChest;

    public Button buyButton;
    public Button tradeButton;
    public Button upgradeButton;
    public Button downgradeButton;
    public Button mortgageButton;
    public Button unmortgageButton;
    public Button rollDiceButton;
    public Button endTurnButton;

    public Button rollDoubleButton;
    public Button getOutOfJailFreeCard;
    public Button payFiftyButton;
    public GameObject jailOptionsUI;

    public int[] numberOfDoubles = new int[] {0,0,0,0};

    public Text playerTurn;
    
    public Image playerOne,playerTwo,playerThree,playerFour,UIColor,UIColor2,JailOptionsImage;

    public GameObject[] playerCounters;

    public int selectedTile;

    public void Awake()
    {
        GameObject playerOne = GameObject.Find("PlayerCounter 1");
        GameObject playerTwo = GameObject.Find("PlayerCounter 2");
        GameObject playerThree = GameObject.Find("PlayerCounter 3");
        GameObject playerFour = GameObject.Find("PlayerCounter 4");

        playerCounters = new GameObject[] { playerOne, playerTwo, playerThree, playerFour };

        ChangeUIColour();

        NewTurnUIUpdate();

    }

    public void EndTurn()
    {
        turns.currentPlayerTurn ++;
        if(turns.currentPlayerTurn == 5)turns.currentPlayerTurn=1;
        turns.currentPlayerForArrays = turns.currentPlayerTurn - 1;
        playerTurn.text = "Player " + turns.currentPlayerTurn.ToString();

        ChangeUIColour();
        NewTurnUIUpdate();

        if(turns.playerIsInJail[turns.currentPlayerForArrays])EnableJailOptions();
    }

    public void RollDice()
    {
        int rollOne = 0;
        int rollTwo = 0;

        rollOne = Random.Range(1,7);
        rollTwo = Random.Range(1,7);

        Debug.Log(""+rollOne+""+rollTwo);

        int rollTotal = rollOne + rollTwo;

        turns.playerPositions[turns.currentPlayerForArrays] += rollTotal;
        if(turns.playerPositions[turns.currentPlayerForArrays] > 39)
        {
            turns.playerPositions[turns.currentPlayerForArrays] -= 40;
            turns.playerMoney[turns.currentPlayerForArrays] += 200;
            uiScript.MoneyInterfaceUpdater();
        }
        MovePlayer(rollTotal);

        if(!DoubleCheck(rollOne, rollTwo))
        {
            rollDiceButton.interactable = false;
            endTurnButton.interactable = true;
        }
        JailCheck();
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
            MortgagePropertyButtonCheck();
            buyButton.interactable = false;

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

            UpgradePropertyButtonCheck();
            DowngradePropertyButtonCheck();
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

            DowngradePropertyButtonCheck();
            UpgradePropertyButtonCheck();
        }
    }

    public void MortgageProperty()
    {
        if(board.positionList.position[selectedTile].owner == turns.currentPlayerTurn && board.positionList.position[selectedTile].isOwned)
        {
            board.positionList.position[selectedTile].isOwned = false;
            board.positionList.position[selectedTile].owner = turns.currentPlayerTurn;
            turns.playerMoney[turns.currentPlayerForArrays] += board.positionList.position[selectedTile].price/2;
            uiScript.MoneyInterfaceUpdater();
            UnmortgagePropertyButtonCheck();
            MortgagePropertyButtonCheck();
        }
    }

    public void UnMortgageProperty()
    {
        if(turns.playerMoney[turns.currentPlayerForArrays]>=board.positionList.position[selectedTile].price/2 && board.positionList.position[selectedTile].owner == turns.currentPlayerTurn && !board.positionList.position[selectedTile].isOwned)
        {
            board.positionList.position[selectedTile].isOwned = true;
            board.positionList.position[selectedTile].owner = turns.currentPlayerTurn;
            turns.playerMoney[turns.currentPlayerForArrays] -= board.positionList.position[selectedTile].price/2;
            uiScript.MoneyInterfaceUpdater();
            MortgagePropertyButtonCheck();
            UnmortgagePropertyButtonCheck();
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
        if(board.positionList.position[selectedTile].owner == turns.currentPlayerTurn && turns.PlayerOwnsEntireSet(selectedTile, turns.currentPlayerForArrays) && board.positionList.position[selectedTile].housesNumber > 0)return true;
        else return false;
    }



    void ChangeUIColour()
    {
        if(turns.currentPlayerTurn == 1)
        {
            UIColor.color = playerOne.color;
            UIColor2.color = playerOne.color;
            JailOptionsImage.color = playerOne.color;
        }
        if(turns.currentPlayerTurn == 2)
        {
            UIColor.color = playerTwo.color;
            UIColor2.color = playerTwo.color;
            JailOptionsImage.color = playerTwo.color;
        }
        if(turns.currentPlayerTurn == 3)
        {
            UIColor.color = playerThree.color;
            UIColor2.color = playerThree.color;
            JailOptionsImage.color = playerThree.color;
        }
        if(turns.currentPlayerTurn == 4)
        {
            UIColor.color = playerFour.color;
            UIColor2.color = playerFour.color;
            JailOptionsImage.color = playerFour.color;
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
        if(GetTileType() == "Chance")
        {
            chanceAndCommunityChest.Chance();
        }
        if(GetTileType() == "Community Chest")
        {
            chanceAndCommunityChest.CommuntiyChest();
        }
        if(GetTileType() == "Go To Jail")
        {
            MovePlayerToJail();
        }

        BuyButtonCheck();
    }

    public void DisableAllButtons()
    {
        buyButton.interactable = false;
        tradeButton.interactable = false;
        upgradeButton.interactable = false;
        downgradeButton.interactable = false;
        mortgageButton.interactable = false;
        unmortgageButton.interactable = false;
        rollDiceButton.interactable = false;
        endTurnButton.interactable = false;
    }

    public void EnableAllButtons()
    {
        buyButton.interactable = true;
        tradeButton.interactable = true;
        upgradeButton.interactable = true;
        downgradeButton.interactable = true;
        mortgageButton.interactable = true;
        unmortgageButton.interactable = true;
        rollDiceButton.interactable = true;
        endTurnButton.interactable = true;
    }

    bool DoubleCheck(int dieOne, int dieTwo)
    {
        if(dieOne==dieTwo)
        {
            numberOfDoubles[turns.currentPlayerForArrays]++;
            // When Players Added Give Player Rolling Double Another Turn
            return true;
        }
        else 
        {
            numberOfDoubles[turns.currentPlayerForArrays] = 0;
            return false;
        }
    }   

    bool JailCheck()
    {
        if(numberOfDoubles[turns.currentPlayerForArrays] == 3)
        {
            Debug.Log("JAIL!!");
            MovePlayerToJail();
            numberOfDoubles[turns.currentPlayerForArrays] = 0;
            return true;
        }
        else return false;
    }

    public void MovePlayerToJail()
    {
        turns.playerPositions[turns.currentPlayerForArrays] = 10;
        turns.playerIsInJail[turns.currentPlayerForArrays] = true;
        MovePlayer(0);
    }


    public void UpgradePropertyButtonCheck()
    {
        if(UpgradeRequirementsCheck())
        {
            upgradeButton.interactable = true;
        }
        else upgradeButton.interactable = false;

    }

    public void DowngradePropertyButtonCheck()
    {
        if(DowngradeRequirementsCheck())
        {
            downgradeButton.interactable = true;
        }
        else downgradeButton.interactable = false;

    }

    public void BuyButtonCheck()
    {
        if(turns.playerMoney[turns.currentPlayerForArrays]>=board.positionList.position[turns.playerPositions[turns.currentPlayerForArrays]].price && !board.positionList.position[turns.playerPositions[turns.currentPlayerForArrays]].isOwned)
        {
            buyButton.interactable = true;
        }
        else buyButton.interactable = false;
    }

    public void MortgagePropertyButtonCheck()
    {
        if(board.positionList.position[selectedTile].owner == turns.currentPlayerTurn && board.positionList.position[selectedTile].isOwned)
        {
            mortgageButton.interactable = true;
        }
        else mortgageButton.interactable = false;
    }

    public void UnmortgagePropertyButtonCheck()
    {
        if(turns.playerMoney[turns.currentPlayerForArrays]>=board.positionList.position[turns.playerPositions[turns.currentPlayerForArrays]].price/2 && board.positionList.position[selectedTile].owner == turns.currentPlayerTurn && !board.positionList.position[selectedTile].isOwned)
        {
            unmortgageButton.interactable = true;
        }
        else unmortgageButton.interactable = false;
    }

    public void NewTurnUIUpdate()
    {
        rollDiceButton.interactable = true;
        endTurnButton.interactable = false;
        upgradeButton.interactable = false;
        downgradeButton.interactable = false;
        mortgageButton.interactable = false;
        unmortgageButton.interactable = false;
        buyButton.interactable = false;
        tradeButton.interactable = false;
    }

    public void EnableJailOptions()
    {
        rollDiceButton.interactable = false;
        jailOptionsUI.SetActive(true);
        rollDoubleButton.interactable = true;
        GetOutOfJailFreeCardButtonCheck();
        PayFiftyCheck();
    }

    public void DisableJailOptions()
    {
        jailOptionsUI.SetActive(false);
        rollDoubleButton.interactable = false;

        if(turns.playerTurnsInJail[turns.currentPlayerForArrays] == 3)
        {
            FreePlayerFromJail();
        }
    }

    void GetOutOfJailFreeCardButtonCheck()
    {
        if(turns.playerHasGetOutOfJailFreeCard[turns.currentPlayerForArrays])
        {
            getOutOfJailFreeCard.interactable = true;
        }
        else getOutOfJailFreeCard.interactable = false;
    }

    public void UseGetOutOfJailFreeCard()
    {
        if(turns.playerHasGetOutOfJailFreeCard[turns.currentPlayerForArrays] == true)
        {
            turns.playerHasGetOutOfJailFreeCard[turns.currentPlayerForArrays] = false;
            FreePlayerFromJail();
        }
    }

    public void JailRollDouble()
    {
        int rollOne = 0;
        int rollTwo = 0;

        rollOne = Random.Range(1,7);
        rollTwo = Random.Range(1,7);

        if(rollOne == rollTwo)
        {
            FreePlayerFromJail();
        }
        else
        {
            turns.playerTurnsInJail[turns.currentPlayerForArrays] ++;
            DisableJailOptions();
            EndTurn();
        }
    }

    void FreePlayerFromJail()
    {
        turns.playerIsInJail[turns.currentPlayerForArrays] = false;
        turns.playerTurnsInJail[turns.currentPlayerForArrays] = 0;
        jailOptionsUI.SetActive(false);
        DisableJailOptions();
        EndTurn();
    }

    void PayFiftyCheck()
    {
        if(turns.playerMoney[turns.currentPlayerForArrays] >= 50)
        {
            payFiftyButton.interactable = true;
        }
        else payFiftyButton.interactable = false;
    }

    public void PayFiftyGetOutOfJail()
    {
        if(turns.playerMoney[turns.currentPlayerForArrays] >= 50)
        {
            turns.playerMoney[turns.currentPlayerForArrays] -= 50;
            FreePlayerFromJail();
        }
    }
}

