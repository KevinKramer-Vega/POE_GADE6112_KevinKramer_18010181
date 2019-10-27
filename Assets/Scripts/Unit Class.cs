using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Unit : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    protected int xPos;
    protected int yPos;
    protected int health;
    protected int maxHealth;
    protected int speed;
    protected int attack;
    protected int attackRange;
    protected int faction;
    protected string symbol;
    protected bool isAttacking;
    protected string unitType;

    public abstract void Move(int direction);
    public abstract void Combat(Unit attacker);
    public abstract bool InRange(Unit other);
    // public abstract (Unit, int) Closest(List<Unit> units);
    public abstract void Death();
    public abstract override string ToString();


}

