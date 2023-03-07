using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChanceAndCommunityChest : MonoBehaviour
{
    public turns turns;
    public UITurns UITurns;
    public UIScript UIScript;
    public board board;

    public void Chance()
    {
        int whatCard = Random.Range(1,16);

        if(whatCard == 1)
        {
            Debug.Log("Advance To Go");
            turns.playerPositions[turns.currentPlayerForArrays] = 0;
            turns.playerMoney[turns.currentPlayerForArrays] += 200;
            UIScript.MoneyInterfaceUpdater();
            UITurns.MovePlayer(0);
        }
        if(whatCard == 2)
        {
            Debug.Log("Advance To Trafalgar Square");
            if(turns.playerPositions[turns.currentPlayerForArrays]>24)
            {
                turns.playerMoney[turns.currentPlayerForArrays] += 200;
                UIScript.MoneyInterfaceUpdater();
            }
            turns.playerPositions[turns.currentPlayerForArrays] = 24;
            UITurns.MovePlayer(0);
        }
        if(whatCard == 3)
        {
            Debug.Log("Advance To Mayfair");
            turns.playerPositions[turns.currentPlayerForArrays] = 39;
            UITurns.MovePlayer(0);
        }
        if(whatCard == 4)
        {
            Debug.Log("Advance To Pall Mall");
            if(turns.playerPositions[turns.currentPlayerForArrays]>11)
            {
                turns.playerMoney[turns.currentPlayerForArrays] += 200;
                UIScript.MoneyInterfaceUpdater();
            }
            turns.playerPositions[turns.currentPlayerForArrays] = 11;
            UITurns.MovePlayer(0);
        }
        if(whatCard == 5)
        {
            Debug.Log("Advance To Nearest Station");
            if(turns.playerPositions[turns.currentPlayerForArrays]>35)turns.playerPositions[turns.currentPlayerForArrays] = 5;
            else if(turns.playerPositions[turns.currentPlayerForArrays]>25)turns.playerPositions[turns.currentPlayerForArrays] = 35;
            else if(turns.playerPositions[turns.currentPlayerForArrays]>15)turns.playerPositions[turns.currentPlayerForArrays] = 25;
            else if(turns.playerPositions[turns.currentPlayerForArrays]>5)turns.playerPositions[turns.currentPlayerForArrays] = 15;
            UITurns.MovePlayer(0);
        }
        if(whatCard == 6)
        {
            Debug.Log("Advance To Nearest Utility");
            if(turns.playerPositions[turns.currentPlayerForArrays]>28)turns.playerPositions[turns.currentPlayerForArrays] = 12;
            else turns.playerPositions[turns.currentPlayerForArrays] = 28;
            UITurns.MovePlayer(0);
        }
        if(whatCard == 7)
        {
            Debug.Log("Bank pays you dividend of £50");
            turns.playerMoney[turns.currentPlayerForArrays] += 50;
            UIScript.MoneyInterfaceUpdater();
        }

        if(whatCard == 9)
        {
            Debug.Log("Go Back 3 Spaces");
            turns.playerPositions[turns.currentPlayerForArrays] -= 3;
            UITurns.MovePlayer(0);

        }
        if(whatCard == 10)
        {
            Debug.Log("Go to Jail. Go directly to jail, do not pass Go, do not collect £200");
            UITurns.MovePlayerToJail();
        }
        if(whatCard == 11)
        {
            Debug.Log("Make general repairs on all your property. For each house pay £25. For each hotel pay £100");
            turns.playerMoney[turns.currentPlayerForArrays] -= turns.playerTotalHouses[turns.currentPlayerForArrays] * 25;
            turns.playerMoney[turns.currentPlayerForArrays] -= turns.playerTotalHotels[turns.currentPlayerForArrays] * 100;
            UIScript.MoneyInterfaceUpdater();
        }
        if(whatCard == 12)
        {
            Debug.Log("Make general repairs on all your property. For each house pay £25. For each hotel pay £100");
            turns.playerMoney[turns.currentPlayerForArrays] -= 15;
            UIScript.MoneyInterfaceUpdater();
        }
        if(whatCard == 13)
        {
            Debug.Log("Take a trip to Kings Cross Station. If you pass Go, collect £200");
            if(turns.playerPositions[turns.currentPlayerForArrays]>5)
            {
                turns.playerMoney[turns.currentPlayerForArrays] += 200;
                UIScript.MoneyInterfaceUpdater();
            }
            turns.playerPositions[turns.currentPlayerForArrays] = 5;
            UITurns.MovePlayer(0);
        }
        if(whatCard == 14)
        {
            int playersPaid = 0;
            Debug.Log("You have been elected Chairman of the Board. Pay each player £50");
            for(int player = 0; player < turns.playerMoney.Length; player++)
            {
                if(turns.currentPlayerForArrays != player && turns.playerMoney[turns.currentPlayerForArrays] < 0)
                {
                    turns.playerMoney[player] += 50;
                    playersPaid ++;
                }
                turns.playerMoney[turns.currentPlayerForArrays] -= 50 * playersPaid;
                UIScript.MoneyInterfaceUpdater();
            }
        }
        if(whatCard == 15)
        {
            Debug.Log("Your building loan matures. Collect £150");
            turns.playerMoney[turns.currentPlayerForArrays] += 150;
            UIScript.MoneyInterfaceUpdater();
        }
        if(whatCard == 16)
        {
            Debug.Log("Get Out Of Jail Free Card");
            turns.playerHasGetOutOfJailFreeCard[turns.currentPlayerForArrays] = true;
        }
    }
    
    public void CommuntiyChest()
    {
        int whatCard = Random.Range(1,16);

        if(whatCard == 1)
        {
            Debug.Log("Advance To Go");
            turns.playerPositions[turns.currentPlayerForArrays] = 0;
            turns.playerMoney[turns.currentPlayerForArrays] += 200;
            UITurns.MovePlayer(0);
            UIScript.MoneyInterfaceUpdater();
        }
        if(whatCard == 2)
        {
            Debug.Log("Bank error in your favour. Collect £200");
            turns.playerMoney[turns.currentPlayerForArrays] += 200;
            UIScript.MoneyInterfaceUpdater();
        }
        if(whatCard == 3)
        {
            Debug.Log("Doctor’s fee. Pay £50");
            turns.playerMoney[turns.currentPlayerForArrays] -= 50;
            UIScript.MoneyInterfaceUpdater();
        }
        if(whatCard == 4)
        {
            Debug.Log("From sale of stock you get £50");
            turns.playerMoney[turns.currentPlayerForArrays] += 50;
            UIScript.MoneyInterfaceUpdater();
        }
        if(whatCard == 5)
        {
            Debug.Log("Get Out Of Jail Free Card");
            turns.playerHasGetOutOfJailFreeCard[turns.currentPlayerForArrays] = true;
        }
        if(whatCard == 6)
        {
            Debug.Log("Go to Jail. Go directly to jail, do not pass Go, do not collect £200");
            UITurns.MovePlayerToJail();
        }
        if(whatCard == 7)
        {
            Debug.Log("Holiday fund matures. Receive £100");
            turns.playerMoney[turns.currentPlayerForArrays] += 100;
            UIScript.MoneyInterfaceUpdater();
        }
        if(whatCard == 8)
        {
            Debug.Log("Income tax refund. Collect £20");
            turns.playerMoney[turns.currentPlayerForArrays] += 20;
            UIScript.MoneyInterfaceUpdater();
        }
        if(whatCard == 9)
        {
            int playersPaid = 0;
            Debug.Log("It is your birthday. Collect £10 from every player");
            for(int player = 0; player < turns.playerMoney.Length; player++)
            {
                if(turns.currentPlayerForArrays != player && turns.playerMoney[player] < 0)
                {
                    turns.playerMoney[player] -= 10;
                    playersPaid ++;
                }
                turns.playerMoney[turns.currentPlayerForArrays] += 10 * playersPaid;
                UIScript.MoneyInterfaceUpdater();
            }
        }
        if(whatCard == 10)
        {
            Debug.Log("Life insurance matures. Collect £100");
            turns.playerMoney[turns.currentPlayerForArrays] += 100;
            UIScript.MoneyInterfaceUpdater();
        }
        if(whatCard == 11)
        {
            Debug.Log("Pay hospital fees of £100");
            turns.playerMoney[turns.currentPlayerForArrays] -= 100;
            UIScript.MoneyInterfaceUpdater();
        }
        if(whatCard == 12)
        {
            Debug.Log("Pay school fees of £50");
            turns.playerMoney[turns.currentPlayerForArrays] -= 50;
            UIScript.MoneyInterfaceUpdater();
        }
        if(whatCard == 13)
        {
            Debug.Log("Receive £25 consultancy fee");
            turns.playerMoney[turns.currentPlayerForArrays] += 25;
            UIScript.MoneyInterfaceUpdater();
        }
        if(whatCard == 14)
        {
            Debug.Log("You are assessed for street repairs. £40 per house. £115 per hotel");
            turns.playerMoney[turns.currentPlayerForArrays] -= turns.playerTotalHouses[turns.currentPlayerForArrays] * 40;
            turns.playerMoney[turns.currentPlayerForArrays] -= turns.playerTotalHotels[turns.currentPlayerForArrays] * 115;
            UIScript.MoneyInterfaceUpdater();
        }
        if(whatCard == 15)
        {
            Debug.Log("You have won second prize in a beauty contest. Collect £10");
            turns.playerMoney[turns.currentPlayerForArrays] += 10;
            UIScript.MoneyInterfaceUpdater();
        }
        if(whatCard == 16)
        {
            Debug.Log("You inherit £100");
            turns.playerMoney[turns.currentPlayerForArrays] += 100;
            UIScript.MoneyInterfaceUpdater();
        }
    }


}
