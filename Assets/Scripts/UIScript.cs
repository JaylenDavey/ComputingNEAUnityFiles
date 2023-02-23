using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIScript : MonoBehaviour
{
    public board board;
    public dice dice;
    public turns turns;

    public Text tileName;
    public Text tileType;
    public Text tilePrice;
    public Text tileRent;
    public Text tileOneHouse;
    public Text tileTwoHouse;
    public Text tileThreeHouse;
    public Text tileFourHouse;
    public Text tileHotel;
    public Text tileUpgradeCost;
    public Text tileOwner;

    public Text playerOneMoney;
    public Text playerTwoMoney;
    public Text playerThreeMoney;
    public Text playerFourMoney;
        

    private void UpdateOwnerInformation(int tileNumber)
    {
        if(board.positionList.position[tileNumber].owner == 6)
        {
            tileOwner.text = "Not Purchasable";
        }
        else if(!board.positionList.position[tileNumber].isOwned)
        {
            tileOwner.text = "Unowned";
        }
        else
        {
            tileOwner.text = "Owned By : Player " + board.positionList.position[tileNumber].owner;
        }
    }
    private void UpdateSharedInformation(int tileNumber)
    {
        tileName.text =  board.positionList.position[tileNumber].name;
        tileType.text =  board.positionList.position[tileNumber].type;
    }

    private void UpdateStationInformation(int tileNumber)
    {
        tilePrice.text = "Buy Price : " + board.positionList.position[tileNumber].price.ToString();
        tileRent.text = "";
        tileOneHouse.text = "One Station Rent : " + board.positionList.position[tileNumber].rent.ToString();
        tileTwoHouse.text = "Two Station Rent : " + board.positionList.position[tileNumber].rentOneHouse.ToString();
        tileThreeHouse.text = "Three Station Rent : " + board.positionList.position[tileNumber].rentTwoHouse.ToString();
        tileFourHouse.text = "Four Station Rent : " + board.positionList.position[tileNumber].rentThreeHouse.ToString();  
        tileHotel.text = "";
        tileUpgradeCost.text = "Upgrade Cost : " + board.positionList.position[tileNumber].housePrice.ToString();
    }
    private void UpdatePropertyInformation(int tileNumber)
    {
        tilePrice.text = "Buy Price : " + board.positionList.position[tileNumber].price.ToString();
        tileRent.text = "Rent Base : " + board.positionList.position[tileNumber].rent.ToString();
        tileOneHouse.text = "Rent With One House : " + board.positionList.position[tileNumber].rentOneHouse.ToString();
        tileTwoHouse.text = "Rent With Two House : " + board.positionList.position[tileNumber].rentTwoHouse.ToString();
        tileThreeHouse.text = "Rent With Three House : " + board.positionList.position[tileNumber].rentThreeHouse.ToString();
        tileFourHouse.text = "Rent With Four House : " + board.positionList.position[tileNumber].rentFourHouse.ToString();
        tileHotel.text = "Rent With Hotel : " + board.positionList.position[tileNumber].rentHotel.ToString();
        tileUpgradeCost.text = "Upgrade Cost : " + board.positionList.position[tileNumber].housePrice.ToString();
    }
    private void UpdateUtillityInformation(int tileNumber)
    {
        tilePrice.text = "Buy Price : " + board.positionList.position[tileNumber].price.ToString();
        tileRent.text = "Rent Base : " + board.positionList.position[tileNumber].rent.ToString();
        tileOneHouse.text = "Rent With One House : " + board.positionList.position[tileNumber].rentOneHouse.ToString();
        tileTwoHouse.text = "Rent With Two House : " + board.positionList.position[tileNumber].rentTwoHouse.ToString();
        tileThreeHouse.text = "Rent With Three House : " + board.positionList.position[tileNumber].rentThreeHouse.ToString();
        tileFourHouse.text = "Rent With Four House : " + board.positionList.position[tileNumber].rentFourHouse.ToString();
        tileHotel.text = "Rent With Hotel : " + board.positionList.position[tileNumber].rentHotel.ToString();
        tileUpgradeCost.text = "Upgrade Cost : " + board.positionList.position[tileNumber].housePrice.ToString();
    }
    private void UpdateGoInformation(int tileNumber)
    {
        tilePrice.text = "When You Pass GO Collect 200";
        tileRent.text = "";
        tileOneHouse.text = "";
        tileTwoHouse.text = "";
        tileThreeHouse.text = "";
        tileFourHouse.text = "";
        tileHotel.text = "";
        tileUpgradeCost.text = "";
    }
    private void UpdateParkingInformation(int tileNumber)
    {
        tilePrice.text = "This Tile Is Just A Place";
        tileRent.text = "To Rest,";
        tileOneHouse.text = "There Is No Reward For";
        tileTwoHouse.text = "Landing Here";
        tileThreeHouse.text = "";
        tileFourHouse.text = "";
        tileHotel.text = "";
        tileUpgradeCost.text = "";
    }
    private void UpdateGoToJailInformation(int tileNumber)
    {
        tilePrice.text = "When You Pass GO Collect 200";
        tileRent.text = "";
        tileOneHouse.text = "";
        tileTwoHouse.text = "";
        tileThreeHouse.text = "";
        tileFourHouse.text = "";
        tileHotel.text = "";
        tileUpgradeCost.text = "";
    }
    private void UpdateCommunityInformation(int tileNumber)
    {
        tilePrice.text = "When You Land On This Tile";
        tileRent.text = "Pick Up A Community Chest Chard Card";
        tileOneHouse.text = "";
        tileTwoHouse.text = "";
        tileThreeHouse.text = "";
        tileFourHouse.text = "";
        tileHotel.text = "";
        tileUpgradeCost.text = "";
    }
    private void UpdateChanceInformation(int tileNumber)
    {
        tilePrice.text = "When You Land On This Tile";
        tileRent.text = "Pick Up A Chance Card.";
        tileOneHouse.text = "";
        tileTwoHouse.text = "";
        tileThreeHouse.text = "";
        tileFourHouse.text = "";
        tileHotel.text = "";
        tileUpgradeCost.text = "";
    }
    private void UpdateTaxInformation(int tileNumber)
    {
        tilePrice.text = "When You Land Here";
        tileRent.text = "You Pay : "+ board.positionList.position[tileNumber].rent;
        tileOneHouse.text = "";
        tileTwoHouse.text = "";
        tileThreeHouse.text = "";
        tileFourHouse.text = "";
        tileHotel.text = "";
        tileUpgradeCost.text = "";
    }
    private void UpdateJailInformation(int tileNumber)
    {
        tilePrice.text = "Prisoner Are Held Here";
        tileRent.text = "";
        if(turns.playerIsInJail[0])tileOneHouse.text = "Player 1 Is Currently In Jail";else tileOneHouse.text="";
        if(turns.playerIsInJail[1])tileTwoHouse.text = "Player 2 Is Currently In Jail";else tileTwoHouse.text="";
        if(turns.playerIsInJail[2])tileThreeHouse.text = "Player 3 Is Currently In Jail";else tileThreeHouse.text="";
        if(turns.playerIsInJail[3])tileFourHouse.text = "Player 4 Is Currently In Jail";else tileFourHouse.text="";
        tileHotel.text = "Options Are On The Right";
        tileUpgradeCost.text = "When It Is Your Turn";
    }

    public void UpdateInformationUI(int tileNumber)
    {
        UpdateOwnerInformation(tileNumber);
        UpdateSharedInformation(tileNumber);
        if(GetTileType(tileNumber) == "Property")
        {
            UpdatePropertyInformation(tileNumber);
        }
        else if(GetTileType(tileNumber) == "Station")
        {
            UpdateStationInformation(tileNumber);
        }
        else if(GetTileType(tileNumber) == "Pass Go")
        {
            UpdateGoInformation(tileNumber);
        }
        else if(GetTileType(tileNumber) == "Free Parking")
        {
            UpdateParkingInformation(tileNumber);
        }
        else if(GetTileType(tileNumber) == "Go To Jail")
        {
            UpdateGoToJailInformation(tileNumber);
        }
        else if(GetTileType(tileNumber) == "Jail")
        {
            UpdateJailInformation(tileNumber);
        }
        else if(GetTileType(tileNumber) == "Chance")
        {
            UpdateChanceInformation(tileNumber);
        }
        else if(GetTileType(tileNumber) == "Community Chest")
        {
            UpdateCommunityInformation(tileNumber);
        }
        else if(GetTileType(tileNumber) == "Tax")
        {
            UpdateTaxInformation(tileNumber);
        }
    }

    public string GetTileType(int tileNumber)
    {
        string whatType = board.positionList.position[tileNumber].type;
        return whatType;
    }

    public void MoneyInterfaceUpdater()
    {
        playerOneMoney.text = "Player One : " + turns.playerMoney[0].ToString();
        playerTwoMoney.text = "Player Two : " + turns.playerMoney[1].ToString();
        playerThreeMoney.text = "Player Three : " + turns.playerMoney[2].ToString();
        playerFourMoney.text = "Player Four : " + turns.playerMoney[3].ToString();
    }


    // mention the waste of time of adding default to tileName when write up k dickehd   
}
