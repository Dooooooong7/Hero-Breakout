using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireOfEnemy : MonoBehaviour
{
    public GameObject stonePrefab;
    public Transform stoneFloder;
    //public Transform firePoint;
    public float initialFireInterval = 0.2f;
    public float fireTimer = 0.2f;//射击间隔
    public float fireFrequency = 1f;//射击频率
    public float throwForce;

    
    void Update()
    {
        
        fireTimer -= Time.deltaTime;
        if (fireTimer <= 0) {
            StonetFire();
            fireTimer = initialFireInterval;
            fireFrequency = 1 / fireTimer;
        }
    }

   
    private void StonetFire()
    {
        GameObject node = Instantiate(stonePrefab, stoneFloder);
        node.transform.position = new Vector3(transform.position.x - 0.5f, transform.position.y + 1.5f, transform.position.z);
        var rb = node.GetComponent<Rigidbody>();
        rb.AddForce(transform.forward * throwForce, ForceMode.Impulse);
    }

}
