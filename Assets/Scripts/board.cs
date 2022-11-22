using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class board : MonoBehaviour
{
    public dice dice;
    public turns turns;
    public tiles tiles;


    public int[] playerPositions = new int[] {0,0,0,0,0,0};
    public bool[] playerIsInJail = new bool[] {false,false,false,false,false,false};



}
