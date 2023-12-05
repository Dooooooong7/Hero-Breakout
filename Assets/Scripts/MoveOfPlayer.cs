using System;
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
    public float moveDistance = 3;
    public float smoothTime = 8f;
    public float deltaDistance = 0.01f;
    
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
        if (Math.Abs(transform.position.x) < deltaDistance)
            targetPosition.x = moveDistance;
        if (moveDistance + transform.position.x  < deltaDistance)
            targetPosition.x = 0;

    }


    private void LMove(InputAction.CallbackContext obj)
    {
       if(Math.Abs(transform.position.x) < deltaDistance)
           targetPosition.x = -moveDistance;
       if (moveDistance - transform.position.x  < deltaDistance)
           targetPosition.x = 0;
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
        targetPosition.y = transform.position.y;
        targetPosition.z = transform.position.z;
        transform.position = Vector3.Lerp(transform.position, targetPosition, smoothTime * Time.deltaTime);
        
    }

    private void FixedUpdate()
    {
        
    }
    
    
    
    
    private void Jump(InputAction.CallbackContext obj)
    {
        if(physicsCheck.onGround) 
            rb.AddForce(transform.up * jumpForce, ForceMode.Impulse);
    }

    
    
}