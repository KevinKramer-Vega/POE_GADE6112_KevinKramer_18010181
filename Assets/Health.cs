using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField]
    private int MaxHealth = 100;

    private int currentHealth;

    public event Action<float> OnHealthPctChanged = delegate { };
    public void ModifyHealth(int amount)
    {
        currentHealth += MaxHealth;
        float currentHealthPct = (float)currentHealth / (float)MaxHealth;
        OnHealthPctChanged(currentHealthPct);
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
   private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            ModifyHealth(-10);
        }
    }
}
