using UnityEditor.ShaderGraph.Internal;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    //Adustable player speed, adjusted within unity editor
    [SerializeField] float CurrentPlayerSpeed;
    Vector2 currentMoveVector;
    //Reference to 2dRigidbody and 2dRigbidbody slidemovement reference
    Rigidbody2D rb;

    //Subscriptions to InputManagers C# events, within OnEnable and OnDisable
    private void OnEnable()
    {
        InputManager.OnInputMove += UpdateMoveVector;
    }
    private void OnDisable()
    {
        InputManager.OnInputMove -= UpdateMoveVector;
    }


    void Awake()
    {
        //Connected Component on GameObject is referenced to the variable "rb"
        rb = GetComponent<Rigidbody2D>();
    }
    private void FixedUpdate()
    {
        MovePlayer();
        SpeedHandlerPlayer();
    }

    //Method which moves player with given Vector2 variable
    private void MovePlayer()
    {
        if (Mathf.Abs(currentMoveVector.x) == 1)
        {
            rb.linearVelocity = new Vector2(currentMoveVector.x * CurrentPlayerSpeed, rb.linearVelocity.y);
        }
        else 
        {
            rb.linearVelocity = new Vector2(0f, rb.linearVelocity.y);
        }
    }
    private void UpdateMoveVector(Vector2 moveVector)
    {
        currentMoveVector = moveVector;
    }
    private void SpeedHandlerPlayer()
    {
        if (Mathf.Abs(rb.linearVelocity.x) > CurrentPlayerSpeed)
        {
            Vector2 flatVec = new Vector2(rb.linearVelocity.x, 0);
            Vector2 limitedVec = flatVec.normalized * CurrentPlayerSpeed;
            rb.linearVelocity = new Vector2(limitedVec.x, rb.linearVelocity.y);
        }
    }
}
