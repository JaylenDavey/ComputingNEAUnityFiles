using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random;

public class board : MonoBehaviour
{
    public int tileNumber = 0;
    public string[] tileNames = new string[] {"Pass Go","Old Kent Road","Community Chest","Income Tax","King's Cross Station","The Angel, Islington","Chance","Euston Road","Pentonville Road","Jail","Pall Mall","Electric Company","Whitehall","Northumberland Avenue","Marylebone Station","Bond Street","Malborough Street","Vine Street","Free Parking","Strand","Chance","Fleet Street","Trafalgar Square","Fenchurch Station","Leicester Square","Coventry Street","Water Works","Piccadilly","Go To Jail","Regent Street","Oxford Street","Community Chest","Bond Street","Liverpool Street Station","Chance","Park Lane","Super Tax","Mayfair"};


    void Start()
    {
        Debug.Log(tileNames[1]); 
    }

    int RollDice(int diceTotal, bool isDouble)
    {
        int diceRollOne = 0;
        int diceRollTwo = 0;

        diceRollOne = Random.range(0,6)
        diceRollTwo = Random.range(0,6)

        diceTotal = diceRollOne + diceRollTwo;
        if diceRollOne == diceRollTwo(isDouble = true)

        return(diceTotal,isDouble)
    }
    
}
