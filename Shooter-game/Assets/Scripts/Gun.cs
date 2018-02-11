using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : Weapon {

    public Transform[] projectileSpawns;
    public GameObject projectile;


    public override void Shoot()
    {
        if (cooldown <= 0)
        {
            foreach (Transform spawnPoint in projectileSpawns)
            {
                AudioManager.instance.PlayShootingSound();
                //Instantiate(projectile, spawnPoint.transform.position, spawnPoint.transform.rotation);
                GameObject bullet = PoolManager.instance.GetObject(projectile);

                bullet.transform.localPosition = spawnPoint.transform.position;
                bullet.transform.localRotation = spawnPoint.transform.localRotation;
                bullet.SetActive(true);
                
                //bullet.GetComponent<Projectile>().friendly = true;
            }
            cooldown = fireRate;
        }
    }
}
