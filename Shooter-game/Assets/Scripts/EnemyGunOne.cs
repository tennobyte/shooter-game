using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGunOne : Weapon {

    public Transform[] projectileSpawns;
    public GameObject projectile;
    public float projectileSpeed;

    public override void Shoot()
    {
        if (cooldown <= 0)
        {
            foreach (Transform spawnPoint in projectileSpawns)
            {
                //Instantiate(projectile, spawnPoint.transform.position, spawnPoint.transform.rotation);
                GameObject bullet = PoolManager.instance.GetObject(projectile);

                bullet.transform.localPosition = spawnPoint.transform.position;
                bullet.transform.localRotation = spawnPoint.transform.localRotation;
                Projectile proj = bullet.GetComponent<Projectile>();
                proj.SetSpeed(projectileSpeed);
                bullet.SetActive(true);
                bullet.SetActive(true);

                //bullet.GetComponent<Projectile>().friendly = true;
            }
            cooldown = fireRate;
        }
    }
}
