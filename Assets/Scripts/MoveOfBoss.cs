using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveOfBoss : MonoBehaviour
{
    public float speed = 1f;
    public float moveDistance = 15f;
    public float initZ;
    public MoveOfGround moveSpeed;
    public bool isMoving;
    

    
    [Header("buff")]
    public float increaseBulletDistance = 0.5f;
    public float increaseBulletFrequency = 0.1f;
    public float increaseBulletDamage = 1f;
    public float increaseBulletSpeed = 0.1f;

    void Start()
    {
        moveSpeed = GameObject.Find("GroundOne").GetComponent<MoveOfGround>();
        initZ = transform.position.z;
        isMoving = true;
    }

    
    void Update()
    {
        speed = moveSpeed.speed;
        if (isMoving)
        {
          transform.Translate(0,0,speed * Time.deltaTime,Space.World);
          if (initZ - transform.position.z >= moveDistance)
          {
              isMoving = false;
          }  
        }
    }
    
    public void SelfDestroy(int isKilled)
    {
        if (isKilled == 1)
        {
            int i = Random.Range(0, 3);
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
        Destroy(this.gameObject);
        GameObject.Find("CreatObject").GetComponent<CreatBarrier>().isFinalBoss = false;
        GameObject.Find("CreatObject").GetComponent<CreatBarrier>().creatCount = 3;
    }
}
