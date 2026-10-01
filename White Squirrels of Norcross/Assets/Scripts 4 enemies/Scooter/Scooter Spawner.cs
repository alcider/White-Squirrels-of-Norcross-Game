using UnityEngine;
using System.Collections;

public class ScooterSpawner : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    [SerializeField] private NewMonoBehaviourScript movementScript;
    public GameObject scooter;
    private bool ableToStart;
    public Transform parent;
    void Start()
    {
        StartCoroutine(SpawnerStart());
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(movementScript.inCamera);
    }
    IEnumerator SpawnerStart()
    {
        while (true)
        {
            if (movementScript.inCamera == true)
            {
                Instantiate(scooter, parent);
                yield return new WaitForSeconds(20);
            }
            else
            {
                yield return new WaitForSeconds(1);
            }
        }
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Destroy(other.gameObject);
            //Must change the Destroy() function for a tp so the player doesn't die eternally.
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
