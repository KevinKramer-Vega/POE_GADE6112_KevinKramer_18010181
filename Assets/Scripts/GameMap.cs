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
    //Team 1 Units/Buildings
    public enum TileTypeTeam1
    {
        MeleeUnit_Team1,
        RangedUnit_Team1,
        WizzardUnit_Team1,
        Resource_Team1,
        Factory_Team1
    }
    //Team 2 Units/Buildings
    public enum TileTypeTeam2
    {
        MeleeUnit_Team2,
        RangedUnit_Team2,
        WizzardUnit_Team2,
        Resource_Team2,
        Factory_Team2
    }
    //Neutral Team Unit + Neutral objects like a wall/openSpace
    public enum Neutral
    {
        Wizzard_Neutral,
        OpenTile,
        Wall
    }

    public int mapSize;
    public GameObject openSpace;
    public GameObject wall;
    public GameObject [] team1;
    public GameObject [] team2;
    public GameObject [] neutral;

    TileTypeTeam1[,] map;
    TileTypeTeam2[,] map2;
    Neutral[,] map3;
    int posX;
    int posZ;

    // Start is called before the first frame update
    void Start()
    {

        InitializeMap();
        PlaceWall();
        PlaceTeam1();
        PlaceTeam2();
        PlaceNeutral();

        // =========================

        Display();

    }

    // Update is called once per frame
    void Update()
    {
       
    }
    public void InitializeMap()
    {
        map3 = new Neutral[mapSize, mapSize];

        for (int x = 0; x < mapSize; x++)
        {
            for (int z = 0; z < mapSize; z++)
            {
                map3[x, z] = Neutral.OpenTile;
            }
        }

        //North Wall
        for (int x = 0; x < mapSize; x++)
        {
            map3[x, mapSize - 1] = Neutral.OpenTile;
        }

        //South Wall
        for (int x = 0; x < mapSize; x++)
        {
            map3[x, 0] = Neutral.OpenTile;
        }

        //East Wall
        for (int z = 0; z < mapSize; z++)
        {
            map3[mapSize - 1, z] = Neutral.OpenTile;
        }

        //West Wall
        for (int z = 0; z < mapSize; z++)
        {
            map3[0, z] = Neutral.OpenTile;
        }
    }
}
