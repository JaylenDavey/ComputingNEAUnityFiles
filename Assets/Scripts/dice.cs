using UnityEngine;

public class dice : MonoBehaviour
{
    public board board;
    public turns turns;
    public UIScript uiScript;

    public int[] numberOfDoubles = new int[] {0,0,0,0};

    [ContextMenu("Dice Roll")]
    public void DiceRolling()
    {
        RollDice();
    }



    public int RollDice()
    {
        int rollOne = 0;
        int rollTwo = 0;

        rollOne = Random.Range(1,7);
        rollTwo = Random.Range(1,7);

        int rollTotal = rollOne + rollTwo;
        
        DoubleCheck(rollOne, rollTwo);
        JailCheck();

        Debug.Log(""+rollOne + rollTwo + rollTotal);

        return rollTotal;
    }

    bool DoubleCheck(int dieOne, int dieTwo)
    {
        if(dieOne==dieTwo)
        {
            numberOfDoubles[turns.currentPlayerForArrays]++;
            // When Players Added Give Player Rolling Double Another Turn
            return true;
        }
        else 
        {
            numberOfDoubles[turns.currentPlayerForArrays] = 0;
            return false;
        }
    }   

    bool JailCheck()
    {
        if(numberOfDoubles[turns.currentPlayerForArrays] == 3)
        {
            Debug.Log("JAIL!!");
            // When Jail Is Added Add A Function That Puts Player In Jail
            numberOfDoubles[turns.currentPlayerForArrays] = 0;
            return true;
        }
        else return false;
    }
}
