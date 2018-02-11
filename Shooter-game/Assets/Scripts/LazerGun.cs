using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LazerGun : Weapon {

    public LineRenderer lineRenderer;
    public Animator animator;
    public Transform laserStartPosition;
    public Transform laserEndPosition;
    public Vector3 laserStartRotation;
    public Vector3 laserEndRotation;
    public float rotationSpeed;
    public bool isActive = false;
    public bool isAnimationFinished = false;


    void Start () {
        lineRenderer = GetComponent<LineRenderer>();
        lineRenderer.SetPosition(0, laserStartPosition.position);
        lineRenderer.SetPosition(1, laserEndPosition.position);
        laserStartRotation = transform.rotation.eulerAngles;
        laserEndRotation = new Vector3(laserStartRotation.x, laserStartRotation.y, -laserStartRotation.z);
        DeactivateLaser();
        animator = GetComponent<Animator>();
        cooldown = fireRate;
    }


	void Update () {

        if (isActive)
        {
            RaycastHit2D hit = Physics2D.Linecast(laserStartPosition.position, laserEndPosition.position, 1 << 8);
            if (hit)
            {
                lineRenderer.SetPosition(1, hit.point);
                hit.collider.GetComponent<IDestroyable>().ReceiveDamage(2);
            }
            else
            {

                lineRenderer.SetPosition(1, laserEndPosition.position);
            }
            lineRenderer.SetPosition(0, laserStartPosition.position);
        }
        else
        {
            lineRenderer.enabled = false;
        }

        if (cooldown > 0)
        {
            cooldown = cooldown - Time.deltaTime;
        }

        if (isAnimationFinished)
        {
            cooldown = fireRate;
            isAnimationFinished = false;
        }
    }

    public override void Shoot()
    {
        if(cooldown <= 0){
            ActivateLaser();
        }    
    }



    public void ActivateLaser()
    {
        lineRenderer.enabled = true;
        animator.Play("TurningLeft");
        //animator.
    }

    public void DeactivateLaser()
    {
        isActive = false;
        lineRenderer.enabled = false;
    }


}
