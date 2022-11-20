using UnityEngine;

public class dice : MonoBehaviour
{
    public int numberOfDoubles = 0;

    public int RollDice()
    {
        int rollOne = 0;
        int rollTwo = 0;

        rollOne = Random.Range(1,7);
        rollTwo = Random.Range(1,7);

        int rollTotal = rollOne + rollTwo;
        
        DoubleCheck(rollOne, rollTwo);

        return rollTotal;
    }

    bool DoubleCheck(int dieOne, int dieTwo)
    {
        if(dieOne==dieTwo)
        {
            numberOfDoubles++;
            JailCheck();
            // When Players Added Give Player Rolling Double Another Turn
            return true;
        }
        else 
        {
            numberOfDoubles = 0;
            return false;
        }
    }   

    bool JailCheck()
    {
        if(numberOfDoubles == 3)
        {
            // When Jail Is Added Add A Function That Puts Player In Jail
            numberOfDoubles = 0;
            return true;
        }
        else return false;
    }
}
