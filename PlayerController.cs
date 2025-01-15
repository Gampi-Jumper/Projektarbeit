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

    private int maxAmmo;
    private int currentAmmo;
    private float reloadTime;
    private bool isReloading = false;

    public GameObject ammoImagePrefab;
    public Transform ammoContainer;

    public AudioSource shootSound;
    public AudioSource longReloadSound;
    public AudioSource mediumReloadSound;
    public AudioSource shortReloadSound;
    public AudioSource emptyGunSound;

    void Start()
    {
        reloadTime = PlayerPrefs.GetFloat("ReloadTime", 1.5f);
        maxAmmo = PlayerPrefs.GetInt("MaxAmmo", 5);
        currentAmmo = PlayerPrefs.GetInt("MaxAmmo", 5);
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
        reloadTime = PlayerPrefs.GetFloat("ReloadTime", 1.5f);
        if(reloadTime == 1.5f)
        {
            longReloadSound.Play();        
        }
        if(reloadTime == 1f)
        {
            mediumReloadSound.Play();        
        }
        if(reloadTime == 1.5f)
        {
            shortReloadSound.Play();        
        }
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
