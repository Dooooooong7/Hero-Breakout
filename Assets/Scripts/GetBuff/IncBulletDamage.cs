using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
public class IncBulletDamage : MonoBehaviour
{
    public float increaseBulletDamage = 1f;
    public UnityEvent<float> onIncreaseBulletDamage; 
    
    // Start is called before the first frame update
    void Start()
    {
        onIncreaseBulletDamage.AddListener(GameObject.Find("Player").GetComponent<FireOfPlayer>().IncDamage);
        // onIncreaseBulletSpeed.AddListener(F);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.name == "Player")
        {
            onIncreaseBulletDamage?.Invoke(increaseBulletDamage);
        }
    }

}
