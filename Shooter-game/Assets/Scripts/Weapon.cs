using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public abstract class Weapon : MonoBehaviour, IShootable {
    public float fireRate = 0.5f;
    protected float cooldown = 0;
    public float damage = 10;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (cooldown > 0)
        {
            cooldown = cooldown - Time.deltaTime;
        }
    }

    virtual public void Shoot()
    {

    }
}
