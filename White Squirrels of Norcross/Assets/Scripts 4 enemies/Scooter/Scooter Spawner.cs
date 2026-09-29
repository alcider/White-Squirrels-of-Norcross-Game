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
        
    }
    IEnumerator SpawnerStart()
    {
        while (true)
        {
            if (movementScript.inCamera == true)
            {
                Instantiate(scooter, parent);
                yield return new WaitForSeconds(1);
            }
        }
    }
}
