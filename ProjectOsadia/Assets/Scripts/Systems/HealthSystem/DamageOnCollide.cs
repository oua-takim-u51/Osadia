using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageOnCollide : MonoBehaviour
{
    public float damageAmount = 20f;
    private GameObject player;
    private HealthSystem healthSystem;

    //private void OnCollisionEnter(Collision collision)
    //{
    //    if(collision.collider.gameObject.GetType() == typeof(PlayerControllerFPS))
    //    player = collision.gameObject;
    //    healthSystem = collision.gameObject.GetComponent<HealthSystemComponent>().GetHealthSystem();
    //    healthSystem.Damage(damageAmount);
    //}

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Damage Triggered!" + damageAmount);
        if (other.gameObject.name == "Player")
            player = other.gameObject;
        healthSystem = other.gameObject.GetComponent<HealthSystemComponent>().GetHealthSystem();
        healthSystem.Damage(damageAmount);
        Debug.Log(healthSystem.GetHealth());
    }
}
