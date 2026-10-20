using UnityEditor.Tilemaps;
using UnityEngine;
using UnityEngine.UIElements;

public class Invisible_Wall_No_counter : MonoBehaviour
{
    SpriteRenderer o_renderer;
    bool hasBeenFound = false;
    public static int secretsFound;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        o_renderer = gameObject.GetComponent<SpriteRenderer>();
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.CompareTag("Player")){
            o_renderer.color = new Color(1f, 1f, 1f, 0.5f);
        }
    }

    private void OnTriggerExit2D(Collider2D collider)
    {
        if (collider.gameObject.CompareTag("Player"))
        {
            o_renderer.color = new Color(1f, 1f, 1f, 1f);
        }
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log("Secrets found: " + secretsFound);
    }
}