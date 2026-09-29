using UnityEngine;

public class PlayerJump : MonoBehaviour
{
    [SerializeField] float CurrentJumpForce;
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
        rb.AddForce(Vector2.up * CurrentJumpForce, ForceMode2D.Impulse);
    }
}
