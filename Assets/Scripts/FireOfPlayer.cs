using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireOfPlayer : MonoBehaviour
{
    public GameObject bulletPrefab;
    public Transform bulletFloder;
    public Transform firePoint;
    public float initialFireInterval = 0.2f;
    public float fireTimer = 0.2f;//射击间隔
    public float fireFrequency = 1f;//射击频率

    [Header("Buff")]
    public BuffDataSO buffData;
    public float maxDistance = 0f;
    public float maxDamage = 0f;
    public float maxSpeed = 0f;
    public float maxFrequency = 0f;

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
        if(buffData.addFrequency < maxFrequency)
            buffData.addFrequency += addedSpeed;
    }
    
    public void IncMoveSpeed(float add)
    {
        if(buffData.addSpeed < maxSpeed)
            buffData.addSpeed += add;
    }
    
    public void IncMoveDistance(float add)
    {
        if(buffData.addDistance < maxDistance)
            buffData.addDistance += add;    
    }

    public void IncDamage(float add)
    {
       if(buffData.addDamage < maxDamage)
            buffData.addDamage += add;
    }
    
}
