using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveOfEnermy : MonoBehaviour
{
    public float speed = 1f;
    public float moveDistance = 15f;
    public float initZ;
    public MoveOfGround moveSpeed;

    
    [Header("buff")]
    public float increaseBulletDistance = 0.5f;
    public float increaseBulletFrequency = 0.1f;
    public float increaseBulletDamage = 1f;
    public float increaseBulletSpeed = 0.1f;

    void Start()
    {
        moveSpeed = GameObject.Find("GroundOne").GetComponent<MoveOfGround>();
        initZ = transform.position.z;
    }

    
    void Update()
    {
        speed = moveSpeed.speed;
        transform.Translate(0,0,speed * Time.deltaTime,Space.World);
        if( initZ - transform.position.z >= moveDistance) SelfDestroy(0);
    }
    
    public void SelfDestroy(int isKilled)
    {
        if (isKilled == 1)
        {
            Debug.Log(1);
            var i = Random.Range(0, 3);
            var buff = GameObject.Find("Player").GetComponent<FireOfPlayer>();
            switch (i)
            {
                  case 0: buff.IncDamage(increaseBulletDamage);
                      break;
                  case 1: buff.IncreaseFire(increaseBulletFrequency);
                      break;
                  case 2: buff.IncMoveDistance(increaseBulletDistance);
                      break;
                  case 3: buff.IncMoveSpeed(increaseBulletSpeed);
                      break;
            }
        }
        
        Destroy(gameObject);
    }
}
