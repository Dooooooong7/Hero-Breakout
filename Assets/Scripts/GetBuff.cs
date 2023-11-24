using UnityEngine;
using UnityEngine.Events;

public class GetBuff : MonoBehaviour
{
    public float increaseBulletSpeed = 0.1f;
    public UnityEvent<float> onGetBuff; 
    
    // Start is called before the first frame update
    void Start()
    {
        onGetBuff.AddListener(GameObject.Find("Player").GetComponent<FireOfPlayer>().IncreaseFire);
        onGetBuff.AddListener(F);
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log(other.name + "碰到了" + this.name);
        if (other.name == "Player")
        {
            onGetBuff?.Invoke(increaseBulletSpeed);
        }
    }

    private void F(float a)
    {
        Debug.Log("调用");
    }
}
