using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResourceBuilding : Building
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public bool IsDestroyed { get; set; }

    public int XPos
    {
        get { return base.xPos; }
        set { base.xPos = value; }
    }
    public int YPos
    {
        get { return base.yPos; }
        set { base.yPos = value; }
    }
    public int Health
    {
        get { return base.health; }
        set { base.health = value; }
    }
    public int MaxHealth
    {
        get { return base.maxHealth; }
    }

    public int Faction
    {
        get { return base.faction; }
    }
    public string Symbol
    {
        get { return base.symbol; }
        set { base.symbol = value; }
    }

    public string resourceType = " Gold ";
    public int resourceGen = 0;
    public int resourcePR = 0;
    public int remaining = 500;


    public override void Destruction()
    {
        if (Health <= 0)
        {
            symbol = "XX";
            IsDestroyed = true;
        }
    }

    public void ResourceGenerator()
    {
      
    }

    public override string ToString()
    {
        string temp = " ";
        temp += "Building :";
        temp += "(" + Symbol + ")";
        temp += "(" + XPos + "," + YPos + ")";
        temp += Health;
        temp += (IsDestroyed ? "Destroyed : " : "Standing");
        temp += "Resource Type :  " + resourceType;
        temp += "Resources Per a round :  " + resourcePR;
        temp += "Resources Remaining : " + remaining;
        return temp;
    }
    public ResourceBuilding(int x, int y, int h, int f, string sym)
    {
        XPos = x;
        YPos = y;
        Health = h;
        base.maxHealth = h;
        base.faction = f;
        Symbol = sym;
        IsDestroyed = false;
    }
}

