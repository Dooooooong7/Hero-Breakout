using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class BloodOfPlayer : MonoBehaviour
{
   public float maxBlood = 100f;
   public float currentBlood;
   public float timeUnhurtable = 1f;
   public float countTime;
   // public UnityEvent<BloodOfPlayer> OnHealthChange;
   public CharacterEventSO BloodChangeEventSO;
   
   public float nowTime;
   
   private void Start()
   {
      currentBlood = maxBlood;
      BloodChangeEventSO.RaiseEvent(this);
      // OnHealthChange?.Invoke(this);
   }
   
   private void Update()
   {
      nowTime = Time.time;
      TakeDamage();
      // countTime += Time.deltaTime;
      // if (currentBlood <= 0) Time.timeScale = 0;
      // Debug.Log("游戏失败！");
   }

   public void TakeDamage()
   {
      countTime += Time.deltaTime;
      if (currentBlood <= 0)
      {
         Time.timeScale = 0;
         Debug.Log("游戏失败！");
      }

      BloodChangeEventSO.RaiseEvent(this);
      // OnHealthChange?.Invoke(this);
   }

   public void IncBlood(float increaseBlood)
   {
      if (currentBlood + increaseBlood < maxBlood) currentBlood += increaseBlood;
      else currentBlood = maxBlood;
   }
}
