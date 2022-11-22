using UnityEngine;

public class turns : MonoBehaviour
{
    public dice dice;
    public board board;
    public tiles tiles;

    public int totalPlayers = 6;
    public int currentPlayerTurn = 1;
    public int currentPlayerForArrays = 0;


    void turn()
    {
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
        if(board.playerIsInJail[currentPlayerForArrays])
        {
            JailOptions(); 
        }
    }

    void JailOptions()
    {

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
