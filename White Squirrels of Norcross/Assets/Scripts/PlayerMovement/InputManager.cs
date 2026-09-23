using UnityEngine;
using System;
using UnityEngine.InputSystem;
public class InputManager : MonoBehaviour
{
    //Variable creates perm instance of InputManager
    public static InputManager Instance { get; private set; }

    //C# Events for invoking any method which subscribes to them
    public static event Action<Vector2> OnInputMove; //Event for when movement detected
    public static event Action OnInputJump;
    public static event Action OnInputAction;



    public void ToMove(InputAction.CallbackContext context)
    {
        Vector2 moveInput = context.ReadValue<Vector2>();
        OnInputMove?.Invoke(moveInput);
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
        
    }
}
