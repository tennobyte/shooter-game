using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShip : MonoBehaviour, IDestroyable, ISwitchable  {

    public float health;
    public float maxHealth;
    public float speed;
    public Weapon weapon;
    public int points;
    public Transform ship;
    public Rigidbody2D rb;
    public float tiltValue;

    public Transform beacon;

    public bool shootingEnabled;

    // Use this for initialization
    void Start () {
        rb = GetComponent<Rigidbody2D>();
        shootingEnabled = false;
    }

    public void SwitchOn()
    {
        shootingEnabled = true;
    }

    void OnEnable()
    {
        health = maxHealth;
        shootingEnabled = false;
    }

    // Update is called once per frame
    void Update () {
        if (shootingEnabled)
        {
            weapon.Shoot();
        }
        
        if (beacon != null)
        {
            //rb.AddForce((beacon.position - transform.position) * speed);
            rb.velocity = (beacon.position - transform.position) * speed;
        }
        //rb.AddForce((Vector2)new Vector3(-transform.position.x, -transform.position.y) + Random.insideUnitCircle);

        rb.AddForce(Random.insideUnitCircle);
        float movement = rb.velocity.x;
        ship.localRotation = Quaternion.Euler(0, 180 + tiltValue * -movement, 90);
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
        GameObject hitPS = PoolManager.instance.GetObject(GameManager.instance.hitExplosions);
        hitPS.transform.position = transform.position;
        hitPS.transform.rotation = transform.rotation;
        hitPS.SetActive(true);
        ParticleSystem ps = hitPS.GetComponent<ParticleSystem>();
        ps.Emit(10);
        GameManager.instance.addPoints(points);
        AudioManager.instance.PlayExplosionSound();
        gameObject.SetActive(false);
    }
}
