using UnityEngine;
using UnityEngine.Events;

public class GetBuff : MonoBehaviour
{
    public float increaseBulletSpeed = 0.1f;
    public UnityEvent<float> onIncreaseBulletSpeed; 
    
    // Start is called before the first frame update
    void Start()
    {
        onIncreaseBulletSpeed.AddListener(GameObject.Find("Player").GetComponent<FireOfPlayer>().IncreaseFire);
       // onIncreaseBulletSpeed.AddListener(F);
    }

    private void OnTriggerEnter(Collider other)
    {
        //Debug.Log(other.name + "碰到了" + this.name);
        if (other.name == "Player")
        {
            onIncreaseBulletSpeed?.Invoke(increaseBulletSpeed);
        }
    }

    // private void F(float a)
    // {
    //     Debug.Log("调用");
    // }
}
