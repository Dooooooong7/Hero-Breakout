using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class MoveOfBullet : MonoBehaviour
{
    public float nowSpeed = 1f;
    public float nowFlyDistance = 10f;
    public float initZ;
    public float nowDamage = 10f;
    
    
    void Start()
    {
        initZ = transform.position.z;
    }
    
    void Update()
    {
        
        transform.Translate(0,0,nowSpeed * Time.deltaTime,Space.World);
        if(transform.position.z - initZ >= nowFlyDistance) SelfDestroy();
    }

    private void OnTriggerEnter(Collider other)
    {
        //Debug.Log("子弹击中" + other.name);
    }

    public void SelfDestroy()
    {
        Destroy(this.gameObject);
    }
    
}
