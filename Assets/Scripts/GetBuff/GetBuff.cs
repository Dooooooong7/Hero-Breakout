using UnityEngine;
using UnityEngine.Events;

public class GetBuff : MonoBehaviour
{
    public float buffNum;
    public float increaseBulletDamage = 1f;
    public UnityEvent<float> onIncreaseBulletDamage; 
    public float increaseBulletDistance = 0.5f;
    public UnityEvent<float> onIncreaseBulletDistance;
    public float increaseBulletFrequency = 0.1f;
    public UnityEvent<float> onIncreaseBulletFrequency;
    public float increaseBulletSpeed = 1f;
    public UnityEvent<float> onIncreaseBulletSpeed;
    public float increaseBlood = 10f;
    public UnityEvent<float> onIncreaseBlood;
    
    void Start()
    {
        onIncreaseBulletDamage.AddListener(GameObject.Find("Player").GetComponent<FireOfPlayer>().IncDamage);
        onIncreaseBulletDistance.AddListener(GameObject.Find("Player").GetComponent<FireOfPlayer>().IncMoveDistance);
        onIncreaseBulletFrequency.AddListener(GameObject.Find("Player").GetComponent<FireOfPlayer>().IncreaseFire);
        onIncreaseBulletSpeed.AddListener(GameObject.Find("Player").GetComponent<FireOfPlayer>().IncMoveSpeed);
        onIncreaseBlood.AddListener(GameObject.Find("Player").GetComponent<BloodOfPlayer>().IncBlood);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.name == "Player")
        {
            switch (buffNum)
            {
                case 1: onIncreaseBulletDamage?.Invoke(increaseBulletDamage);
                    break;
                case 2: onIncreaseBulletDistance?.Invoke(increaseBulletDistance);
                    break;
                case 3: onIncreaseBulletFrequency?.Invoke(increaseBulletFrequency);
                    break;
                case 4: onIncreaseBulletSpeed?.Invoke(increaseBulletSpeed);
                    break;
                case 5: onIncreaseBlood?.Invoke(increaseBlood);
                    break;
                
            }
        }
    }
}
