using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreatEnermy : MonoBehaviour
{
    public List<GameObject> enemy = new List<GameObject>();
    public List<float> enemyXPosition = new List<float>();
    public float spawnTime;
    private float _countTime;
    private Vector3 _spawnPosition;
    public Transform enemyFloder;
    public CreatBarrier mainSpawnTime;

    private void Start()
    {
        mainSpawnTime = GetComponent<CreatBarrier>();
        _countTime = spawnTime/2;
    }

    private void Update()
    {
        spawnTime = 4 * mainSpawnTime.spawnTime;
        SpawnEnemy();
    }

    public void SpawnEnemy()
    {
        _countTime += Time.deltaTime;
        _spawnPosition = transform.position;
        if (_countTime >= spawnTime)
        {
            CreatEnemy();
            _countTime = 0;
        }
    }

    public void CreatEnemy()
    {
        int indexEnemy = Random.Range(0, enemy.Count);
        int indexPosition = Random.Range(0, enemyXPosition.Count);
        _spawnPosition.x = enemyXPosition[indexPosition];
        GameObject node = Instantiate(enemy[indexEnemy], enemyFloder);
        node.transform.position = _spawnPosition;
    }
}
