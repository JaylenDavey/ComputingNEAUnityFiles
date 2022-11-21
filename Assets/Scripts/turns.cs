using UnityEngine;

public class turns : MonoBehaviour
{
    public dice dice;
    public board board;

    int totalPlayers = 4;
    int currentPlayerTurn = 1;
    int currentPlayerForsArrays = 0;
    
    void Start()
    {
        debug.Log(board.playerPositions[0])
        debug.Log(board.tileNames[board.playerPositions])
        int x = 0
    }

    void Update()
    {
        currentPlayerForsArrays = currentPlayerTurn - 1;
        while(x <= 100)
        {
            dice.RollDice()
            board.playerPositions[currentPlayerForsArrays]
            x+=;
        }
    }

    void turn()
    {
        currentPlayerForsArrays = currentPlayerTurn - 1;
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

    int PlayerTileInformation()
    {

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
            currentPlayerTurn +=;
        }
    }




}
