using UnityEngine;
using System;
using System.Collections;
public class PlayerJump : MonoBehaviour
{

    [SerializeField] float CurrentJumpForce; // Variable on how hard the player jumps
    [SerializeField] Transform FloorLocation; // Variable on the location of the players feet (typically as child of player capsule )
    [SerializeField] LayerMask FloorLayer; // Variable of Layermask of floors in game
    [SerializeField] int CurrentJumpsLeft; //Variable which holds how many jumps left
    int InitalJumpsLeft; //Variable used to hold the inital jumps left
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
        InitalJumpsLeft = CurrentJumpsLeft;
    }

    void Update()
    {
        UpdateIsGrounded();
        UpdateJumpsLeft();
    }

    private void UpdateIsGrounded()
    {
        float raycastDistance = 0.1f;
        bool RealIsGrounded = Physics2D.Raycast(FloorLocation.position, Vector2.down, raycastDistance, FloorLayer);
        if (RealIsGrounded)
        {
            IsGrounded = true;
        }
        else
        {
            StartCoroutine(SetIsGroundedFalseTimer());
        }
    }
    private IEnumerator SetIsGroundedFalseTimer()
    {
        yield return new WaitForSeconds(0.1f);
        IsGrounded = false;
    }

    private void UpdateJumpsLeft()
    {
        if (IsGrounded)
        {
            CurrentJumpsLeft = InitalJumpsLeft;
        }
    }

    private void JumpPlayer()
    {
        //A tiny raycast is shot down from the Floorlocation, if raycast hits anything with the floorlayer, the player jumps

        if (IsGrounded)
        {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, 0);
            rb.AddForce(Vector2.up * CurrentJumpForce, ForceMode2D.Impulse);
        }
        else if (CurrentJumpsLeft > 0)
        {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, 0);
            rb.AddForce(Vector2.up * CurrentJumpForce, ForceMode2D.Impulse);
            CurrentJumpsLeft--;
        }
        
    }
}
