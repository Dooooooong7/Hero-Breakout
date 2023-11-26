using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class LogicOfEnemy : MonoBehaviour
{
    public float blood = 10f;
    
    
    void Update()
    {
        if (blood == 0)
        {
            Destroy(this.gameObject);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        
        Debug.Log(1);
        if (other.name == "Player")
        {
            Time.timeScale = 0;
        }
        if (other.name == "BulletOfGun(Clone)") 
        {
            Debug.Log(2);
            blood -= GameObject.Find("BulletOfGun(Clone)").GetComponent<MoveOfBullet>().damage;
            GameObject.Find("BulletOfGun(Clone)").GetComponent<MoveOfBullet>().selfDestroy();
        }
    }
    
}
