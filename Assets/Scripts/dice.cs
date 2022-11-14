using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class play : MonoBehaviour
{
    public int numberOfDoubles = 0;

    void Start()
    {
        RollDice();
    }

    int RollDice()
    {
        int diceRollOne = 0;
        int diceRollTwo = 0;

        diceRollOne = Random.Range(0,6);
        diceRollTwo = Random.Range(0,6);

        int diceTotal = diceRollOne + diceRollTwo;

        DoubleCheck(diceRollOne, diceRollTwo);

        Debug.Log(""+diceRollOne+diceRollTwo+DoubleCheck(diceRollOne, diceRollTwo));

        return diceTotal;

    }

    bool DoubleCheck(int a, int b)
    {
        if(a==b)
        {
            numberOfDoubles ++;
            return true;
        }
        else
            return false;
    }
    
}
