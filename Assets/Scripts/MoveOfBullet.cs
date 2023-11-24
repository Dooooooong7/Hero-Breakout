using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveOfBullet : MonoBehaviour
{
    public float speed = 1f;
    public float flytime = 2f;
    
    
    
    // Start is called before the first frame update
    void Start()
    {
        Invoke("selfDestroy",flytime);
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(0,0,speed * Time.deltaTime,Space.World);
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("子弹击中" + other.name);
    }

    private void selfDestroy()
    {
        Destroy(this.gameObject);
    }
    
    
}
