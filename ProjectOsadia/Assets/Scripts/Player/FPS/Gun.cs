using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    public Transform aimPoint; // AimPoint objesini referans alacak Transform deðiþkeni
    public Transform muzzlePoint; // MuzzlePoint objesini referans alacak Transform deðiþkeni
    public GameObject projectilePrefab; // Fýrlatýlacak projectile prefabini referans alacak GameObject deðiþkeni
    public AudioClip shootingSound; // Ateþ etme sesi

    public Camera customCamera; // Sürüklendiðinde atanacak özel kamera
    public AudioSource audioSource; // Sürüklendiðinde atanacak ses kaynaðý

    public float projectileSpeed = 20f; // Ateþlenen objenin hareket hýzý

    private void Start()
    {
        audioSource = GetComponent<AudioSource>(); // Bu scriptin ekli olduðu nesneden ses kaynaðýný alýyoruz
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0)) // Mouse sol tuþuna basýldýðýnda
        {
            Shoot(); // Ateþ etme fonksiyonunu çaðýrýyoruz
        }
    }

    private void FixedUpdate()
    {
        
    }

    private void Shoot()
    {
        if (customCamera == null)
        {
            Debug.LogError("Kamera atanmamýþ.");
            return;
        }

        if (shootingSound == null)
        {
            Debug.LogError("Ateþ etme sesi atanmamýþ.");
            return;
        }

        Ray ray = customCamera.ScreenPointToRay(Input.mousePosition); // Fare pozisyonundan bir ýþýn oluþturuyoruz

        RaycastHit hit;
        if (Physics.Raycast(ray, out hit)) // Raycast atýyoruz ve deðdiði nesneyi kontrol ediyoruz
        {
            Vector3 hitPoint = hit.point; // Iþýnýn deðdiði noktayý alýyoruz
            Quaternion hitRotation = Quaternion.LookRotation(hit.normal); // Iþýnýn deðdiði normal doðrultusunda bir rotasyon oluþturuyoruz

            Fire(hitPoint); // Deðdiði noktaya doðru ateþ etme fonksiyonunu çaðýrýyoruz
        }
        else
        {
            Vector3 targetPosition = ray.origin + ray.direction * 100f; // Raycast ýþýný bir yere çarpmazsa, raycast yönünde bir hedef noktasý belirliyoruz
            Fire(targetPosition); // Raycast ýþýnýnýn yönüne doðru ateþ etme fonksiyonunu çaðýrýyoruz
        }
    }

    private void Fire(Vector3 targetPosition)
    {
        GameObject projectileObject = Instantiate(projectilePrefab, muzzlePoint.position, muzzlePoint.rotation); // Projectile prefabini MuzzlePoint objesinin pozisyonunda ve rotasyonunda oluþturuyoruz

        Rigidbody projectileRigidbody = projectileObject.GetComponent<Rigidbody>(); // Projectile nesnesinin Rigidbody bileþenini alýyoruz
        if (projectileRigidbody == null)
        {
            projectileRigidbody = projectileObject.AddComponent<Rigidbody>(); // Projectile nesnesine Rigidbody bileþenini ekliyoruz
        }

        projectileRigidbody.velocity = (targetPosition - muzzlePoint.position).normalized * projectileSpeed; // Projectile'a hareket hýzýný ve yönünü vererek ileri doðru hareket etmesini saðlýyoruz

        // Ateþ etme sesini çal
        audioSource.PlayOneShot(shootingSound);
        Debug.Log("Ateþ etme sesi çalýndý.");
    }
}