using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnakeFormation : Formation {

    public float frequency;
    public float magnitude;


    public override void Move()
    {
        //transform.Translate(Mathf.Sin(Time.time*frequency) * magnitude, Time.deltaTime * -moveSpeed, 0);
        //Debug.Log("Time: " + Time.time + "   Sin: " + Mathf.Sin(Time.time));
        //transform.position = new Vector3(startPositionX + Mathf.Sin(Time.time * frequency) * magnitude, transform.position.y + Time.deltaTime * -moveSpeed);

        transform.Translate(new Vector3(0, -moveSpeed*Time.deltaTime, 0));

        for (int i = 0; i < positions.Length; i++)
        {
            positions[i].localPosition = new Vector3(Mathf.Sin(Time.time * frequency + 1 * i) * magnitude, positions[i].localPosition.y);
        }
    }
}
