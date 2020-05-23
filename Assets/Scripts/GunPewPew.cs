using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunPewPew : MonoBehaviour
{
    [SerializeField]
    private Camera playerCamera;

    [SerializeField]
    private GameObject bulletPrefab;
    [SerializeField]
    private float damage;
    [SerializeField]
    private float range;
    [SerializeField]
    private float fireRate;

    [SerializeField]
    private ParticleSystem impact;
    [SerializeField]
    private ParticleSystem muzzleFlash;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
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
        }
        muzzleFlash.Play();

    }
}
