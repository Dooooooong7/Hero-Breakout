using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
public class IncBulletDistance : MonoBehaviour
{
    public float increaseBulletDistance = 0.5f;
    public UnityEvent<float> onIncreaseBulletDistance; 
    
    // Start is called before the first frame update
    void Start()
    {
        onIncreaseBulletDistance.AddListener(GameObject.Find("Player").GetComponent<FireOfPlayer>().IncMoveDistance);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.name == "Player")
        {
            onIncreaseBulletDistance?.Invoke(increaseBulletDistance);
        }
    }

}
