using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossTurret : Weapon, IDestroyable {

    public Transform barrel;
    public Transform player;
    public GameObject projectile;
    public float maxHealth;
    public float health;
    public float rotationSpeed;
    public float projectileSpeed;
    public int burstAmount;
    public float overloadCooldown;
    public bool isActive;

    public BossShip bossShip;

    private int hasShot = 0;

    void Start () {
        isActive = false;
        GameObject playerGO = GameManager.instance.player.gameObject;
        if (playerGO != null)
        {
            player = playerGO.transform;
            //isActive = true;
        }
    }
	
	void Update () {
        if (isActive)
        {
            Vector3 direction = player.position - transform.position;
            Quaternion rotation = Quaternion.LookRotation(direction, -Vector3.forward);
            transform.rotation = Quaternion.Lerp(transform.rotation, rotation, rotationSpeed);

            if (cooldown > 0)
            {
                cooldown = cooldown - Time.deltaTime;
            }
        }
    }

    public override void Shoot()
    {
        if (cooldown <= 0 && hasShot < burstAmount && isActive)
        {
            AudioManager.instance.PlayShootingSound();
            GameObject bullet = PoolManager.instance.GetObject(projectile);

            bullet.transform.position = barrel.transform.position;
            bullet.transform.rotation = barrel.transform.rotation;
            Projectile proj = bullet.GetComponent<Projectile>();
            proj.SetSpeed(projectileSpeed);
            bullet.SetActive(true);

            cooldown = fireRate;
            hasShot++;

            if (hasShot >= burstAmount)
            {
                hasShot = 0;
                cooldown = overloadCooldown;
            }
        }
    }

    public void ReceiveDamage (float value)
    {
        if (isActive)
        {
            health -= value;
            if (health <= 0)
            {
                Destroy();
            }
        }
    }

    public void Destroy()
    {
        AudioManager.instance.PlayExplosionSound();
        bossShip.ReceiveDamage(200);
        GameObject hitPS = PoolManager.instance.GetObject(GameManager.instance.hitExplosions);
        hitPS.transform.position = transform.position;
        hitPS.transform.rotation = transform.rotation;
        hitPS.SetActive(true);
        ParticleSystem ps = hitPS.GetComponent<ParticleSystem>();
        ps.Emit(10);
        gameObject.GetComponent<Collider2D>().enabled = false;
        isActive = false;
    }
}
