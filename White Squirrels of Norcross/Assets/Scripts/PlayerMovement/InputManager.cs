using UnityEngine;
using System;
using UnityEngine.InputSystem;
public class InputManager : MonoBehaviour
{
    //Variable creates perm instance of InputManager
    public static InputManager Instance { get; private set; }

    //C# Events for invoking any method which subscribes to them
    public static event Action<Vector2> OnInputMove; //Event for when movement detected
    private Vector2 moveInput; //Dedicated Vector2 which constantly gets updated for movement
    private bool isMoving; // Dedicated Bool, used to know when player is moving or not

    public static event Action OnInputJump;
    public static event Action OnInputAction;



    public void ToMove(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            moveInput = context.ReadValue<Vector2>();
            isMoving = true;
        }
        if (context.canceled)
        {
            isMoving = false;
        }
    }
    public void ToJump(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            OnInputJump?.Invoke();
        }
    }
    public void ToAction(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            OnInputAction?.Invoke();
        }
    }
    void Awake()
    {
        //Perm Instance of InputManager is created if no other Input manager exists
        if(Instance != null & Instance != this)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
        DontDestroyOnLoad(gameObject);
    }

    void Update()
    {
        if (isMoving)
        {
            ToggleMove();
        }
    }

    private void ToggleMove()
    {
        OnInputMove?.Invoke(moveInput);
    }


}
