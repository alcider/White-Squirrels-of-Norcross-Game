using UnityEngine;
using System.Collections;

public class ScooterSpawner : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    [SerializeField] private ScooterMovement movementScript;
    public GameObject scooter;
    private bool ableToStart;
    public Transform parent;
    float ElaspedTime = 0f;
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        SpawnerStart();
    }
    void SpawnerStart()
    {
        ElaspedTime += Time.deltaTime;

        if (movementScript.inCamera == true && ElaspedTime >= 1f)
        {
            Instantiate(scooter, parent);
            ElaspedTime = 0f;
        }
    }

    
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("MainCamera"))
        {
            movementScript.inCamera = true;
        }
        
    }
    void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("MainCamera"))
        {
            movementScript.inCamera = false;
        }
    }
}
