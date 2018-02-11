using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SinFormation : Formation {

    public float frequency;
    public float magnitude;

    private float startPositionX;

    private void Start()
    {
        startPositionX = transform.position.x;
    }

    public override void Move()
    {
        //transform.Translate(Mathf.Sin(Time.time*frequency) * magnitude, Time.deltaTime * -moveSpeed, 0);
        //Debug.Log("Time: " + Time.time + "   Sin: " + Mathf.Sin(Time.time));
        transform.position = new Vector3(startPositionX + Mathf.Sin(Time.time * frequency) * magnitude, transform.position.y + Time.deltaTime * -moveSpeed);
    }
}
