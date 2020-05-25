using System.Collections;
using UnityEngine;

public abstract class GunPewPew : MonoBehaviour
{
    [SerializeField]
    private Camera playerCamera;

    [SerializeField]
    protected float damage;
    [SerializeField]
    protected float range;
    [SerializeField]
    protected float fireRate;
    [SerializeField]
    protected float maxAmmo;
    [SerializeField]
    protected float reloadTimer;

    protected float currentAmmo;
    protected float nextTimeToFire = 0f;
    protected bool isReloading;

    [SerializeField]
    private ParticleSystem impact;
    [SerializeField]
    private ParticleSystem muzzleFlash;

    private void Start()
    {
        currentAmmo = maxAmmo;
    }


    void Update()
    {
        if (isReloading)
        {
            return;
        }
        if (currentAmmo <= 0)
        {
            StartCoroutine(Reload());
            return;
        }
        if (Input.GetButton("Fire1") && Time.time >= nextTimeToFire && currentAmmo != 0)
        {
            nextTimeToFire = Time.time + 1f / fireRate;
            currentAmmo--;
            Shoot();
        }
    }

    protected virtual void Shoot()
    {
        Ray ray = playerCamera.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0f));
        RaycastHit hit;
        if(Physics.Raycast(ray, out hit))
        {
            ParticleSystem impactParticle = Instantiate(impact, hit.point, Quaternion.identity);
            impactParticle.Play();
            WeaponProperties();
        }
        muzzleFlash.Play();

    }

    protected abstract void WeaponProperties();

    IEnumerator Reload()
    {
        isReloading = true;
        Debug.Log("reloading");
        yield return new WaitForSeconds(reloadTimer);
        Debug.Log("done");
        currentAmmo = maxAmmo;
        isReloading = false;
    }
}
