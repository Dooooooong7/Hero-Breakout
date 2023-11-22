using UnityEngine;
using UnityEngine.InputSystem;
using Vector3 = UnityEngine.Vector3;

public class MoveOfPlayer : MonoBehaviour
{
    
    
    public PlayerInpotControl inputControl;
    public float inputDirection;
    private Rigidbody rb;
    public PhysicsCheck physicsCheck;
    private Vector3 targetPosition;
    
    [Header("基本参数")]
    public float jumpForce;
    public float zspeed = 8;
    public float moveDistance = 3;
    public float smoothTime = 0.5f;
    
    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        physicsCheck = GetComponent<PhysicsCheck>();
        inputControl = new PlayerInpotControl();
        inputControl.Gamelay.Jump.started += Jump;
        inputControl.Gamelay.LeftMove.started += LMove;
        inputControl.Gamelay.RightMove.started += RMove;
    }

    private void RMove(InputAction.CallbackContext obj)
    {
        //transform.Translate(moveDistance,0,0);
        targetPosition = transform.position + Vector3.right * moveDistance;
        
    }


    private void LMove(InputAction.CallbackContext obj)
    {
        //transform.Translate(-moveDistance,0,0);
        targetPosition = transform.position + Vector3.left * moveDistance;
    }


    private void OnEnable()
    {
        inputControl.Enable();
    }

    private void OnDisable()
    {
        inputControl.Disable();
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    private void Update()
    {
        transform.Translate(0, 0, zspeed * Time.deltaTime);
        transform.position = Vector3.Lerp(transform.position, targetPosition, smoothTime * Time.deltaTime);
    }

    private void FixedUpdate()
    {
        
    }
    
    
    
    
    private void Jump(InputAction.CallbackContext obj)
    {
        // Debug.Log("1");
        if(physicsCheck.onGround) 
            rb.AddForce(transform.up * jumpForce, ForceMode.Impulse);
    }

    
    
}