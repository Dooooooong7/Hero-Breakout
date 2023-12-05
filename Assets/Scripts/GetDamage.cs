using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetDamage : MonoBehaviour
{
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.name == "Player")
        {
            var pBlood = other.GetComponent<BloodOfPlayer>();
            if (pBlood.countTime >= pBlood.timeUnhurtable)
            {
                if (pBlood.currentBlood < GetComponent<DamageOfBarriers>().damage)
                    pBlood.currentBlood = 0;
                else 
                    pBlood.currentBlood -= GetComponent<DamageOfBarriers>().damage;
                pBlood.countTime = 0;
            }
            Debug.Log("碰到障碍,当前血量为" + pBlood.currentBlood);
            GetComponent<MoveOfBarrier>().SelfDestroy();
        }
    }
}
