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
    
    public float maxblood = 10f;
    
    [Header("状态")]
    public bool isHurt = false;
    
    public bool isDead = false;

   
    
    private void Start()
    {
        capsuleTransform = transform.Find("Blood");
        currentBlood = maxblood;
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
                 pBlood.blood -= currentBlood;
                 pBlood.countTime = 0;
            }
            Debug.Log("碰到敌人,当前血量为" + pBlood.blood);
            GetComponent<MoveOfEnermy>().SelfDestroy(1);
        }
        
        if (other.name == "BulletOfGun(Clone)") 
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
