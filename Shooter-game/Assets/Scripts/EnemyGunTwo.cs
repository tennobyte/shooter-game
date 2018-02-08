using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGunTwo : Weapon {

    public Transform[] projectileSpawns;
    public GameObject projectile;
    public float projectileSpeed;
    public int burstAmount;
    public float overloadCooldown;

    private int hasShot = 0;

    public override void Shoot()
    {
        if (cooldown <= 0 && hasShot < burstAmount)
        {
            foreach (Transform spawnPoint in projectileSpawns)
            {
                //Instantiate(projectile, spawnPoint.transform.position, spawnPoint.transform.rotation);
                GameObject bullet = PoolManager.instance.GetObject(projectile);

                bullet.transform.localPosition = spawnPoint.transform.position;
                bullet.transform.localRotation = spawnPoint.transform.localRotation;
                bullet.transform.Rotate(0, 0, Random.Range(-20,20));
                Projectile proj = bullet.GetComponent<Projectile>();
                proj.SetSpeed(projectileSpeed);
                bullet.SetActive(true);

                //bullet.GetComponent<Projectile>().friendly = true;
            }
            cooldown = fireRate;
            hasShot++;

            if (hasShot >= burstAmount)
            {
                hasShot = 0;
                cooldown = overloadCooldown;
            }
        }
        
    }
}
