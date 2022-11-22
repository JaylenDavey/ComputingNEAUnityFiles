using UnityEngine;

public class turns : MonoBehaviour
{
    public dice dice;
    public board board;

    public int totalPlayers = 6;
    public int currentPlayerTurn = 1;
    public int currentPlayerForArrays = 0;

    int x = 0;
    
    void Start()
    {

    }

    void turn()
    {
        currentPlayerForArrays = currentPlayerTurn - 1;
        bool isInJail = InJailCheck();
        JailOptions();
        Upgrade();
        Trade();
        RollDice();
        MovePlayer();
        PlayerTileInformation();
        PlayerActions();
        CheckForDouble();
        DeterminePlayerTurn();
    }


    bool InJailCheck()
    {
        if(board.playerIsInJail)
        return false;
    }

    void JailOptions()
    {

    }

    void Upgrade()
    {

    }

    void Trade()
    {

    }

    void RollDice()
    {

    }

    void MovePlayer()
    {

    }

    string PlayerTileInformation()
    {
        string tileType = "Pass Go";
        return tileType;
    }

    void PlayerActions()
    {

    }

    void CheckForDouble()
    {

    }

    void DeterminePlayerTurn()
    {
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
