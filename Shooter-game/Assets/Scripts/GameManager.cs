using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

    private float maxWidth;

    public PlayerController player;

    public GameObject bullet;
    public GameObject enemyBullet;
    public GameObject enemy_1;
    public GameObject enemy_2;
    public GameObject hitExplosions;

    // Use this for initialization
    void Start () {
        //Устанавливаем границу перемещения игрока и спавна врагов/плюшек
        Camera mainCamera = Camera.main;
        Vector3 upperCorner = new Vector3(Screen.width, Screen.height, 0);
        maxWidth = mainCamera.ScreenToWorldPoint(upperCorner).x;
        player.SetBoundary(maxWidth);

        PoolManager.instance.CreatePool(bullet, 40);
        PoolManager.instance.CreatePool(enemyBullet, 100);
        PoolManager.instance.CreatePool(enemy_1, 10);
        PoolManager.instance.CreatePool(enemy_2, 10);
        PoolManager.instance.CreatePool(hitExplosions, 10);
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
