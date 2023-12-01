using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveOfGround : MonoBehaviour
{
    public float speed = -8;
    
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(0, 0, speed * Time.deltaTime, Space.World);
        if (transform.position.z <= -126) transform.position = new Vector3(transform.position.x,transform.position.y,72);
    }
}
