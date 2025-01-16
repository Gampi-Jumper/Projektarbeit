using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public GameObject sniperFunction;
    public GameObject minigunFunction;

    private bool isHoldingMouse = false;
    private float timeMinigunShots = 0.15f;
    public AudioSource minigunSound;

    private SpriteRenderer spriteRenderer;
    public Sprite spritePistole;
    public Sprite spriteSniper;
    public Sprite spriteMinigun;
    private int currentGun;

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
        spriteRenderer = GetComponent<SpriteRenderer>();
        reloadTime = PlayerPrefs.GetFloat("ReloadTime", 1.5f);
        maxAmmo = PlayerPrefs.GetInt("MaxAmmo", 5);
        currentAmmo = PlayerPrefs.GetInt("MaxAmmo", 5);
        UpdateAmmoUI();
        currentGun = PlayerPrefs.GetInt("CurrentGun", 1);
        if(currentGun == 3)
        {
            spriteRenderer.sprite = spriteMinigun;
            sniperFunction.SetActive(false);
            minigunFunction.SetActive(true);
        }
        if(currentGun == 2)
        {
            spriteRenderer.sprite = spriteSniper;
            sniperFunction.SetActive(true);
            minigunFunction.SetActive(false);
        }
        if(currentGun == 1)
        {
            spriteRenderer.sprite = spritePistole;
            sniperFunction.SetActive(false);
            minigunFunction.SetActive(false);
        }
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

        currentGun = PlayerPrefs.GetInt("CurrentGun", 1);
        if (currentGun == 3)
        {
            if (Input.GetMouseButtonDown(0) && !isHoldingMouse)
            {
                isHoldingMouse = true;
                minigunSound.loop = true;
                minigunSound.Play();
                StartCoroutine(ShootingMinigun());
            }
            if (Input.GetMouseButtonUp(0))
            {
                isHoldingMouse = false;
                minigunSound.Stop();
            }
        }
        else
        {
            if (Input.GetMouseButtonDown(0))
            {
                Shoot();
            }
        }


        if (Input.GetMouseButtonDown(1) && currentAmmo < maxAmmo && currentGun != 3)
        {
            StartCoroutine(Reload());
        }
    }

    private IEnumerator ShootingMinigun()
    {
        while (isHoldingMouse)
        {
            Instantiate(projectile, shotPoint.position, shotPoint.rotation);
            yield return new WaitForSeconds(timeMinigunShots);
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
        if(reloadTime == 0.5f)
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
