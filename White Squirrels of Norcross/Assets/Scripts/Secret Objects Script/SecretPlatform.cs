using UnityEditor.Tilemaps;
using UnityEngine;
using UnityEngine.UIElements;
using System;

public class SecretPlatform : MonoBehaviour
{
    SpriteRenderer ObjectRenderer;
    Collider2D ObjectCollider;
    bool IsFound;


    void Start()
    {
        ObjectRenderer = GetComponent<SpriteRenderer>();
        ObjectCollider = GetComponent<Collider2D>();
        ObjectRenderer.color = new Color(1f, 1f, 1f, 0.01f);
    }

    private void OnCollisionEnter2D (Collider2D col)
    {
        if(col.gameObject.CompareTag("Player"))
        {
            IsFound = true;
            ObjectRenderer.color = new Color(1f, 1f, 1f, 1f);
        }
    }
}
