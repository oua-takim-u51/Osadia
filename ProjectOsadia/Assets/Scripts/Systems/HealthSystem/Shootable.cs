using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Shootable : MonoBehaviour
{
    [SerializeField] HealthSystemComponent health;
    [SerializeField] int hp = 100;
    private HealthSystem healthSystem;

    public static event EventHandler OnShootableDead;
    private class ShootableEventArgs : EventArgs
    {
        
    }
    
    private void Start()
    {
        healthSystem = health.GetHealthSystem();
        healthSystem.SetHealthMax(hp, true);
        healthSystem.OnDead += HealthSystem_OnDead;
    }
    
    private void HealthSystem_OnDead(object sender, System.EventArgs e)
    {
        Debug.Log("Vurulan nesne öldü. " +  healthSystem.IsDead());
        OnShootableDead?.Invoke(this, EventArgs.Empty);
    }
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.collider.CompareTag("Bullet"))
        {
            if(healthSystem.IsDead() == false) 
            { 
               healthSystem.Damage(20);
               Debug.Log("Hit! Kalan can : " + healthSystem.GetHealth());
            }
        }
    }
}
