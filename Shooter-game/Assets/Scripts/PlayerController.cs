using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class PlayerController : MonoBehaviour, IDestroyable {

    public float maxHealth;
    public float currentHealth;

    public Weapon weapon;
    public Transform ship;
    public Rigidbody2D rb;
    public Slider healthBar;

    public float moveSpeed;
    public float tiltValue;

    private float xBoundary;

	// Use this for initialization
	void Start () {
        rb = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetButton("Fire1"))
        {
            weapon.Shoot();
        }
        //float movement = moveSpeed * Input.GetAxis("Mouse X") * Time.deltaTime*10;
        //transform.Translate(movement, 0, 0);

    }

    private void FixedUpdate()
    {
        float movement = Input.GetAxis("Horizontal") * moveSpeed * Time.deltaTime;
        rb.velocity = new Vector3(movement, 0, 0);
        rb.position = new Vector3(Mathf.Clamp(rb.position.x, -xBoundary, xBoundary), -2.7f, 0);
        ship.rotation = Quaternion.Euler(0, tiltValue * -movement, 0);
    }

    public void SetBoundary(float value)
    {
        xBoundary = value - 0.5f;
    }

    public void ReceiveDamage(float value)
    {
        currentHealth -= value;
        healthBar.value = Mathf.Clamp(currentHealth / maxHealth,0,1);
        if (currentHealth <= 0)
        {
            Destroy();
        }
    }

    public void Destroy()
    {
        Debug.Log("Player Destroyed");
    }


}
