using UnityEngine;
using UnityEngine.InputSystem;

public class Character : MonoBehaviour
{
    [SerializeField] private float movementSpeed = 1f;
    [SerializeField] private float jumpSpeed = 20f;
    private Rigidbody characterRb;
    private CharacterInputSystem inputActions;
    private Vector2 vector2;
    private bool isWalking;
    private bool isAttaking;
    private float playerSize = .7f;
    private void Start()
    {
        characterRb = GetComponent<Rigidbody>();
        inputActions = new CharacterInputSystem();
        inputActions.Character.Enable();
    }
    private void FixedUpdate()
    {
       


        
    }
    private void Update()
    {
        Vector3 moveDirection = new Vector3(vector2.x , 0 , vector2 .y); 
        
        bool canMove = !Physics.Raycast(transform.position, moveDirection, playerSize);

        if (canMove)
        {
            isWalking = characterRb.velocity != Vector3.zero;
            characterRb.velocity = moveDirection * movementSpeed;
        }
        else
        {
            characterRb.velocity = Vector3.zero;
        }
        
        

        if (vector2 != Vector2.zero)
        {
            Vector3 targetDirection = new Vector3(vector2.x, 0, vector2.y);
            transform.forward = Vector3.Slerp(transform.forward, targetDirection, Time.deltaTime * movementSpeed);
        }

        OnAttack();
    }
       private void OnAttack()
    {
        if (Input.GetMouseButtonDown(0))
        {
            isAttaking = true;
        }
        else 
            isAttaking= false;
    }
       public void Movement(InputAction.CallbackContext callback)
        {
            vector2 = callback.ReadValue<Vector2>();
        }
        public void Jump(InputAction.CallbackContext callback)
        {
            if (callback.performed)
            {
                characterRb.AddForce(Vector3.up * jumpSpeed, ForceMode.Impulse);
            }

        }   
        public bool IsWalking()
    {
        return isWalking;
    }    
        public bool IsAttaking()
    {
        return isAttaking;
    }
}
