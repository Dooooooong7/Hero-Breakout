using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BloodOfPlayer : MonoBehaviour
{
   public float blood = 100f;
   public float timeUnhurtable = 1f;
   public float countTime;
    
   
   private void Update()
   {
      countTime += Time.deltaTime;
      if (blood <= 0) Time.timeScale = 0;
      Debug.Log("游戏失败！");
   }

   
}
