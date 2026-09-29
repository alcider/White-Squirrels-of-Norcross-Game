using TMPro;
using UnityEditor.ShaderGraph.Internal;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{

    //Adustable player speed, adjusted within unity editor
    [SerializeField] float CurrentPlayerSpeed;

    //Reference to 2dRigidbody and 2dRigbidbody slidemovement reference
    Rigidbody2D rb;

    //Subscriptions to InputManagers C# events, within OnEnable and OnDisable
    private void OnEnable()
    {
        InputManager.OnInputMove += MovePlayer;
    }
    private void OnDisable()
    {
        InputManager.OnInputMove -= MovePlayer;
    }


    void Start()
    {
        //Connected Component on GameObject is referenced to the variable "rb"
        rb = GetComponent<Rigidbody2D>();
    }
    private void FixedUpdate()
    {
        SpeedHandlerPlayer();
    }

    //Method which moves player with given Vector2 variable
    private void MovePlayer(Vector2 moveVector)
    {
        Vector2 usedMoveVector = new Vector2(moveVector.x * CurrentPlayerSpeed, 0);
        rb.AddForce(usedMoveVector, ForceMode2D.Impulse);
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
