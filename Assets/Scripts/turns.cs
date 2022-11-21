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

    void Update()
    {  
        while(x <= 10)
        {
            currentPlayerForArrays = currentPlayerTurn - 1;
            Debug.Log("-----Player"+currentPlayerTurn+":");
            Debug.Log(board.tileNames[board.playerPositions[currentPlayerForArrays]]);
            board.playerPositions[currentPlayerForArrays] = board.playerPositions[currentPlayerForArrays] + dice.RollDice();
            Debug.Log(board.tileNames[board.playerPositions[currentPlayerForArrays]]);
            DeterminePlayerTurn();
            Debug.Log(x+"!!!");
            x++;
        }
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
