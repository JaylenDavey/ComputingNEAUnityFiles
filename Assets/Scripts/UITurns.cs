using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UITurns : MonoBehaviour
{
    public turns turns;
    public dice dice;
    public board board;

    public Text playerTurn;

    public Transform playerOne;

    Button buyButton;
    Button upgradeButton;
    Button mortgageButton;
    Button downgradeButton;
    Button tradeButton;
    Button diceButton;
    Button endButton;

    public int selectedTile;

    public void Awake()
    {
        playerOne = GameObject.Find("Player1").GetComponent<Transform>();
    }
    public void OnEndTurn()
    {
        turns.currentPlayerTurn ++;
        if(turns.currentPlayerTurn == 5)turns.currentPlayerTurn=1;
        turns.currentPlayerForArrays = turns.currentPlayerTurn - 1;
        playerTurn.text = "Player " + turns.currentPlayerTurn.ToString();

        Debug.Log(turns.currentPlayerTurn.ToString() + turns.currentPlayerForArrays.ToString()); 
    }

    public void StartTurnRollDice()
    {
        turns.playerPositions[turns.currentPlayerForArrays] += dice.RollDice();
        if(turns.playerPositions[turns.currentPlayerForArrays] < 39)turns.playerPositions[turns.currentPlayerForArrays] -= 40;

        playerOne.transform.localPosition = new Vector2(1,1);
    }
}
