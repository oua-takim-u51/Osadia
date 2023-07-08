using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealOnCollide : MonoBehaviour
{
    public float healAmount = 20f;
    private GameObject player;
    private HealthSystem healthSystem;

    //private void OnCollisionEnter(Collision collision)
    //{
    //    if(collision.collider.gameObject.GetType() == typeof(PlayerControllerFPS))
    //    player = collision.gameObject;
    //    healthSystem = collision.gameObject.GetComponent<HealthSystemComponent>().GetHealthSystem();
    //}

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Healed Triggered!" + healAmount);
        if (other.gameObject.name == "Player")
        player = other.gameObject;
        healthSystem = other.gameObject.GetComponent<HealthSystemComponent>().GetHealthSystem();
        healthSystem.Heal(healAmount);
        Debug.Log(healthSystem.GetHealth());
    }
}
