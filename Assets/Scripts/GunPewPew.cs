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
        GameObject bulletObject = Instantiate(bulletPrefab);
        bulletObject.transform.position = this.transform.position + playerCamera.transform.forward;
        bulletObject.transform.forward = playerCamera.transform.forward;
    }
}
