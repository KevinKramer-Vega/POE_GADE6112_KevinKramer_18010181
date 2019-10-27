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




    public int mapSize;
    public GameObject OpenTile;
    public GameObject Wall;
    public GameObject[] Team1;
    public GameObject[] Team2;
    public GameObject[] Neutral;


    TileType[,] map;


    int posX;
    int posZ;

    // Start is called before the first frame update
    void Start()
    {
        InitializeMap();
        //Team1
        PlaceTeam1(Random.Range(5, 10));
        PlaceBuildingTeam1(2);

        //================================
        //Team 2


        //Neutral
        PlaceNeutral(5);
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
            map[x, mapSize - 1] = TileType.Wall;
        }

        //South Wall
        for (int x = 0; x < mapSize; x++)
        {
            map[x, 0] = TileType.Wall;
        }

        //East Wall
        for (int z = 0; z < mapSize; z++)
        {
            map[mapSize - 1, z] = TileType.Wall;
        }

        //West Wall
        for (int z = 0; z < mapSize; z++)
        {
            map[0, z] = TileType.Wall;
        }
    }

    //Place Team 1 units
    public void PlaceTeam1(int placeTeam1)
    {
        for (int i = 0; i < placeTeam1; i++)
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
        for (int i = 0; i < placeTeam1; i++)
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
        for (int i = 0; i < placeTeam1; i++)
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
    //Place Teamq Buildings
    public void PlaceBuildingTeam1(int placeBuildingTeam1)
    {
        for (int i = 0; i < placeBuildingTeam1; i++)
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
        for (int i = 0; i < placeBuildingTeam1; i++)
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


        //Place Neutral
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

        //Displays GameMap
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
                            Instantiate(Team1[0], new Vector3(x, 1f, z), Quaternion.identity);
                            break;
                        case TileType.RangedUnit_Team1:
                            Instantiate(Team1[1], new Vector3(x, 1f, z), Quaternion.identity);
                            break;
                        case TileType.WizzardUnit_Team1:
                            Instantiate(Team1[2], new Vector3(x, 1f, z), Quaternion.identity);
                            break;
                        case TileType.Resource_Team1:
                            Instantiate(Team1[3], new Vector3(x, 1f, z), Quaternion.identity);
                            break;
                        case TileType.Factory_Team1:
                            Instantiate(Team1[4], new Vector3(x, 1f, z), Quaternion.identity);
                            break;
                        case TileType.MeleeUnit_Team2:
                            Instantiate(Team2[5], new Vector3(x, 1f, z), Quaternion.identity);
                            break;
                        case TileType.RangedUnit_Team2:
                            Instantiate(Team2[6], new Vector3(x, 1f, z), Quaternion.identity);
                            break;
                        case TileType.WizzardUnit_Team2:
                            Instantiate(Team2[7], new Vector3(x, 1f, z), Quaternion.identity);
                            break;
                        case TileType.Resource_Team2:
                            Instantiate(Team2[8], new Vector3(x, 1f, z), Quaternion.identity);
                            break;
                        case TileType.Factory_Team2:
                            Instantiate(Team2[9], new Vector3(x, 1f, z), Quaternion.identity);
                            break;
                        case TileType.Wizzard_Neutral:
                            Instantiate(Neutral[0], new Vector3(x, 1f, z), Quaternion.identity);
                            break;
                    }
                }
            }
        }


    
}

