using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class board : MonoBehaviour
{
    public int tileNumber = 0;
    public string[] tileNames = new string[] {"Pass Go","Old Kent Road","Community Chest","Income Tax","King's Cross Station","The Angel, Islington","Chance","Euston Road","Pentonville Road","Jail","Pall Mall","Electric Company","Whitehall","Northumberland Avenue","Marylebone Station","Bond Street","Malborough Street","Vine Street","Free Parking","Strand","Chance","Fleet Street","Trafalgar Square","Fenchurch Station","Leicester Square","Coventry Street","Water Works","Piccadilly","Go To Jail","Regent Street","Oxford Street","Community Chest","Bond Street","Liverpool Street Station","Chance","Park Lane","Super Tax","Mayfair"};

    /// <summary>
    /// Start is called on the frame when a script is enabled just before
    /// any of the Update methods is called the first time.
    /// </summary>
    private void Start()
    {
        debug.Debug.Log(titleNames[1],titleNames[10]);
    }
    
}
