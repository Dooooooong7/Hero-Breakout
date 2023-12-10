using UnityEngine;

public class MoveOfBullet : MonoBehaviour
{
    public float nowSpeed;
    public float nowFlyDistance;
    public float initZ;
    public float nowDamage;
    
    
    void Start()
    {
        initZ = transform.position.z;
    }
    
    void Update()
    {
        
        transform.Translate(0,0,nowSpeed * Time.deltaTime,Space.World);
        if(transform.position.z - initZ >= nowFlyDistance) SelfDestroy();
    }

    private void OnTriggerEnter(Collider other)
    {
        //Debug.Log("子弹击中" + other.name);
    }

    public void SelfDestroy()
    {
        Destroy(this.gameObject);
    }
    
}
