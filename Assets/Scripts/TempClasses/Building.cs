using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Building : MonoBehaviour
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
    protected int faction;
    protected string symbol;

    public abstract void Destruction();
    public abstract override string ToString();
}
