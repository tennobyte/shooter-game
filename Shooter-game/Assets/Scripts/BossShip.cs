using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossShip : MonoBehaviour, IDestroyable, ISwitchable
{
    public Weapon[] turrets;
    public Weapon lazer;
    public float health;
    public float maxHealth;
    public int points;
    public float speed;
    public float tiltValue;
    public Rigidbody2D rb;
    public bool shootingEnabled;

    public Transform beacon;

    // Use this for initialization
    void Start () {
        rb = GetComponent<Rigidbody2D>();
        shootingEnabled = false;
    }

    public void SwitchOn()
    {
        shootingEnabled = true;
        foreach (BossTurret turret in turrets)
        {
            turret.isActive = true;
            turret.GetComponent<Collider2D>().enabled = true;
            turret.health = turret.maxHealth;
        }
    }

    void OnEnable()
    {
        health = maxHealth;
        shootingEnabled = false;
        foreach (BossTurret turret in turrets)
        {
            turret.gameObject.SetActive(true);
            turret.isActive = false;
            turret.GetComponent<Collider2D>().enabled = true;
        }
    }

    // Update is called once per frame
    void Update () {
        if (shootingEnabled)
        {
            foreach (Weapon turret in turrets)
            {
                turret.Shoot();
            }

            lazer.Shoot();
        }

        if (beacon != null)
        {
            rb.AddForce((beacon.position - transform.position) * speed);
        }
        //rb.AddForce((Vector2)new Vector3(-transform.position.x, -transform.position.y) + Random.insideUnitCircle);
        rb.AddForce(Random.insideUnitCircle);
        float movement = rb.velocity.y;
        transform.localRotation = Quaternion.Euler(0, tiltValue * movement, 0);
    }

    public void ReceiveDamage(float value)
    {
        if (shootingEnabled)
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
        GameManager.instance.addPoints(points);
        GameObject hitPS = PoolManager.instance.GetObject(GameManager.instance.hitExplosions);
        hitPS.transform.position = transform.position;
        hitPS.transform.rotation = transform.rotation;
        hitPS.SetActive(true);
        ParticleSystem ps = hitPS.GetComponent<ParticleSystem>();
        ps.Emit(20);
        gameObject.SetActive(false);
    }
}
