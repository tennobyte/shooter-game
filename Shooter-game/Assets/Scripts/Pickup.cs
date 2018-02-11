using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Pickup : MonoBehaviour {

    public float moveSpeed;
    public float rotationSpeed;

    public Transform mesh;

	
	// Update is called once per frame
	void Update () {
        Move();
    }

    public virtual void Move()
    {
        transform.Translate(new Vector3(0,Time.deltaTime * -moveSpeed, 0));
        mesh.Rotate(new Vector3(0, 0,Time.deltaTime * rotationSpeed));
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        PlayerController player = collision.GetComponent<PlayerController>();
        if(player != null)
        {
            TakeEffect(player);
        }
    }

    public virtual void TakeEffect(PlayerController player)
    {
        Debug.Log("Picked!");
        gameObject.SetActive(false);
    }
}
