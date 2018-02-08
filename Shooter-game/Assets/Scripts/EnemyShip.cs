using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShip : MonoBehaviour, IDestroyable  {

    public float health;
    public float max_health;
    public Weapon weapon;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        weapon.Shoot();
    }

    public void ReceiveDamage(float value)
    {
        health -= value;
        if (health <= 0)
        {
            Destroy();
        }
    }

    public void Destroy()
    {
        gameObject.SetActive(false);
    }
}
