using UnityEngine;

public class PlayerJump : MonoBehaviour
{

    [SerializeField] float CurrentJumpForce; // Variable on how hard the player jumps
    [SerializeField] Transform FloorLocation; // Variable on the location of the players feet (typically as child of player capsule )
    [SerializeField] LayerMask FloorLayer; // Variable of Layermask of floors in game
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
    }

    void Update()
    {
        
    }

    private void JumpPlayer()
    {
        //A tiny raycast is shot down from the Floorlocation, if raycast hits anything with the floorlayer, the player jumps
        float raycastDistance = 0.2f;
        bool isGrounded = Physics2D.Raycast(FloorLocation.position, Vector2.down, raycastDistance, FloorLayer);
        if (isGrounded)
        {
            rb.AddForce(Vector2.up * CurrentJumpForce, ForceMode2D.Impulse);
        }
        
    }
}
