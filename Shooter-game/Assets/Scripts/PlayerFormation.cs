using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFormation : Formation {

    public Transform player;
    public float horizontalSpeed;

	// Use this for initialization
	void Start () {
        //player = GameObject.FindGameObjectWithTag("Player").transform;
        player = GameManager.instance.player.transform;
    }

    // Update is called once per frame
    public override void Move() { 
		if (player != null)
        {
            transform.Translate((player.position.x - transform.position.x)* Time.deltaTime * horizontalSpeed, Time.deltaTime * -moveSpeed, 0);
        }
	}
}
