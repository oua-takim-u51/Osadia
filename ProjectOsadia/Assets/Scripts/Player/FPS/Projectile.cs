using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public AudioClip impactSound; // Projektilin �arpma sesi

    private AudioSource audioSource;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>(); // AudioSource bile�enini al

        Destroy(gameObject, 10f); // 10 saniye sonra projektili yok et
    }

    private void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        HandleCollision(other.gameObject); // �arp��ma i�lemini ger�ekle�tir

        if (other.transform.parent != null)
        {
            HandleCollision(other.transform.parent.gameObject); // �arp��ma i�lemini parent obje i�in ger�ekle�tir
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        HandleCollision(collision.gameObject); // �arp��ma i�lemini ger�ekle�tir

        if (collision.transform.parent != null)
        {
            HandleCollision(collision.transform.parent.gameObject); // �arp��ma i�lemini parent obje i�in ger�ekle�tir
        }
    }

    private void HandleCollision(GameObject collidedObject)
    {
        if (collidedObject.CompareTag("Enemy")) // �arpan objenin tagini "Enemy" ile kontrol et
        {
            Destroy(collidedObject); // E�er tag "Enemy" ise, objeyi yok et
        }

        audioSource.PlayOneShot(impactSound); // �arpma sesini �al
        
        Destroy(gameObject); // Projektili �arpt�ktan sonra yok et
    }
}