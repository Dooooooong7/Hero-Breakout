using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class CreatBuffDoor : MonoBehaviour
{
    public List<GameObject> buffDoor = new List<GameObject>();
    public List<float> buffXPosition = new List<float>();
    public float spawnTime;
    private float _countTime;
    private Vector3 _spawnPosition;
    public Transform buffFloder;

    private void Start()
    {
        _countTime = 3;
    }

    private void Update()
    {
        SpawnBuff();
    }

    public void SpawnBuff()
    {
        _countTime += Time.deltaTime;
        _spawnPosition = transform.position;
        if (_countTime >= spawnTime)
        {
            CreatBuff();
            _countTime = 0;
        }
    }

    public void CreatBuff()
    {
        _spawnPosition.y += 1.5f;
        for (int i = 0; i < 3; i++)
        {
            int indexBarrier = Random.Range(0, buffDoor.Count);
            _spawnPosition.x = buffXPosition[i];
            GameObject node = Instantiate(buffDoor[indexBarrier], buffFloder);
            node.transform.position = _spawnPosition;
        }
    }
}