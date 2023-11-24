using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetBuff : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log(other.name + "碰到了" + this.name);
        if (other.name == "Player") ;
    }
}
