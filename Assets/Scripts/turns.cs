using UnityEngine;

public class turns : MonoBehaviour
{
    int totalPlayers = 4;
    int currentPlayerTurn = 1;


    void turn()
    {
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


    public bool InJailCheck()
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

    void PlayerTileInformation()
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

    }




}
