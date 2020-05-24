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

    protected float nextTimeToFire = 0f;

    [SerializeField]
    private ParticleSystem impact;
    [SerializeField]
    private ParticleSystem muzzleFlash;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButton("Fire1") && Time.time >= nextTimeToFire)
        {
            nextTimeToFire = Time.time + 1f / fireRate;
            Shoot();
        }
    }

    private void Shoot()
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
}
