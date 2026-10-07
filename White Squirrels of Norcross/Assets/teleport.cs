using UnityEngine;

public class teleport : MonoBehaviour
{
    public static Vector2 playerLocation = new Vector2(-3.5f, 0.5f);
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    void OnTriggerEnter2D (Collider2D collider)
    {
        if (collider.gameObject.CompareTag("Enemy"))
        {
            transform.position = playerLocation;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
