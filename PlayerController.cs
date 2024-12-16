using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed;
    public float offset;

    public Transform shotPoint;
    public GameObject projectile;

    public float timeBetweenShots;
    float nextShotTime;

    public int maxAmmo = 5;       // Maximale Schüsse im Magazin
    public int currentAmmo;       // Aktuelle Anzahl der Schüsse
    public float reloadTime = 2f; // Dauer des Nachladens in Sekunden
    private bool isReloading = false;

    public GameObject ammoImagePrefab; // Prefab für ein Munitionsbild
    public Transform ammoContainer;   // Container für die Munitionsbilder

    public AudioSource shootSound;
    public AudioSource reloadSound;
    public AudioSource emptyGunSound;

    void Start()
    {
        UpdateAmmoUI();
    }

    void Update()
    {
        Vector3 playerInput = new Vector3(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"), 0);
        transform.position += playerInput.normalized * speed * Time.deltaTime;

        Vector3 displacement = transform.position - Camera.main.ScreenToWorldPoint(Input.mousePosition);
        float angle = Mathf.Atan2(displacement.y, displacement.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0f, 0f, angle + offset);

        if (isReloading)
        {
            return;
        }
        if (Input.GetMouseButtonDown(0))
        {
            Shoot();
        }
        if (Input.GetMouseButtonDown(1) && currentAmmo < maxAmmo)
        {
            StartCoroutine(Reload());
        }
    }

    void Shoot()
    {
        if (currentAmmo > 0)
        {
            if (Time.time > nextShotTime)
            {
                currentAmmo--;
                UpdateAmmoUI();
                shootSound.Play();
                nextShotTime = Time.time + timeBetweenShots;
                Instantiate(projectile, shotPoint.position, shotPoint.rotation);
            }

        }
        else
        {
            emptyGunSound.Play();
        }
    }

    IEnumerator Reload()
    {
        isReloading = true;
        reloadSound.Play();
        yield return new WaitForSeconds(reloadTime);
        currentAmmo = maxAmmo;
        isReloading = false;
        UpdateAmmoUI();
    }

    void UpdateAmmoUI()
    {
        foreach (Transform child in ammoContainer)
        {
            Destroy(child.gameObject);
        }

        for (int i = 0; i < currentAmmo; i++)
        {
            Instantiate(ammoImagePrefab, ammoContainer);
        }
    }
}
