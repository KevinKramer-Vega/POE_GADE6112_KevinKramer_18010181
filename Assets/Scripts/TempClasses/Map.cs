using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Map : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    List<Building> buildings = new List<Building>();//task 2
    List<Unit> units = new List<Unit>();
    int numUnits=0 ;
    int numBuildings=0;//task 2
   
   

    public List<Building> Buildings
    {
        get { return buildings; }
        set { buildings = value; }
    }
    public List<Unit> Units
    {
        get { return units; }
        set { units = value; }
    }

    
    

    public void Generate()
    {

        for (int i = 0; i < numUnits; i++)
        {
            if (Random.Range(0, 4) == 0)//Generate MeleeUnit
            {
                MeleeUnit m = new MeleeUnit(Random.Range(0, 20),
                                           Random.Range(0, 20),
                                           120,
                                           1,
                                           20,
                                          (i % 2 == 0 ? 1 : 0),
                                          "M",
                                          "Ninja");//task 2 unit type 
                units.Add(m);
            }
            else if (Random.Range(0, 4) == 1)// Generate RangedUnit
            {
                RangedUnit r = new RangedUnit(Random.Range(0, 20),
                                           Random.Range(0, 20),
                                           100,
                                           1,
                                           20,
                                           5,
                                          (i % 2 == 0 ? 1 : 0),
                                          "R",
                                          "Archer");//task 2 unit type
                units.Add(r);
            }
            else if (Random.Range(0, 4) == 2) //task 3-Generate WizzardUnit
            {
                WizzardUnit w = new WizzardUnit(Random.Range(0, 20),
                                           Random.Range(0, 20),
                                           100,
                                           1,
                                           20,
                                           (i % 2 == 0 ? 1 : 0),
                                           "W",
                                           "Mage");
                units.Add(w);
            }
            else//Generates the neutral unit
            {
                NeutralTeam n = new NeutralTeam(Random.Range(0, 20),
                                           Random.Range(0, 20),
                                           100,
                                           1,
                                           20,
                                           "NW",
                                           "Rouge");
                units.Add(n);
            }

        }
        for (int i = 0; i < numBuildings; i++)
        {
            if (Random.Range(0, 2) == 0)
            {
                ResourceBuilding rb = new ResourceBuilding(Random.Range(0, 20),
                                                          Random.Range(0, 20),
                                                          200,
                                                          (i % 2 == 0 ? 1 : 0),
                                                          "RB");
                buildings.Add(rb);
            }
            else
            {
                FactoryBuilding fb = new FactoryBuilding(Random.Range(0, 20),
                                                          Random.Range(0, 20),
                                                          200,
                                                          (i % 2 == 0 ? 1 : 0),
                                                          "FB");
                buildings.Add(fb);
            }
        }
    }
}

