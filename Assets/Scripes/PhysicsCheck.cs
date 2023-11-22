using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhysicsCheck : MonoBehaviour
{
    [Header("检测参数")]
    public float checkRaduis;
    public LayerMask groundLayer;
    public Vector3 bottomOffset;
    [Header("检测参数")]
    public bool onGround;
    

    private void Awake()
    {
        
    }

    private void Update()
    {
        check();
    }

    public void check()
    {
        var isGround  = Physics.OverlapSphere(transform.position + bottomOffset, checkRaduis, groundLayer);
        if (isGround.Length > 0)
        {
            onGround = true;
        }
        else onGround = false;
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(transform.position + bottomOffset, checkRaduis);
    }
    
}
