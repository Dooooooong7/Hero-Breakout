using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireOfPlayer : MonoBehaviour
{
    public GameObject bulletPrefab;
    public Transform bulletFloder;
    public Transform firePoint;
    public float fireInterval = 0.1f;
    
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("bulletFire", fireInterval, fireInterval);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void bulletFire()
    {
        GameObject node = Instantiate(bulletPrefab, bulletFloder);
        node.transform.position = firePoint.position;
    }
}
