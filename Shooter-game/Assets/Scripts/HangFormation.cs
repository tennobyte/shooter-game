using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HangFormation : Formation {

    public Vector2 beacon;
    public float radius;

	// Use this for initialization
	void Start () {
        beacon = Random.insideUnitCircle*radius;
	}
	
	// Update is called once per frame
	void Update () {
        transform.Translate((beacon.x - transform.position.x) * Time.deltaTime*moveSpeed,
            (beacon.y - transform.position.y)*Time.deltaTime * moveSpeed, 
            0);
	}
}
