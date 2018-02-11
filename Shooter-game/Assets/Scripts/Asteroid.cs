using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Asteroid : MonoBehaviour, IDestroyable, ISwitchable {

    public Transform asteroid;
    public float speed;
    public float rotationSpeed;

    public float health;
    public float maxHealth;

    public int points;

    public Vector3 rotation;

    public GameObject[] items;

    public bool ableToDie;

	// Use this for initialization
	void Start () {
        rotation = Random.rotationUniform.eulerAngles * rotationSpeed;
        ableToDie = false;
    }
	
	// Update is called once per frame
	void Update () {
        transform.Translate(new Vector3(0,Time.deltaTime * -speed));
        asteroid.Rotate(rotation*Time.deltaTime);
	}

    void OnEnable()
    {
        ableToDie = false;
        health = maxHealth;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        PlayerController player = other.GetComponent<PlayerController>();
        if (player!= null)
        {
            player.ReceiveDamage(100);
        }
    }

    public void SwitchOn()
    {
        ableToDie = true;
    }

    public void ReceiveDamage(float value)
    {
        if (ableToDie)
        {
            health -= value;
            if (health <= 0)
            {
                ableToDie = false;
                Destroy();
            }
        }
    }

    public void Destroy()
    {
        AudioManager.instance.PlayExplosionSound();
        GameManager.instance.addPoints(points);
        DropRandomItem();
        GameObject hitPS = PoolManager.instance.GetObject(GameManager.instance.hitExplosions);
        hitPS.transform.position = transform.position;
        hitPS.transform.rotation = transform.rotation;
        hitPS.SetActive(true);
        ParticleSystem ps = hitPS.GetComponent<ParticleSystem>();
        ps.Emit(10);
        gameObject.SetActive(false);
    }

    public void DropRandomItem()
    {
        GameObject drop = PoolManager.instance.GetObject(items[Random.Range(0,items.Length)]);
        drop.transform.position = transform.position;
        drop.SetActive(true);
    }
}
