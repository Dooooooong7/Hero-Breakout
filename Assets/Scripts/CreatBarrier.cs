using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using Random = UnityEngine.Random;

public class CreatBarrier : MonoBehaviour
{
    [Header("基本数据")]
    private float _countTime;
    private Vector3 _spawnPosition;
    public int creatCount;
    [Header("时间间隔")]
    public float spawnTime;
    public float timeControl;
    public float minSpawnTime;
    [Header("障碍物")]
    public List<GameObject> barriers = new List<GameObject>(); 
    public List<float> barrierXPosition = new List<float>();
    public Transform barrierFloder;
    [Header("buff")]
    public List<GameObject> buffDoor = new List<GameObject>();
    public List<float> buffXPosition = new List<float>();
    public Transform buffFloder;
    [Header("敌人")]
    public List<GameObject> enemy = new List<GameObject>();
    public List<float> enemyXPosition = new List<float>();
    public Transform enemyFloder;
    [Header("循环")] 
    public int level;

    public bool isBoss = false;
    public bool isFinalBoss = false;
    [Header("结束")] 
    public GameObject endLine;

    public bool isEnd;
    
    
    private void Start()
    {
        _countTime = spawnTime;
        creatCount = 0;
        level = 1;
        isEnd = false;
    }

    private void Update()
    {
        if(spawnTime >= minSpawnTime) spawnTime -= timeControl * Time.deltaTime;
        SpawnObject();
    }

    public void SpawnObject()
    {
        _countTime += Time.deltaTime;
        if (level % 5 == 0)
        {
            isBoss = true;
        }

        if (level % 25 == 0)
        {
            isBoss = false;
            isFinalBoss = true;
        }
        
        if (_countTime >= spawnTime)
        {
            _spawnPosition = transform.position;
            if (creatCount == 0 && !isBoss &&!isFinalBoss)
            {
                CreatBarriers(0);
            }
            if (creatCount == 1 && !isBoss &&!isFinalBoss)
            {
                CreatBarriers(1);
            }
            if(creatCount == 2 && !isBoss &&!isFinalBoss) CreatEnemy(0);
            if (creatCount == 2 && isBoss && !isFinalBoss)
            {
                CreatEnemy(1);
                isBoss = false;
                level++;
            }
            if (creatCount == 2 && isFinalBoss)
            {
                CreatEnemy(2);
                isEnd = true;
                level++;
            }
            if (creatCount == 3 && !isBoss &&!isFinalBoss && !isEnd)
            {
                CreatBuff();
                creatCount = -1;
                level++;
            }
            if (creatCount == 3 && !isBoss && !isFinalBoss && isEnd)
            {
                CreatEndLine();
                isEnd = false;
                creatCount = -1;
                level++;
            }
            creatCount++;
            _countTime = 0;
        } 
    }

    public void CreatBarriers(int k)
    {
        if (k == 0)
        {
            for (int i = 0; i < 2; i++)
            {
                 int indexBarrier = Random.Range(0, barriers.Count);
                 int indexPosition = Random.Range(0, barrierXPosition.Count);
                 _spawnPosition.x = barrierXPosition[indexPosition];
                 GameObject node = Instantiate(barriers[indexBarrier], barrierFloder);
                 node.transform.position = _spawnPosition;
            } 
        }

        if (k == 1)
        {
            for (int i = 0; i < 2; i++)
            {
                int indexPosition = Random.Range(0, barrierXPosition.Count);
                _spawnPosition.x = barrierXPosition[indexPosition];
                GameObject node = Instantiate(barriers[0], barrierFloder);
                node.transform.position = _spawnPosition;
            } 
        }
       
       
    }
    
    public void CreatBuff()
    {
        for (int i = 0; i < 3; i++)
        {
            int indexBarrier = Random.Range(0, buffDoor.Count);
            _spawnPosition.x = buffXPosition[i];
            GameObject node = Instantiate(buffDoor[indexBarrier], buffFloder);
            node.transform.position = _spawnPosition;
        }
    }
    
    public void CreatEnemy(int k)
    {
        GameObject node;
        if (k == 2)
        {
            _spawnPosition.x = enemyXPosition[1];
            node = Instantiate(enemy[k], enemyFloder);
            node.transform.position = _spawnPosition;   
        }
        else
        {
            int indexPosition = Random.Range(0, enemyXPosition.Count);
            _spawnPosition.x = enemyXPosition[indexPosition];
            node = Instantiate(enemy[k], enemyFloder);
            node.transform.position = _spawnPosition;  
        }
        
        
    }
    public void CreatEndLine()
    {
        Debug.Log(6);
       GameObject node = Instantiate(endLine, buffFloder);
       _spawnPosition.y += 0.5f;
       node.transform.position = _spawnPosition;
       
    }
    
}
