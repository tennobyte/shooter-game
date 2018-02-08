using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour {

    public float speed;
    public float damage;
    public Rigidbody2D rb;
    public GameObject onHitPS;

    public bool hasCollided = false;

	// Use this for initialization
	void OnEnable () {
        rb = GetComponent<Rigidbody2D>();
        //rb.velocity = new Vector3(0,1 * speed, 0);
        rb.velocity = transform.up * speed;
        hasCollided = false;
        //particle = GetComponent<ParticleSystem>();
    }


    
    private void OnTriggerEnter2D(Collider2D other)
    {
        
        IDestroyable go = other.GetComponent<IDestroyable>();
        if (go != null && !hasCollided)
        {
            Debug.Log("Hit enemy:" + other.name);

            go.ReceiveDamage(damage);

            GameObject hitPS = PoolManager.instance.GetObject(onHitPS);
            hitPS.transform.position = transform.position;
            hitPS.transform.rotation = transform.rotation;
            hitPS.SetActive(true);
            ParticleSystem ps = hitPS.GetComponent<ParticleSystem>();
            ps.Emit(1);

            hasCollided = true;
        }  
    }

    public void SetSpeed(float value)
    {
        speed = value;
    }

    public void SetDamage(float value)
    {
        damage = value;
    }
    



}
