using UnityEngine;
using System.Collections;

public class NewMonoBehaviourScript : MonoBehaviour
{
    public bool inCamera;
    public float speed;
    void Start()
    {
        speed = 5.0f;
        inCamera = false;
    }

    void Update()
    {
        
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("MainCamera"))
        {
            inCamera = true;
            StartCoroutine(StartMovement());
        }
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("MainCamera"))
        {
            inCamera = false;
            Destroy(gameObject);
        }
    
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Destroy(other.gameObject);
            //Must change the Destroy() function for a tp so the player doesn't die eternally.
        }
    }
    IEnumerator StartMovement()
    {
        while (inCamera)
        {
            yield return new WaitForSeconds(0.01f);
            transform.Translate(Vector2.left * Time.deltaTime * speed);
        }
    }
}
