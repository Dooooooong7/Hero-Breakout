using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveOfBullet : MonoBehaviour
{
    public float speed = 1f;
    public float flyDistance = 15f;
    public float initZ;
    public float damage = 1;
    
    
    // Start is called before the first frame update
    void Start()
    {
        initZ = transform.position.z;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(0,0,speed * Time.deltaTime,Space.World);
        if(transform.position.z - initZ >= flyDistance) selfDestroy();
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("子弹击中" + other.name);
    }

    public void selfDestroy()
    {
        Destroy(this.gameObject);
    }
    
    
}
