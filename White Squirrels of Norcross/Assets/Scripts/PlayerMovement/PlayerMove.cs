using TMPro;
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
        //Connected Component on GameObject is referenced to the variable "rb" apon start
        rb = GetComponent<Rigidbody2D>();
    }
    private void FixedUpdate()
    {
        MovePlayer();
        SpeedHandlerPlayer();
    }

    //Method which uses currentMoveVector to move the player using the CurretPlayerSpeed by adjusting the velocity.
    //AKA, this is THE method which moves the player :P
    private void MovePlayer()
    {
        /*If the currentMoveVector, after being placed into its absolute vaule, is equal to 1, 
        then the rigidbody's velocity is adjusted, using currentMoveVector at its raw form, multiplyed by the CurrentPlayerSpeed,
        while leaving alone the rigidbody's y value.
        */
        //AKA, if the player is moving AT ALL (pressing left or right), then they move.
        //We set currentMoveVector with its absoulte value, to lower code size.
        if (Mathf.Abs(currentMoveVector.x) == 1)
        {
            rb.linearVelocity = new Vector2(currentMoveVector.x * CurrentPlayerSpeed, rb.linearVelocity.y);
        }
        /*ELSE, if currentMoveVector.x returns nothing,(if it returns 0), then the rigidbody's x velocity is set to 0, while the 
        y velocity is left alone.
        */
        //AKA, if the player is pressing nothing, the player fully stop moving left and right, leaving alone gravity.
        /*We do this to give the player very slick, rigid movement. If the player stops, they fully stop
        without werid funky momentum.
        */
        else 
        {
            rb.linearVelocity = new Vector2(0f, rb.linearVelocity.y);
        }
    }

    //This method updates the scripts currentMoveVector when given a new moveVector from the subscibed C# event.
    //AKA, this method updates the currectMoveVector when the player moves or not.
    private void UpdateMoveVector(Vector2 moveVector)
    {
        currentMoveVector = moveVector;
    }

    /*This method uses the current rigidbody x velocity, compares it to the set CurrentPlayerSpeed, and if its higher than the 
    the CurrentPlayerSpeed value, it resets the rigidbody velcity back to its rigbidbody x value, times the player speed.
    */
    //AKA, this method just stops the player going faster than the set player speed. :/
    private void SpeedHandlerPlayer()
    {
        if (Mathf.Abs(rb.linearVelocity.x) > CurrentPlayerSpeed)
        {
            Vector2 BaseXVelocity = new Vector2(rb.linearVelocity.x, 0);
            Vector2 PlayerSpeedVelocity = BaseXVelocity.normalized * CurrentPlayerSpeed;
            rb.linearVelocity = new Vector2(PlayerSpeedVelocity.x, rb.linearVelocity.y);
        }
    }
}
