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
    public enum TileType
    {
        MeleeUnit_Team1,
        RangedUnit_Team1,
        WizzardUnit_Team1,
        Resource_Team1,
        Factory_Team1,
        MeleeUnit_Team2,
        RangedUnit_Team2,
        WizzardUnit_Team2,
        Resource_Team2,
        Factory_Team2,
        Wizzard_Neutral,
        OpenTile,
        Wall
    }
    //Team 2 Units/Buildings
   /* public enum TileTypeTeam2
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
    }*/

    public int mapSize;
    public GameObject OpenTile;
    public GameObject Wall;
    public GameObject [] team1;
    public GameObject [] team2;
    public GameObject [] neutral;

    TileType[,] map;
    //TileTypeTeam2[,] map2;
    //Neutral[,] map3;
    int posX;
    int posZ;

    // Start is called before the first frame update
    void Start()
    {

        InitializeMap();
        //Team1
        PlaceMeleeTeam1(Random.Range(0,5));
        PlaceRangedTeam1(Random.Range(0,5));
        PlaceWizzardTeam1(Random.Range(0,5));
        PlaceFactoryTeam1(Random.Range(0,5));
        PlaceResourceTeam1(Random.Range(0,5));
        //================================
        //Team 2
        PlaceMeleeTeam2(Random.Range(0, 5));
        PlaceRangedTeam2(Random.Range(0, 5));
        PlaceWizzardTeam2(Random.Range(0, 5));
        PlaceFactoryTeam2(Random.Range(0, 5));
        PlaceResourceTeam2(Random.Range(0, 5));

        //Neutral
        PlaceNeutral(1);
        // =========================
        Display();
    }

    // Update is called once per frame
    void Update()
    {
       
    }
    public void InitializeMap()
    {
        map = new TileType[mapSize, mapSize];

        for (int x = 0; x < mapSize; x++)
        {
            for (int z = 0; z < mapSize; z++)
            {
                map[x, z] = TileType.OpenTile;
            }
        }

        //North Wall
        for (int x = 0; x < mapSize; x++)
        {
            map[x, mapSize - 1] = TileType.OpenTile;
        }

        //South Wall
        for (int x = 0; x < mapSize; x++)
        {
            map[x, 0] = TileType.OpenTile;
        }

        //East Wall
        for (int z = 0; z < mapSize; z++)
        {
            map[mapSize - 1, z] = TileType.OpenTile;
        }

        //West Wall
        for (int z = 0; z < mapSize; z++)
        {
            map[0, z] = TileType.OpenTile;
        }
    }
    //Place Team 1
    public void PlaceMeleeTeam1(int numMelee1)
    {
        for (int i = 0; i < numMelee1; i++)
        {
           int x = Random.Range(1, mapSize - 1);
           int z = Random.Range(1, mapSize - 1);
           if (map[x, z] == TileType.OpenTile)
           {
             map[x, z] = TileType.MeleeUnit_Team1;
           }
           else
           {
              i--;
           }
        }

    }
    public void PlaceRangedTeam1(int numRanged1)
    {
        for (int i = 0; i < numRanged1; i++)
        {
            int x = Random.Range(1, mapSize - 1);
            int z = Random.Range(1, mapSize - 1);
            if (map[x, z] == TileType.OpenTile)
            {
                map[x, z] = TileType.RangedUnit_Team1;
            }
            else
            {
                i--;
            }
        }

    }
    public void PlaceWizzardTeam1(int numWizzard1)
    {
        for (int i = 0; i < numWizzard1; i++)
        {
            int x = Random.Range(1, mapSize - 1);
            int z = Random.Range(1, mapSize - 1);
            if (map[x, z] == TileType.OpenTile)
            {
                map[x, z] = TileType.WizzardUnit_Team1;
            }
            else
            {
                i--;
            }
        }

    }
    public void PlaceResourceTeam1(int numRes1)
    {
        for (int i = 0; i < numRes1; i++)
        {
            int x = Random.Range(1, mapSize - 1);
            int z = Random.Range(1, mapSize - 1);
            if (map[x, z] == TileType.OpenTile)
            {
                map[x, z] = TileType.Resource_Team1;
            }
            else
            {
                i--;
            }
        }

    }
    public void PlaceFactoryTeam1(int numFac1)
    {
        for (int i = 0; i < numFac1; i++)
        {
            int x = Random.Range(1, mapSize - 1);
            int z = Random.Range(1, mapSize - 1);
            if (map[x, z] == TileType.OpenTile)
            {
                map[x, z] = TileType.Factory_Team1;
            }
            else
            {
                i--;
            }
        }

    }
    //Place Team 2
    public void PlaceMeleeTeam2(int numMelee2)
    {
        for (int i = 0; i < numMelee2; i++)
        {
            int x = Random.Range(1, mapSize - 1);
            int z = Random.Range(1, mapSize - 1);
            if (map[x, z] == TileType.OpenTile)
            {
                map[x, z] = TileType.MeleeUnit_Team2;
            }
            else
            {
                i--;
            }
        }

    }
    public void PlaceRangedTeam2(int numRanged2)
    {
        for (int i = 0; i < numRanged2; i++)
        {
            int x = Random.Range(1, mapSize - 1);
            int z = Random.Range(1, mapSize - 1);
            if (map[x, z] == TileType.OpenTile)
            {
                map[x, z] = TileType.RangedUnit_Team2;
            }
            else
            {
                i--;
            }
        }

    }
    public void PlaceWizzardTeam2(int numWizzard2)
    {
        for (int i = 0; i < numWizzard2; i++)
        {
            int x = Random.Range(1, mapSize - 1);
            int z = Random.Range(1, mapSize - 1);
            if (map[x, z] == TileType.OpenTile)
            {
                map[x, z] = TileType.WizzardUnit_Team2;
            }
            else
            {
                i--;
            }
        }

    }
    public void PlaceResourceTeam2(int numRes2)
    {
        for (int i = 0; i < numRes2; i++)
        {
            int x = Random.Range(1, mapSize - 1);
            int z = Random.Range(1, mapSize - 1);
            if (map[x, z] == TileType.OpenTile)
            {
                map[x, z] = TileType.Resource_Team2;
            }
            else
            {
                i--;
            }
        }

    }
    public void PlaceFactoryTeam2(int numFac2)
    {
        for (int i = 0; i < numFac2; i++)
        {
            int x = Random.Range(1, mapSize - 1);
            int z = Random.Range(1, mapSize - 1);
            if (map[x, z] == TileType.OpenTile)
            {
                map[x, z] = TileType.Factory_Team2;
            }
            else
            {
                i--;
            }
        }

    }
    public void PlaceNeutral(int numWizNeut)
    {
        for (int i = 0; i < numWizNeut; i++)
        {
            int x = Random.Range(1, mapSize - 1);
            int z = Random.Range(1, mapSize - 1);
            if (map[x, z] == TileType.OpenTile)
            {
                map[x, z] = TileType.Wizzard_Neutral;
            }
            else
            {
                i--;
            }
        }
    }

    public void Display()
    {
        GameObject[] tiles = GameObject.FindGameObjectsWithTag("tile");
        foreach (GameObject g in tiles)
        {
            Destroy(g);
        }
        for (int x = 0; x < mapSize; x++)
        {
            for (int z = 0; z < mapSize; z++)
            {
                switch (map[x, z])
                {
                    case TileType.OpenTile:
                       Instantiate(OpenTile, new Vector3(x, 1f, z), Quaternion.identity);
                        break;
                    case TileType.Wall:
                        Instantiate(Wall, new Vector3(x, 1f, z), Quaternion.identity);
                        break;
                    case TileType.MeleeUnit_Team1:
                        Instantiate(team1[0], new Vector3(x, 1f, z), Quaternion.identity);
                        break;
                    case TileType.RangedUnit_Team1:
                        Instantiate(team1[1], new Vector3(x, 1f, z), Quaternion.identity);
                        break;
                    case TileType.WizzardUnit_Team1:
                        Instantiate(team1[2], new Vector3(x, 1f, z), Quaternion.identity);
                        break;
                    case TileType.Resource_Team1:
                        Instantiate(team1[3], new Vector3(x, 1f, z), Quaternion.identity);
                        break;
                    case TileType.Factory_Team1:
                        Instantiate(team1[4], new Vector3(x, 1f, z), Quaternion.identity);
                        break;
                    case TileType.MeleeUnit_Team2:
                        Instantiate(team2[5], new Vector3(x, 1f, z), Quaternion.identity);
                        break;
                    case TileType.RangedUnit_Team2:
                        Instantiate(team2[6], new Vector3(x, 1f, z), Quaternion.identity);
                        break;
                    case TileType.WizzardUnit_Team2:
                        Instantiate(team2[7], new Vector3(x, 1f, z), Quaternion.identity);
                        break;
                    case TileType.Resource_Team2:
                        Instantiate(team2[8], new Vector3(x, 1f, z), Quaternion.identity);
                        break;
                    case TileType.Factory_Team2:
                        Instantiate(team2[9], new Vector3(x, 1f, z), Quaternion.identity);
                        break;
                    case TileType.Wizzard_Neutral:
                        Instantiate(neutral[10], new Vector3(x, 1f, z), Quaternion.identity);
                        break;
                }
            }
        }
    }
}
