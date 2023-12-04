using UnityEngine;
using UnityEngine.Events;

public class IncMoveSpeed : MonoBehaviour
{
    public float increaseBulletSpeed = 0.1f;
    public UnityEvent<float> onIncreaseBulletSpeed; 
    
    // Start is called before the first frame update
    void Start()
    {
        onIncreaseBulletSpeed.AddListener(GameObject.Find("Player").GetComponent<FireOfPlayer>().IncMoveSpeed);
        // onIncreaseBulletSpeed.AddListener(F);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.name == "Player")
        {
            onIncreaseBulletSpeed?.Invoke(increaseBulletSpeed);
        }
    }

}
