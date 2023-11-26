using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireOfPlayer : MonoBehaviour
{
    public GameObject bulletPrefab;
    public Transform bulletFloder;
    public Transform firePoint;
    private float _increasedFireSpeed = 0f;
    public float initialFireInterval = 0.2f;
    public float fireTimer = 0.2f;
    public float fireFrequency = 1f;
    
   

    

     void Update()
    {
        
        fireTimer -= Time.deltaTime;
        if (fireTimer <= 0) {
            BulletFire();
            fireTimer = initialFireInterval /(1 + _increasedFireSpeed) ;
            fireFrequency = 1 / fireTimer;
        }
    }

   
    private void BulletFire()
    {
        GameObject node = Instantiate(bulletPrefab, bulletFloder);
        node.transform.position = firePoint.position;
    }

    public void IncreaseFire(float addedSpeed)
    {
        _increasedFireSpeed += addedSpeed;
    }
}
