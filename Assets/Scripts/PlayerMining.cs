using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public class PlayerMining : MonoBehaviour
{
    public Transform firePoint;
    public GameObject projectile;
    public float fireRate = 0.6f;
    public int miningPower = 1;

    private float nextFireTime = 0f;

    private void Update()
    {
        //Get input from miner
        if (Input.GetMouseButton(0) && Time.time >= nextFireTime)
        {
            //spawn projectile
            Projectile newProjectile = Instantiate(projectile, firePoint.position, firePoint.rotation).GetComponent<Projectile>();
            newProjectile.damage = miningPower;

            if (AudioManager.Instance != null)
            {
                AudioManager.Instance.PlayLaser();
            }

            nextFireTime = Time.time + fireRate;
        }
    }
}
