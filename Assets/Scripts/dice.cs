using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dice : MonoBehaviour
{
    public int numberOfDoubles = 0;

    public int RollDice()
    {
        int diceRollOne = 0;
        int diceRollTwo = 0;

        diceRollOne = Random.Range(1,7);
        diceRollTwo = Random.Range(1,7);

        int diceTotal = diceRollOne + diceRollTwo;

        DoubleCheck(diceRollOne, diceRollTwo);

        Debug.Log(""+diceRollOne+diceRollTwo+DoubleCheck(diceRollOne, diceRollTwo));

        return diceTotal;
    }

    bool DoubleCheck(int dieOne, int dieTwo)
    {
        if(dieOne==dieTwo)
        {
            numberOfDoubles ++;
            JailCheck(numberOfDoubles);
            return true;
        }
        else
            numberOfDoubles = 0;
            return false;


    }

    bool JailCheck(int numberOfDoubles)
    {
        if(numberOfDoubles == 3)
        {
            Debug.LogError($"3 Doubles!!");
            return true;
            // player goes to jail
        }
        else
            return false;

    }
    
}
