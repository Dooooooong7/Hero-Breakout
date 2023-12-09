using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;

public class LogicOfEnemy : MonoBehaviour
{
    private Transform capsuleTransform;
    [HideInInspector] public Animator anim;
    [Header("基本属性")] 
    public float currentBlood;
    
    public float maxblood = 50f;
    public float bloodGrow;
    
    [Header("状态")]
    public bool isHurt = false;
    
    public bool isDead = false;

    public float nowTime;

    public bool canBeHurt;
  
    
    
    private void Start()
    {
        nowTime = Time.time;
        maxblood = 20f + bloodGrow * nowTime / 8f;
        currentBlood = maxblood;
        capsuleTransform = transform.Find("Blood");
    }

    private void Awake()
    {
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        anim.SetBool("hurt",isHurt);
        anim.SetBool("dead",isDead);
        if (currentBlood <= 0)
        {
            // StartCoroutine(OnDead());
            GetComponent<MoveOfEnermy>().SelfDestroy(1);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.name == "Player")
        {
            var pBlood = other.GetComponent<BloodOfPlayer>();
            if (pBlood.countTime >= pBlood.timeUnhurtable)
            {
                if (pBlood.currentBlood < currentBlood)
                    pBlood.currentBlood = 0;
                else pBlood.currentBlood -= currentBlood;
                 pBlood.countTime = 0;
            }
            Debug.Log("碰到敌人,当前血量为" + pBlood.currentBlood);
            GetComponent<MoveOfEnermy>().SelfDestroy(1);
            
        }
        
        if (other.name == "BulletOfGun(Clone)" && canBeHurt) 
        {
            currentBlood -= GameObject.Find("BulletOfGun(Clone)").GetComponent<MoveOfBullet>().nowDamage;
            StartCoroutine(OnHurt());
            GameObject.Find("BulletOfGun(Clone)").GetComponent<MoveOfBullet>().SelfDestroy();
        }
        float healthPercentage = Mathf.Clamp01(currentBlood/ maxblood);
        float newWidth = healthPercentage;
        Vector3 scale = capsuleTransform.localScale;
        scale.y = capsuleTransform.localScale.y*newWidth;
        capsuleTransform.localScale = scale;
    }
    
    private IEnumerator OnHurt()
    {
        isHurt = true;
        yield return new WaitForSeconds(1.0f);
        isHurt = false;
    }
    
    
}
