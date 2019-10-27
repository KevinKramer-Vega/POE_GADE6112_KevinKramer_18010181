using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMap : MonoBehaviour
{
    public enum Direction
    {
        North,
        East,
        South,
        West
    }

    public enum TileTypeTeam1
    {
        MeleeUnit_Team1,
        RangedUnit_Team1,
        WizzardUnit_Team1,
        Resource_Team1,
        Factory_Team1
    }
    public enum TileTypeTeam2
    {
        MeleeUnit_Team2,
        RangedUnit_Team2,
        WizzardUnit_Team2,
        Resource_Team2,
        Factory_Team2
    }
    public enum Neutral
    {
        Wizzard_Neutral,
        OpenTile,
        Wall
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
