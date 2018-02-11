using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class PlayerController : MonoBehaviour, IDestroyable {

    public float maxHealth;
    public float health;

    public Weapon currentWeapon;
    public Transform ship;
    public Rigidbody2D rb;
    public Slider healthBar;

    public float moveSpeed;
    public float tiltValue;

    private float xBoundary;

    public Weapon[] weapons;
    public int weaponNum;

	// Use this for initialization
	void Start () {
        rb = GetComponent<Rigidbody2D>();
        weaponNum = 0;
        currentWeapon = weapons[weaponNum];
    }
	
	// Update is called once per frame
	void Update () {
        if (Input.GetButton("Fire1"))
        {
            if(currentWeapon != null && !PauseMenu.isPaused)
            {
                currentWeapon.Shoot();
            }     
        }
        //float movement = moveSpeed * Input.GetAxis("Mouse X") * Time.deltaTime*10;
        //transform.Translate(movement, 0, 0);

    }

    private void FixedUpdate()
    {
        float movement = Input.GetAxis("Horizontal") * moveSpeed * Time.deltaTime;
        rb.velocity = new Vector3(movement, 0, 0);
        rb.position = new Vector3(Mathf.Clamp(rb.position.x, -xBoundary, xBoundary), -2.7f, 0);
        ship.rotation = Quaternion.Euler(-90, tiltValue * -movement, 0);
    }

    public void SetBoundary(float value)
    {
        xBoundary = value - 0.5f;
    }

    public void ReceiveDamage(float value)
    {
        health -= value;
        healthBar.value = Mathf.Clamp(health / maxHealth,0,1);
        if (health <= 0)
        {
            Destroy();
        }
    }

    public void GetHealth(float value)
    {
        health = Mathf.Clamp(health + value, 0, maxHealth);
        healthBar.value = Mathf.Clamp(health / maxHealth, 0, 1);
    }

    public void UpgradeWeapon()
    {
        weaponNum = Mathf.Clamp(weaponNum + 1,0,weapons.Length-1);
        currentWeapon.gameObject.SetActive(false);
        currentWeapon = weapons[weaponNum];
        currentWeapon.gameObject.SetActive(true);
    }

    public void Destroy()
    {
        AudioManager.instance.PlayExplosionSound();
        GameObject hitPS = PoolManager.instance.GetObject(GameManager.instance.hitExplosions);
        hitPS.transform.position = transform.position;
        hitPS.transform.rotation = transform.rotation;
        hitPS.SetActive(true);
        ParticleSystem ps = hitPS.GetComponent<ParticleSystem>();
        ps.Emit(10);
        Debug.Log("Player Destroyed");
        gameObject.SetActive(false);
        GameManager.instance.GameOver();
    }


}
