using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class CreatBarrier : MonoBehaviour
{
    public List<GameObject> barriers = new List<GameObject>();
    public List<float> barrierXPosition = new List<float>();
    public float spawnTime;
    private float _countTime;
    private Vector3 _spawnPosition;
    public Transform barrierFloder;
    public int creatCount;
    
    
    private void Start()
    {
        _countTime = 3;
        creatCount = 0;
    }

    private void Update()
    {
        SpawnBarrier();
    }

    public void SpawnBarrier()
    {
        _countTime += Time.deltaTime;
        _spawnPosition = transform.position;
        if (_countTime >= spawnTime)
        {
            if (creatCount < 2)
            {
                CreatBarriers();
            }
            creatCount++;
            if(creatCount > 3) creatCount = 0;
            _countTime = 0;
        }
    }

    public void CreatBarriers()
    {
        for (int i = 0; i < 2; i++)
        {
             int indexBarrier = Random.Range(0, barriers.Count);
             int indexPosition = Random.Range(0, barrierXPosition.Count);
             _spawnPosition.x = barrierXPosition[indexPosition];
             GameObject node = Instantiate(barriers[indexBarrier], barrierFloder);
             node.transform.position = _spawnPosition;
             node.GetComponent<MoveOfBarrier>().speed = -8f;
        }
       
    }
}
