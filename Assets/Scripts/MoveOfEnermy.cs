using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveOfEnermy : MonoBehaviour
{
    public float speed = 1f;
    public float moveDistance = 15f;
    public float initZ;
    
    void Start()
    {
        initZ = transform.position.z;
    }

    
    void Update()
    {
        transform.Translate(0,0,speed * Time.deltaTime,Space.World);
        if( initZ - transform.position.z >= moveDistance) SelfDestroy();
    }
    
    public void SelfDestroy()
    {
        Destroy(this.gameObject);
    }
}
