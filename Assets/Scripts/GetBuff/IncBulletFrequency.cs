using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
public class IncBulletFrequency : MonoBehaviour
{
    public float increaseBulletFrequency = 0.1f;
    public UnityEvent<float> onIncreaseBulletFrequency; 
    
    // Start is called before the first frame update
    void Start()
    {
        onIncreaseBulletFrequency.AddListener(GameObject.Find("Player").GetComponent<FireOfPlayer>().IncreaseFire);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.name == "Player")
        {
            onIncreaseBulletFrequency?.Invoke(increaseBulletFrequency);
        }
    }

}
