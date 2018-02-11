using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootingRange : MonoBehaviour {

    private void OnTriggerEnter2D(Collider2D other)
    {
        //EnemyShip enemy = other.gameObject.GetComponent<EnemyShip>();
        //if (enemy != null)
        //{
        //    enemy.shootingEnabled = true;
        //}
        //else
        //{
        //    BossShip boss = other.gameObject.GetComponent<BossShip>();
        //    if (boss != null)
        //    {
        //        boss.shootingEnabled = true;
        //    }
        //}
        ISwitchable obj = other.gameObject.GetComponent<ISwitchable>();
        if (obj != null)
        {
            obj.SwitchOn();
        }

        //other.gameObject.GetComponent<EnemyShip>().shootingEnabled = true;
        //Debug.Log("коллизия!");
    }
}
