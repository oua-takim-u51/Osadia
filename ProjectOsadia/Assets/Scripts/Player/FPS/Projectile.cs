using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public AudioClip impactSound; // Projektilin çarpma sesi

    private AudioSource audioSource;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>(); // AudioSource bileþenini al

        Destroy(gameObject, 10f); // 10 saniye sonra projektili yok et
    }

    private void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        HandleCollision(other.gameObject); // Çarpýþma iþlemini gerçekleþtir

        if (other.transform.parent != null)
        {
            HandleCollision(other.transform.parent.gameObject); // Çarpýþma iþlemini parent obje için gerçekleþtir
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        HandleCollision(collision.gameObject); // Çarpýþma iþlemini gerçekleþtir

        if (collision.transform.parent != null)
        {
            HandleCollision(collision.transform.parent.gameObject); // Çarpýþma iþlemini parent obje için gerçekleþtir
        }
    }

    private void HandleCollision(GameObject collidedObject)
    {
        if (collidedObject.CompareTag("Enemy")) // Çarpan objenin tagini "Enemy" ile kontrol et
        {
            Destroy(collidedObject); // Eðer tag "Enemy" ise, objeyi yok et
        }

        audioSource.PlayOneShot(impactSound); // Çarpma sesini çal
        
        Destroy(gameObject); // Projektili çarptýktan sonra yok et
    }
}