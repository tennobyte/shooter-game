using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Formation : MonoBehaviour {

    public Transform[] positions;
    public float moveSpeed;

    public virtual void Move()
    {
        transform.Translate(0, Time.deltaTime * -moveSpeed, 0);
    }

    private void Update()
    {
        Move();
    }
}
