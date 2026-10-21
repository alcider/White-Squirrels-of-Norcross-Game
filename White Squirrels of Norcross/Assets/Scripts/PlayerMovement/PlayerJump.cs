using UnityEngine;
using System;
using System.Collections;
public class PlayerJump : MonoBehaviour
{

    [SerializeField] float CurrentJumpForce; // Variable on how hard the player jumps
    [SerializeField] Transform FloorLocation; // Variable on the location of the players feet (typically as child of player capsule )
    [SerializeField] LayerMask FloorLayer; // Variable of Layermask of floors in game
    [SerializeField] int CurrentExtraJumpsLeft; //Variable which holds how many jumps left
    int InitalExtraJumps; //Variable used to hold the inital jumps left
    bool IsGrounded; //Variable used to check if player is grounded
    Rigidbody2D rb; //Rigidbody variable


    //Subscriptions to InputManagers c# OnInputJump Event
    private void OnEnable()
    {
        InputManager.OnInputJump += JumpPlayer;
    }
    private void OnDisable()
    {
        InputManager.OnInputJump -= JumpPlayer;
    }


    void Awake()
    {
        //Connected Component on GameObject is referenced to the variable "rb"
        rb = GetComponent<Rigidbody2D>();
        InitalExtraJumps = CurrentExtraJumpsLeft;
    }

    void Update()
    {
        UpdateIsGrounded();
        ResetJumpsLeft();
    }

    //Method shoots a raycast in Update() to check if the player is grounded
    private void UpdateIsGrounded()
    {
        float raycastDistance = 0.1f;
        bool RealIsGrounded = Physics2D.Raycast(FloorLocation.position, Vector2.down, raycastDistance, FloorLayer);
        if (RealIsGrounded)
        {
            //If raycast detects object that has the FloorLayer matrix, itll set IsGrounded to true
            IsGrounded = true;
        }
        else
        {
            //ELSE, itll enable a coroutine SetIsGroundedFalseTimer.
            StartCoroutine(SetIsGroundedFalseTimer());
        }
    }

    /*To prevent unfair input due to the rigidness from the raycast, this method give the player 0.1 seconds before
    * then setting IsGrounded to false. This gives the player some leeway when jumping, know as coyote jumping.
    */
    private IEnumerator SetIsGroundedFalseTimer()
    {
        yield return new WaitForSeconds(0.1f);
        IsGrounded = false;
    }


    //Method which resets the CurrentExtraJumpsLeft variable to InitalExtraJumps when IsGrounded is true.
    //AKA, when the player is grounded, the players double jump is reset.
    private void ResetJumpsLeft()
    {
        if (IsGrounded)
        {
            CurrentExtraJumpsLeft = InitalExtraJumps;
        }
    }

    //Method used to handle how the player jumps, using IsGrounded and CurrentExtraJumps to determine how the player jumps.
    //AKA, this method actually jumps the player, apon being called by the C# event.
    private void JumpPlayer()
    {
        //A tiny raycast/a tiny line is shot down from the Floorlocation, if raycast hits anything with the floorlayer, the player jumps
        //AKA, if the player is on the ground, they jump WITHOUT using up a double jump, cus that aint how it work.
        if (IsGrounded)
        {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, 0);
            rb.AddForce(Vector2.up * CurrentJumpForce, ForceMode2D.Impulse);
        }
        //IF the raycast does not detect the ground, it checks if CurrentExtraJumpsLeft is greater than 0, if so, they jump
        //AKA, this statement run if the player is PROLLY not on the ground.
        //With this in mind, the code then checks if has any doubles jumps, if so, then the player jumps while using up a double jump.
        else if (CurrentExtraJumpsLeft > 0)
        {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, 0);
            rb.AddForce(Vector2.up * CurrentJumpForce, ForceMode2D.Impulse);
            CurrentExtraJumpsLeft--;
        }
        
    }
}
