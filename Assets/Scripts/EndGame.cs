using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EndGame : MonoBehaviour
{
   private void OnTriggerEnter(Collider other)
   {
      if (other.name == "Player")
      {
         Time.timeScale = 0;
         Debug.Log("游戏胜利！");
      }
   }
}
