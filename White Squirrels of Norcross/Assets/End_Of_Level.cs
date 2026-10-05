using UnityEngine;
using TMPro;

public class End_Of_Level : MonoBehaviour
{
    public TextMeshPro Acorns;
    public TextMeshPro secrets;
    public TextMeshPro time;
    public int timeToBeat;
    public int numcorns;
    public int numofsecretsfound;
    public GameObject endingScreen;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("End Level"))
        {

        }
    }

    // Update is called once per frame
    void Update()
    {
        timeToBeat = (int)(1 * Time.deltaTime);
        numcorns = collect.numAcorns + BigAcorns.numberAcorns;
        numofsecretsfound = SecretCounter.numberOfSecretsFound;

    }
}
