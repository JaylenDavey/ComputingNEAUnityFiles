using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIScript : MonoBehaviour
{
    public board board;
    public dice dice;
    public turns turns;

    Button buyButton;
    Button upgradeButton;
    Button mortgageButton;
    Button downgradeButton;
    Button tradeButton;
    Button diceButton;
    Button endButton;

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
    public Text tileOnwer;
        

    public void UpdatePropertyInformation(int tileNumber)
    {
    tileName.text =  board.positionList.position[tileNumber].name;
    tileType.text =  board.positionList.position[tileNumber].type;
    tilePrice.text = "Buy Price : " + board.positionList.position[tileNumber].price.ToString();
    tileRent.text = "Rent Base : " + board.positionList.position[tileNumber].rent.ToString();
    tileOneHouse.text = "Rent With One House : " + board.positionList.position[tileNumber].rentOneHouse.ToString();
    tileTwoHouse.text = "Rent With Two House : " + board.positionList.position[tileNumber].rentTwoHouse.ToString();
    tileThreeHouse.text = "Rent With Three House : " + board.positionList.position[tileNumber].rentThreeHouse.ToString();
    tileFourHouse.text = "Rent With Four House : " + board.positionList.position[tileNumber].rentFourHouse.ToString();
    tileHotel.text = "Rent With Hotel : " + board.positionList.position[tileNumber].rentHotel.ToString();
    tileUpgradeCost.text = "Upgrade Cost : " + board.positionList.position[tileNumber].housePrice.ToString();
    if(board.positionList.position[tileNumber].owner == 6)
    {
        tileOnwer.text = "Not Purchasable";
    }
    else if(!board.positionList.position[tileNumber].isOwned)
    {
        tileOnwer.text = "Unowned";
    }
    else
    {
        tileOnwer.text = "Owned By : Player " + board.positionList.position[tileNumber].owner;
    }
    }


    // mention the waste of time of adding default to tileName when write up k dickehd   
}
