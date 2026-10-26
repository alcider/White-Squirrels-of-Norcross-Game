using UnityEditor.Tilemaps;
using UnityEngine;
using UnityEngine.UIElements;
using System;

public class SecretWall : MonoBehaviour
{
    SpriteRenderer ObjectRenderer;
    bool IsFound;

    public static event Action OnSecretWallFound;

    void Start()
    {
        ObjectRenderer = GetComponent<SpriteRenderer>();
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.CompareTag("Player")){
            ObjectRenderer.color = new Color(1f, 1f, 1f, 0.5f);
            if (IsFound == false)
            {
                IsFound = true;
                OnSecretWallFound?.Invoke();
            }
        }
    }
    private void OnTriggerExit2D(Collider2D col)
    {
        if (col.gameObject.CompareTag("Player"))
        {
            ObjectRenderer.color = new Color(1f, 1f, 1f, 1f);
        }
    }

}
