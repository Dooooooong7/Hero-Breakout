using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveOfBuff : MonoBehaviour
{
    public float speed = 1f;
    public float moveDistance = 15f;
    public float initZ;
    public MoveOfGround moveSpeed;
    
    void Start()
    {
        moveSpeed = GameObject.Find("GroundOne").GetComponent<MoveOfGround>();
        initZ = transform.position.z;
    }

    
    void Update()
    {
        speed = moveSpeed.speed;
        transform.Translate(0,0,speed * Time.deltaTime,Space.World);
        if( initZ - transform.position.z >= moveDistance) SelfDestroy();
    }
    
    public void SelfDestroy()
    {
        Destroy(this.gameObject);
    }
}
