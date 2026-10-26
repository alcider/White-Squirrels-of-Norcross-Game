using UnityEditor.Tilemaps;
using UnityEngine;
using UnityEngine.UIElements;
using System;

public class SecretPlatform : MonoBehaviour
{
    SpriteRenderer ObjectRenderer;
    bool IsFound;


    void Start()
    {
        ObjectRenderer = GetComponent<SpriteRenderer>();
        ObjectRenderer.color = new Color(1f, 1f, 1f, 0.01f);
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        if(col.gameObject.CompareTag("Player"))
        {
            IsFound = true;
            ObjectRenderer.color = new Color(1f, 1f, 1f, 1f);
        }
    }
    private void OnCollisionExit2D(Collision2D col)
    {
        if(col.gameObject.CompareTag("Player"))
        {
            IsFound = true;
            ObjectRenderer.color = new Color(1f, 1f, 1f, 0.01f);
        }
    }
}
