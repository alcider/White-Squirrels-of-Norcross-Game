using UnityEngine;

public class SecretCounter : MonoBehaviour
{
    public static int numberOfSecretsFound;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        numberOfSecretsFound = InvisibleWall.secretsFound;
        Debug.Log("Number of secrets found: " + numberOfSecretsFound);
    }
}
