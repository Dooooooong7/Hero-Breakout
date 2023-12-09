using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageeOfStone : MonoBehaviour
{
    public float damage;
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.name == "Player")
        {
            var pBlood = other.GetComponent<BloodOfPlayer>();
            if (pBlood.countTime >= pBlood.timeUnhurtable)
            {
                if (pBlood.currentBlood < damage)
                    pBlood.currentBlood = 0;
                else pBlood.currentBlood -= damage;
                pBlood.countTime = 0;
            }
            Debug.Log("碰到石头,当前血量为" + pBlood.currentBlood);
            Destroy(this);
        }
    }

}
