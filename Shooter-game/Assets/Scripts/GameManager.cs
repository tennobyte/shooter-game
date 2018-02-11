using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour {

    static GameManager _instance;
    public static GameManager instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = FindObjectOfType<GameManager>();
            }
            return _instance;
        }
    }

    private float maxWidth;
    private float maxHeight;

    public PlayerController player;

    public GameObject bullet;
    public GameObject enemyBullet;
    public GameObject enemy_1;
    public GameObject enemy_2;
    public GameObject boss_1;
    public GameObject hitExplosions;
    public GameObject asteroid_1;
    public GameObject asteroid_2;
    public GameObject health;
    public GameObject upgrade;

    public GameObject scoreBoard;
    private int points = 0;

    public PauseMenu pauseMenu;
    public bool isGameOver;

    // Use this for initialization
    void Start () {
        isGameOver = false;
        //Устанавливаем границу перемещения игрока и спавна врагов/плюшек
        Camera mainCamera = Camera.main;
        Vector3 upperCorner = new Vector3(Screen.width, Screen.height, 0);
        maxWidth = mainCamera.ScreenToWorldPoint(upperCorner).x;
        maxHeight = mainCamera.ScreenToWorldPoint(upperCorner).y;
        player.SetBoundary(maxWidth);

        PoolManager.instance.CreatePool(bullet, 40);
        PoolManager.instance.CreatePool(enemyBullet, 100);
        PoolManager.instance.CreatePool(enemy_1, 10);
        PoolManager.instance.CreatePool(enemy_2, 10);
        PoolManager.instance.CreatePool(boss_1, 1);
        PoolManager.instance.CreatePool(hitExplosions, 10);
        PoolManager.instance.CreatePool(asteroid_1, 3);
        PoolManager.instance.CreatePool(asteroid_2, 3);
        PoolManager.instance.CreatePool(health, 3);
        PoolManager.instance.CreatePool(upgrade, 3);
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public void addPoints(int value)
    {
        points += value;
        scoreBoard.GetComponent<TextMeshProUGUI>().text = points.ToString();
    }

    public int getPoints()
    {
        return points;
    }

    public void GameOver()
    {
        isGameOver = true;
        pauseMenu.OpenGameOverMenu();
    }

    public float getMaxHeight()
    {
        return maxHeight;
    }

    public float getMaxWidth()
    {
        return maxWidth;
    }
}
