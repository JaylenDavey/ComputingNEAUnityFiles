using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Xml.Serialization;

public class board : MonoBehaviour
{
    public dice dice;
    public turns turns;
    public tiles tiles;

    public string[] tileNames = new string[] {"Pass Go","Old Kent Road","Community Chest","Whitechapel Road","Income Tax","King's Cross Station","The Angel, Islington","Chance","Euston Road","Pentonville Road","Jail","Pall Mall","Electric Company","Whitehall","Northumberland Avenue","Marylebone Station","Bow Street","Community Chest","Malborough Street","Vine Street","Free Parking","Strand","Chance","Fleet Street","Trafalgar Square","Fenchurch Station","Leicester Square","Coventry Street","Water Works","Piccadilly","Go To Jail","Regent Street","Oxford Street","Community Chest","Bond Street","Liverpool Street Station","Chance","Park Lane","Super Tax","Mayfair"};
    // 0 = GO : 1 = JAIL : 2 = Free Parking : 3 = GO TO JAIL : 4 = Unowned Property : 5 = Owned Property : 6 = Chance : 7 = Community Chest : 8 = Chance : 9 = Tax
    public int[] tileType = new int[];
    public int[] tileOwner = new int[null,null,null,null,null,null,null,null,null,null,null,null,null,null,null,null,null,null,null,null,null,null,null,null,null,null,null,null,null,null,null,null,null,null,null,null,null,null,null,null];
    public int[] tileHouses = new int[];
    public int[] ti

    int diceTotal = 0;

    public int[] playerPositions = new int[] {0,0,0,0,0,0};
    public bool[] playerIsInJail = new bool[] {false,false,false,false,false,false};

    private void Start()
    {

    }
    
    void Update()
    {

    }






}
