using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;
using Random = UnityEngine.Random;

public class FireOfBoss : MonoBehaviour
{
    [Header("stone")]
    public GameObject stonePrefab;
    public Transform stoneFloder;
    //public Transform firePoint;
    [Header("射击间隔")]
    public float initialFireInterval = 2f;
    public float fireTimer = 0.2f;//射击间隔
    public float fireFrequency = 1f;//射击频率
    [Header("石头速度")]
    public float throwForce;
    [Header("石头x坐标")]
    public List<float> barrierXPosition = new List<float>();

    public float fireYPosition;
    [Header("石头y坐标")]
    public List<float> barrierYPosition = new List<float>();
    [Header("开火状态")]
    public int isXFiring;//竖直弹幕
    public int isYFiring;//水平弹幕
    public float startFire;//冷却时间计时器
    public float stopTime = 6f;//冷却时间
    public bool isFiring;//是否在攻击

    public LogicOfBoss logicOfBoss;
    public MoveOfBoss moveOfBoss;

    private void Start()
    {
        isXFiring = 0;
        isYFiring = 0;
        logicOfBoss = GetComponent<LogicOfBoss>();
        moveOfBoss = GetComponent<MoveOfBoss>();
        startFire = stopTime;
        isFiring = false;
    }

    void Update()
    {
        startFire += Time.deltaTime;
        fireTimer -= Time.deltaTime;
        if (!isFiring && !moveOfBoss.isMoving)
        {
            if (startFire >= stopTime)
            {
             logicOfBoss.canBeHurt = false;
             isFiring = true;
             isXFiring = 1;
            }
        }
        
        else
        {
          if (fireTimer <= 0) {
             StoneFire();
             fireTimer = initialFireInterval;
             fireFrequency = 1 / fireTimer;
          }  
        }
        
    }
    
    private void StoneFire()
    {
        if (isXFiring > 0 && isXFiring < 5)
        {
            for (int j = 0; j < 2; j++)
            { 
                int indexPosition = Random.Range(0, barrierXPosition.Count);
                for (int i = 0; i < 3; i++)
                {
                 var node = Instantiate(stonePrefab, stoneFloder);
                 node.transform.position = new Vector3(transform.position.x + barrierXPosition[indexPosition], transform.position.y + i * fireYPosition, transform.position.z);
                 var rb = node.GetComponent<Rigidbody>();
                 rb.AddForce(transform.forward * throwForce, ForceMode.Impulse);
                }
            }
            isXFiring++;
            if (isXFiring == 5)
            {
                isYFiring = 1;
                return;
            }
        }

        if (isYFiring > 0 && isYFiring < 5)
        {
            int indexPosition = Random.Range(0, barrierYPosition.Count);
            for (int i = 0; i < 3; i++)
            {
                var node = Instantiate(stonePrefab, stoneFloder);
                node.transform.position = new Vector3(transform.position.x + barrierXPosition[i], transform.position.y + barrierYPosition[indexPosition], transform.position.z);
                var rb = node.GetComponent<Rigidbody>();
                rb.AddForce(transform.forward * throwForce, ForceMode.Impulse);
            }
            isYFiring++;
            if (isYFiring == 5)
            {
                logicOfBoss.canBeHurt = true;
                startFire = 0f;
                isFiring = false;
            }
        }
    }
}
