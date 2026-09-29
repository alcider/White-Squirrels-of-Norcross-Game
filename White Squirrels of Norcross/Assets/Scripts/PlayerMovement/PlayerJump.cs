using UnityEngine;

public class PlayerJump : MonoBehaviour
{
    [SerializeField] float CurrentJumpForce;
    [SerializeField] Transform FloorLocation;
    [SerializeField] LayerMask FloorLayer;
    Rigidbody2D rb;


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
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        
    }

    private void JumpPlayer()
    {
        float sphereRadius = 0.4f;
        bool isGrounded = Physics2D.Raycast(FloorLocation.position, Vector2.down, sphereRadius, FloorLayer);
        if (isGrounded)
        {
            rb.AddForce(Vector2.up * CurrentJumpForce, ForceMode2D.Impulse);
        }
        
    }
}
