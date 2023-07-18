using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    public Transform aimPoint; // AimPoint objesini referans alacak Transform de�i�keni
    public Transform muzzlePoint; // MuzzlePoint objesini referans alacak Transform de�i�keni
    public GameObject projectilePrefab; // F�rlat�lacak projectile prefabini referans alacak GameObject de�i�keni
    public AudioClip shootingSound; // Ate� etme sesi

    public Camera customCamera; // S�r�klendi�inde atanacak �zel kamera
    public AudioSource audioSource; // S�r�klendi�inde atanacak ses kayna��

    public float projectileSpeed = 20f; // Ate�lenen objenin hareket h�z�

    private void Start()
    {
        audioSource = GetComponent<AudioSource>(); // Bu scriptin ekli oldu�u nesneden ses kayna��n� al�yoruz
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0)) // Mouse sol tu�una bas�ld���nda
        {
            Shoot(); // Ate� etme fonksiyonunu �a��r�yoruz
        }
    }

    private void FixedUpdate()
    {
        
    }

    private void Shoot()
    {
        if (customCamera == null)
        {
            Debug.LogError("Kamera atanmam��.");
            return;
        }

        if (shootingSound == null)
        {
            Debug.LogError("Ate� etme sesi atanmam��.");
            return;
        }

        Ray ray = customCamera.ScreenPointToRay(Input.mousePosition); // Fare pozisyonundan bir ���n olu�turuyoruz

        RaycastHit hit;
        if (Physics.Raycast(ray, out hit)) // Raycast at�yoruz ve de�di�i nesneyi kontrol ediyoruz
        {
            Vector3 hitPoint = hit.point; // I��n�n de�di�i noktay� al�yoruz
            Quaternion hitRotation = Quaternion.LookRotation(hit.normal); // I��n�n de�di�i normal do�rultusunda bir rotasyon olu�turuyoruz

            Fire(hitPoint); // De�di�i noktaya do�ru ate� etme fonksiyonunu �a��r�yoruz
        }
        else
        {
            Vector3 targetPosition = ray.origin + ray.direction * 100f; // Raycast ���n� bir yere �arpmazsa, raycast y�n�nde bir hedef noktas� belirliyoruz
            Fire(targetPosition); // Raycast ���n�n�n y�n�ne do�ru ate� etme fonksiyonunu �a��r�yoruz
        }
    }

    private void Fire(Vector3 targetPosition)
    {
        GameObject projectileObject = Instantiate(projectilePrefab, muzzlePoint.position, muzzlePoint.rotation); // Projectile prefabini MuzzlePoint objesinin pozisyonunda ve rotasyonunda olu�turuyoruz

        Rigidbody projectileRigidbody = projectileObject.GetComponent<Rigidbody>(); // Projectile nesnesinin Rigidbody bile�enini al�yoruz
        if (projectileRigidbody == null)
        {
            projectileRigidbody = projectileObject.AddComponent<Rigidbody>(); // Projectile nesnesine Rigidbody bile�enini ekliyoruz
        }

        projectileRigidbody.velocity = (targetPosition - muzzlePoint.position).normalized * projectileSpeed; // Projectile'a hareket h�z�n� ve y�n�n� vererek ileri do�ru hareket etmesini sa�l�yoruz

        // Ate� etme sesini �al
        audioSource.PlayOneShot(shootingSound);
        Debug.Log("Ate� etme sesi �al�nd�.");
    }
}