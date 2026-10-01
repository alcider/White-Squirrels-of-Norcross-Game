using UnityEditor.Tilemaps;
using UnityEngine;
using UnityEngine.UIElements;

public class InvisibleWall : MonoBehaviour
{
    SpriteRenderer w_renderer;
    bool hasBeenFound = false;
    public static int secretsFound;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        w_renderer = gameObject.GetComponent<SpriteRenderer>();
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.CompareTag("Player")){
            w_renderer.color = new Color(1f, 1f, 1f, 0.5f);
            if (hasBeenFound == false)
            {
                secretsFound += 1;
                hasBeenFound = true;
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collider)
    {
        if (collider.gameObject.CompareTag("Player"))
        {
            w_renderer.color = new Color(1f, 1f, 1f, 1f);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
