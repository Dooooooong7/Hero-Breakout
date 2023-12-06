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

    [Header("Buff")]
    public BuffDataSO buffData;
    // public float addDistance = 0f;
    // public float addDamage = 0f;
    // public float addSpeed = 0f;
    // public float addFrequency = 0f;

    public MoveOfBullet moveOfBullet;
    

     void Update()
    {
        
        fireTimer -= Time.deltaTime;
        if (fireTimer <= 0) {
            BulletFire();
            fireTimer = initialFireInterval /(1 + buffData.addFrequency) ;
            fireFrequency = 1 / fireTimer;
        }
    }

   
    private void BulletFire()
    {
        
        GameObject node = Instantiate(bulletPrefab, bulletFloder);
        node.transform.position = firePoint.position;

 
        moveOfBullet = node.GetComponent<MoveOfBullet>();
        moveOfBullet.nowSpeed += buffData.addSpeed;
        moveOfBullet.nowDamage += buffData.addDamage;
        moveOfBullet.nowFlyDistance += buffData.addDistance;
        
    }

    public void IncreaseFire(float addedSpeed)
    {
        buffData.addFrequency += addedSpeed;
    }
    
    public void IncMoveSpeed(float add)
    {
        buffData.addSpeed += add;
    }
    
    public void IncMoveDistance(float add)
    {
        buffData.addDistance += add;
    }

    public void IncDamage(float add)
    {
        buffData.addDamage += add;
    }
    
}
