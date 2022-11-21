using UnityEngine;

public class turns : MonoBehaviour
{
    public dice dice;
    public board board;

    int totalPlayers = 4;
    int currentPlayerTurn = 1;
    int currentPlayerForsArrays = 0;

    int x = 0;
    
    void Start()
    {

    }

    void Update()
    {
        currentPlayerForsArrays = currentPlayerTurn - 1;
        while(x <= 100)
        {
            Debug.Log(board.playerPositions[0]);
            Debug.Log(board.tileNames[board.playerPositions[currentPlayerForsArrays]]);
            board.playerPositions[currentPlayerForsArrays] = board.playerPositions[currentPlayerForsArrays] + dice.RollDice();
            Debug.Log(board.playerPositions[0]);
            Debug.Log(board.tileNames[board.playerPositions[currentPlayerForsArrays]]);

            x++;
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
