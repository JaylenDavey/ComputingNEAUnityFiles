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


    void turn(){
        currentPlayerForArrays = currentPlayerTurn - 1;
        JailCheck();
        Upgrade();
        Trade();
        RollDice();
        MovePlayer();
        PlayerTileInformation();
        PlayerActions();
        WinConditionCheck();
        CheckForDouble();
        DeterminePlayerTurn();
    }


    void JailCheck(){
        if(playerIsInJail[currentPlayerForArrays])
        {
            JailOptions(); 
        }
    }

    void JailOptions(){
        
    }

    void Upgrade(){

    }

    void Trade(){

    }

    void RollDice(){

    }

    void MovePlayer(){

    }

    string PlayerTileInformation(){
        string tileType = "Pass Go";
        return tileType;
    }

    void PlayerActions(){

    }

    void WinConditionCheck(){

    }

    void CheckForDouble(){

    }

    void DeterminePlayerTurn(){
        if(currentPlayerTurn==totalPlayers)
        {
            currentPlayerTurn = 1;
        }
        else
        {
            currentPlayerTurn ++;
        }
    }




}
