using Data.Variables;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;


public class HealthController : MonoBehaviour
{
    
    
    [SerializeField] private int health;
    [SerializeField] private bool useStatic;
    [SerializeField] private IntVariable healthVar;
    
    public int Health
    {
        get { return useStatic ? healthVar : health; }
        set { if (useStatic) { healthVar.SetValue(value); } else { health = value; } }
    }

    public UnityEvent OnDeath;
    public UnityEvent OnTakeDamage;

    public void TakeDamage(int amount)
    {
        Health -= amount;
        OnTakeDamage?.Invoke();
        CheckHealth();
    }

    private void CheckHealth()
    {
        if(Health <= 0)
        {
            OnDeath?.Invoke();
        }
    }
}
