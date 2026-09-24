using UnityEditor.ShaderGraph.Internal;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{

    [SerializeField] float CurrentPlayerSpeed;


    Rigidbody2D rb;

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
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        
    }

    private void MovePlayer(Vector2 moveVector)
    {
        Vector2 UsedVector = new Vector2(moveVector.x, 0);
        rb.AddForce(UsedVector, ForceMode2D.Impulse);
    }
}
