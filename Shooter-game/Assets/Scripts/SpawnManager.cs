using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour {

    public int waveNumber = 0;
    public int difficultyModifier;
    public int bossWaveNubmer;
    public Transform spawnPosition;

    public float spawnRate;
    public float spawnCooldown;
    public int spawnResource;

    public float spawnBoundary;

    public Formation[] formations;
    public Formation bossFormation;

    public GameObject[] enemyShips;
    public GameObject bossShip;

    public GameObject[] asteroids;
    public float asteroidSpawnRate;
    public float asteroidSpawnCooldown;

    // Use this for initialization
    void Start () {
        spawnCooldown = 3;
        spawnBoundary = GameManager.instance.getMaxWidth()/1.5f;
    }
	
	// Update is called once per frame
	void Update () {
        if (spawnCooldown > 0)
        {
            spawnCooldown -= Time.deltaTime;
        }

        if (spawnCooldown <= 0)
        {
            waveNumber++;
            if (waveNumber % bossWaveNubmer == 0)
            {
                SpawnBossWave();
            }
            else
            {
                SpawnWave();
            }
            spawnResource += difficultyModifier;
        }

        if (asteroidSpawnCooldown > 0)
        {
            asteroidSpawnCooldown -= Time.deltaTime;
        }
        else
        {
            SpawnAsteroid();
        }
    }

    public void SpawnAsteroid()
    {
        asteroidSpawnCooldown = asteroidSpawnRate;
        GameObject asteroid = PoolManager.instance.GetObject(asteroids[Random.Range(0, asteroids.Length)]);
        asteroid.transform.position = new Vector3(spawnPosition.position.x + Random.Range(-spawnBoundary, spawnBoundary), spawnPosition.position.y, Random.Range(0, 10));
        asteroid.transform.rotation = Quaternion.identity;
        asteroid.SetActive(true);
    }

    public void SpawnWave()
    {
        spawnCooldown = spawnRate;
        int currentResources = spawnResource;
        int i = 0;
        int j = 0;
        while (formations.Length - j > 0)
        {
            i = Random.Range(0, formations.Length - j );
            if (i+1 > currentResources)
            {
                j++;
            }
            else
            {
                currentResources -= i+1;
                SpawnFormation(formations[i]);
            }
        }
    }

    public void SpawnBossWave()
    {
        spawnCooldown = spawnRate*2;

        Formation formation = Instantiate(bossFormation, new Vector3(spawnPosition.position.x , spawnPosition.position.y, Random.Range(0, 10)), Quaternion.identity);
        Destroy(formation.gameObject, 30);
        GameObject boss = PoolManager.instance.GetObject(bossShip);
        boss.transform.rotation = Quaternion.identity;
        boss.transform.position = spawnPosition.position;
        BossShip bossComp = boss.GetComponent<BossShip>();
        if (bossComp != null)
        {
            bossComp.beacon = formation.positions[0];
        }
        boss.SetActive(true);
    }

    public void SpawnFormation(Formation form)
    {
        Formation formation = Instantiate(form, new Vector3(spawnPosition.position.x + Random.Range(-spawnBoundary, spawnBoundary), spawnPosition.position.y, Random.Range(0, 10)), Quaternion.identity);
        //заполняем формацию кораблями
        Destroy(formation.gameObject,30);
        foreach (Transform position in formation.positions)
        {
            //EnemyShip enemy = Instantiate(enemyShips[Random.Range(0, enemyShips.Length)],position.position, Quaternion.identity);
            GameObject enemy = PoolManager.instance.GetObject(enemyShips[Random.Range(0, enemyShips.Length)]);
            enemy.transform.rotation = Quaternion.identity;
            enemy.transform.position = position.position;
            EnemyShip enemyShip = enemy.GetComponent<EnemyShip>();
            if (enemyShip != null)
            {
                enemyShip.beacon = position;
            }
            enemy.SetActive(true);
        }
    }
}
