using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class GameEngine : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    
    Map map;
    private int round;

    public int Round
    {
        get { return round; }
    }
    public void Update()
    {
        foreach (Building d in map.Buildings)
        {
            if (d is FactoryBuilding)
            {
                FactoryBuilding fb = (FactoryBuilding)d;
                if (fb.ProductionSpeed % Round == 0)
                {
                    map.Units.Add(fb.Spawn());
                }
            }
        }
        for (int i = 0; i < map.Units.Count; i++)
        {
            if (map.Units[i] is MeleeUnit)
            {
                MeleeUnit mu = (MeleeUnit)map.Units[i];
                mu.Health = 10;// tests code
                if (mu.Health <= mu.MaxHealth * 0.25)// Escape!!!( Running away)
                {
                    mu.Move(Random.Range(0, 4));
                }
                else
                {
                    int shortest = 100;
                    Unit closest = mu;
                    foreach (Unit u in map.Units)
                    {
                        if (u is MeleeUnit)
                        {
                            MeleeUnit otherMu = (MeleeUnit)u;
                            int distance = System.Math.Abs(mu.XPos - otherMu.XPos)
                                     + System.Math.Abs(mu.YPos - otherMu.YPos);// Have to use system.Math in order to use random range method
                            if (distance < shortest)
                            {
                                shortest = distance;
                                closest = otherMu;
                            }
                        }
                    }
                    //Check In Range
                    if (shortest <= mu.AttackRange)
                    {
                        mu.IsAttacking = true;
                        mu.Combat(closest);
                    }
                    else // Move towards
                    {
                        if (closest is MeleeUnit)
                        {
                            MeleeUnit closestMu = (MeleeUnit)closest;
                            if (mu.XPos > closestMu.XPos)//North
                            {
                                mu.Move(0);
                            }
                            else if (mu.XPos < closestMu.XPos)//South
                            {
                                mu.Move(2);
                            }
                            else if (mu.XPos > closestMu.YPos)//West
                            {
                                mu.Move(3);
                            }
                            else if (mu.XPos < closestMu.YPos)//East
                            {
                                mu.Move(1);
                            }
                        }
                    }
                }
            }
            if (map.Units[i] is RangedUnit)
            {
                RangedUnit ru = (RangedUnit)map.Units[i];
                // ru.Health = 10;// tests code
                if (ru.Health <= ru.MaxHealth * 0.25)// Escape!!!( Running away)
                {
                    ru.Move(Random.Range(0, 4));
                }
                else
                {
                    int shortest = 100;
                    Unit closest = ru;
                    foreach (Unit u in map.Units)
                    {
                        if (u is RangedUnit)
                        {
                            RangedUnit otherRu = (RangedUnit)u;
                            int distance =System.Math.Abs(ru.XPos - otherRu.XPos)
                                     + System.Math.Abs(ru.YPos - otherRu.YPos);
                            if (distance < shortest)
                            {
                                shortest = distance;
                                closest = otherRu;
                            }
                        }
                    }
                    //Check In Range
                    if (shortest <= ru.AttackRange)
                    {
                        ru.IsAttacking = true;
                        ru.Combat(closest);
                    }
                    else // Move towards
                    {
                        if (closest is RangedUnit)
                        {
                            RangedUnit closestRu = (RangedUnit)closest;
                            if (ru.XPos > closestRu.XPos)//North
                            {
                                ru.Move(0);
                            }
                            else if (ru.XPos < closestRu.XPos)//South
                            {
                                ru.Move(2);
                            }
                            else if (ru.XPos > closestRu.YPos)//West
                            {
                                ru.Move(3);
                            }
                            else if (ru.XPos < closestRu.YPos)//East
                            {
                                ru.Move(1);
                            }
                        }
                    }
                }
            }
            if (map.Units[i] is WizzardUnit)//task 3 new wizzard unit
            {
                WizzardUnit wu = (WizzardUnit)map.Units[i];
                if (wu.Health <= wu.MaxHealth * 0.50)// Escape!!!( Running away)
                {
                    wu.Move(Random.Range(0, 4));
                }
                else
                {
                    int shortest = 100;
                    Unit closest = wu;
                    foreach (Unit u in map.Units)
                    {
                        if (u is WizzardUnit)
                        {
                            WizzardUnit otherWu = (WizzardUnit)u;
                            int distance = System.Math.Abs(wu.XPos - otherWu.XPos)
                                     +System.Math.Abs(wu.YPos - otherWu.YPos);
                            if (distance < shortest)
                            {
                                shortest = distance;
                                closest = otherWu;
                            }
                        }
                    }
                    //Check In Range
                    if (shortest <= wu.AttackRange)
                    {
                        wu.IsAttacking = true;
                        wu.Combat(closest);
                    }
                    else // Move towards
                    {
                        if (closest is WizzardUnit)
                        {
                            WizzardUnit closestWu = (WizzardUnit)closest;
                            if (wu.XPos > closestWu.XPos)//North
                            {
                                wu.Move(0);
                            }
                            else if (wu.XPos < closestWu.XPos)//South
                            {
                                wu.Move(2);
                            }
                            else if (wu.XPos > closestWu.YPos)//West
                            {
                                wu.Move(3);
                            }
                            else if (wu.XPos < closestWu.YPos)//East
                            {
                                wu.Move(1);
                            }
                        }
                    }
                }
            }
            if (map.Units[i] is NeutralTeam)//Neutral
            {
                NeutralTeam nt = (NeutralTeam)map.Units[i];
                if (nt.Health <= nt.MaxHealth * 0.50)// Escape!!!( Running away)
                {
                    nt.Move(Random.Range(0, 4));
                }
                else
                {
                    int shortest = 100;
                    Unit closest = nt;
                    foreach (Unit u in map.Units)
                    {
                        if (u is NeutralTeam)
                        {
                            NeutralTeam otherNt = (NeutralTeam)u;
                            int distance = System.Math.Abs(nt.XPos - otherNt.XPos)
                                     + System.Math.Abs(nt.YPos - otherNt.YPos);
                            if (distance < shortest)
                            {
                                shortest = distance;
                                closest = otherNt;
                            }
                        }
                    }
                    //Check In Range
                    if (shortest <= nt.AttackRange)
                    {
                        nt.IsAttacking = true;
                        nt.Combat(closest);
                    }
                    else // Move towards
                    {
                        if (closest is WizzardUnit)
                        {
                            WizzardUnit closestWu = (WizzardUnit)closest;
                            if (nt.XPos > closestWu.XPos)//North
                            {
                                nt.Move(0);
                            }
                            else if (nt.XPos < closestWu.XPos)//South
                            {
                                nt.Move(2);
                            }
                            else if (nt.XPos > closestWu.YPos)//West
                            {
                                nt.Move(3);
                            }
                            else if (nt.XPos < closestWu.YPos)//East
                            {
                                nt.Move(1);
                            }
                        }
                    }
                }
            }
        }
        map.Display();
        round++;
    }

    public int DistanceTo(Unit a, Unit b)
    {
        int distance = 0;

        if (a is MeleeUnit && b is MeleeUnit)
        {
            MeleeUnit start = (MeleeUnit)a;
            MeleeUnit end = (MeleeUnit)b;
            distance = System.Math.Abs(start.XPos - end.XPos) + System.Math.Abs(start.YPos - end.YPos);
        }
        else if (a is RangedUnit && b is MeleeUnit)
        {
            RangedUnit start = (RangedUnit)a;
            MeleeUnit end = (MeleeUnit)b;
            distance = System.Math.Abs(start.XPos - end.XPos) + System.Math.Abs(start.YPos - end.YPos);
        }
        else if (a is RangedUnit && b is RangedUnit)
        {
            RangedUnit start = (RangedUnit)a;
            RangedUnit end = (RangedUnit)b;
            distance = System.Math.Abs(start.XPos - end.XPos) + System.Math.Abs(start.YPos - end.YPos);
        }
        else if (a is MeleeUnit && b is RangedUnit)
        {
            MeleeUnit start = (MeleeUnit)a;
            RangedUnit end = (RangedUnit)b;
            distance = System.Math.Abs(start.XPos - end.XPos) + System.Math.Abs(start.YPos - end.YPos);
        }
        //Task 3 new wizzard unit
        else if (a is WizzardUnit && b is MeleeUnit)
        {
            WizzardUnit start = (WizzardUnit)a;
            MeleeUnit end = (MeleeUnit)b;
            distance = System.Math.Abs(start.XPos - end.XPos) + System.Math.Abs(start.YPos - end.YPos);
        }
        else if (a is WizzardUnit && b is RangedUnit)
        {
            WizzardUnit start = (WizzardUnit)a;
            RangedUnit end = (RangedUnit)b;
            distance = System.Math.Abs(start.XPos - end.XPos) + System.Math.Abs(start.YPos - end.YPos);
        }
        else if (a is MeleeUnit && b is WizzardUnit)
        {
            MeleeUnit start = (MeleeUnit)a;
            WizzardUnit end = (WizzardUnit)b;
            distance = System.Math.Abs(start.XPos - end.XPos) + System.Math.Abs(start.YPos - end.YPos);
        }
        else if (a is RangedUnit && b is WizzardUnit)
        {
            RangedUnit start = (RangedUnit)a;
            WizzardUnit end = (WizzardUnit)b;
            distance = System.Math.Abs(start.XPos - end.XPos) + System.Math.Abs(start.YPos - end.YPos);
        }
        //Neutral Team units
        else if (a is NeutralTeam && b is MeleeUnit)
        {
            NeutralTeam start = (NeutralTeam)a;
            MeleeUnit end = (MeleeUnit)b;
            distance = System.Math.Abs(start.XPos - end.XPos) + System.Math.Abs(start.YPos - end.YPos);
        }
        else if (a is NeutralTeam && b is RangedUnit)
        {
            NeutralTeam start = (NeutralTeam)a;
            RangedUnit end = (RangedUnit)b;
            distance = System.Math.Abs(start.XPos - end.XPos) + System.Math.Abs(start.YPos - end.YPos);
        }
        else if (a is MeleeUnit && b is NeutralTeam)
        {
            MeleeUnit start = (MeleeUnit)a;
            NeutralTeam end = (NeutralTeam)b;
            distance = System.Math.Abs(start.XPos - end.XPos) + System.Math.Abs(start.YPos - end.YPos);
        }
        else if (a is RangedUnit && b is NeutralTeam)
        {
            RangedUnit start = (RangedUnit)a;
            NeutralTeam end = (NeutralTeam)b;
            distance = System.Math.Abs(start.XPos - end.XPos) + System.Math.Abs(start.YPos - end.YPos);
        }
        return distance;
    }

}

