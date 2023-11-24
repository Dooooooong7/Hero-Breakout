using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireOfPlayer : MonoBehaviour
{
    public GameObject bulletPrefab;
    public Transform bulletFloder;
    public Transform firePoint;
    public float fireInterval;
    private float _increasedFireSpeed = 1f;
    public float initialFireInterval = 0.1f;
    
    // Start is called before the first frame update
    void Start()
    {
        fireInterval = initialFireInterval;
        InvokeRepeating("BulletFire", fireInterval, fireInterval);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void BulletFire()
    {
        GameObject node = Instantiate(bulletPrefab, bulletFloder);
        node.transform.position = firePoint.position;
    }

    public void IncreaseFire(float addedSpeed)
    {
        _increasedFireSpeed += addedSpeed;
        fireInterval = initialFireInterval / 1 + _increasedFireSpeed;
    }
}
