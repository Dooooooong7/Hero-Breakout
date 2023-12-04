using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireOfPlayer : MonoBehaviour
{
    public GameObject bulletPrefab;
    public Transform bulletFloder;
    public Transform firePoint;
    public float initialFireInterval = 0.2f;
    public float fireTimer = 0.2f;
    public float fireFrequency = 1f;

    public float addDistance = 0f;
    public float addDamage = 0f;
    public float addSpeed = 0f;
    public float addFrequency = 0f;

    public MoveOfBullet moveOfBullet;
    

     void Update()
    {
        
        fireTimer -= Time.deltaTime;
        if (fireTimer <= 0) {
            BulletFire();
            fireTimer = initialFireInterval /(1 + addFrequency) ;
            fireFrequency = 1 / fireTimer;
        }
    }

   
    private void BulletFire()
    {
        
        GameObject node = Instantiate(bulletPrefab, bulletFloder);
        node.transform.position = firePoint.position;

 
        moveOfBullet = node.GetComponent<MoveOfBullet>();
        moveOfBullet.nowSpeed += addSpeed;
        moveOfBullet.nowDamage += addDamage;
        moveOfBullet.nowFlyDistance += addDistance;
        
    }

    public void IncreaseFire(float addedSpeed)
    {
        addFrequency += addedSpeed;
    }
    
    public void IncMoveSpeed(float add)
    {
        addSpeed += add;
    }
    
    public void IncMoveDistance(float add)
    {
        addDistance += add;
    }

    public void IncDamage(float add)
    {
        addDamage += add;
    }
    
}
