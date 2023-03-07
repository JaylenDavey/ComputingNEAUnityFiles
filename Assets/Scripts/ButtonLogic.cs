using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonLogic : MonoBehaviour
{
    public Button buyButton;
    public Button tradeButton;
    public Button upgradeButton;
    public Button downgradeButton;
    public Button mortgageButton;
    public Button unmortgageButton;
    public Button rollDiceButton;
    public Button endTurn;

    public void BuyCheck(int playersMoney, int tileCost)
    {
        if(playersMoney < tileCost)
        {
            buyButton.interactable = false;
        }
        else
        {
            buyButton.interactable = true;
        }
    }

    public void UpgradeCheck(int playersMoney, int upgradeCost)
    {
        if(playersMoney < upgradeCost)
        {
            buyButton.interactable = false;
        }
        else
        {
            buyButton.interactable = true;
        }
    }

    public void DowngradeCheck(int numberOfHouses, int tileCost)
    {
        if(numberOfHouses > 0)
        {
            buyButton.interactable = true;
        }
        else
        {
            buyButton.interactable = false;
        }
    }

    public void MortgageCheck(int playersMoney, int upgradeCost)
    {
        if(playersMoney >= upgradeCost)
        {
            buyButton.interactable = false;
        }
    }

    public void UnmortgageCheck(int playersMoney, int upgradeCost)
    {
        if(playersMoney >= upgradeCost)
        {
            buyButton.interactable = false;
        }
    }

    public void RollDiceCheck(int playersMoney, int upgradeCost)
    {
        if(playersMoney >= upgradeCost)
        {
            buyButton.interactable = false;
        }
    }
    
    public void EndTurnCheck(int playersMoney, int upgradeCost)
    {
        if(playersMoney >= upgradeCost)
        {
            buyButton.interactable = false;
        }
    }
    

    public void DisableAll()
    {
        buyButton.interactable = false;
        tradeButton.interactable = false;
        upgradeButton.interactable = false;
        downgradeButton.interactable = false;
        mortgageButton.interactable = false;
        unmortgageButton.interactable = false;
        rollDiceButton.interactable = false;
        endTurn.interactable = false;
    }


}
