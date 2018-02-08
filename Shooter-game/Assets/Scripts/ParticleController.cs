using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleController : MonoBehaviour {

    public float lifeTime;
    private float timeLived;

    private void OnEnable()
    {
        timeLived = 0;
    }

    private void Update()
    {
        timeLived += Time.deltaTime;
        if (timeLived >= lifeTime)
        {
            gameObject.SetActive(false);
        }
    }
}
