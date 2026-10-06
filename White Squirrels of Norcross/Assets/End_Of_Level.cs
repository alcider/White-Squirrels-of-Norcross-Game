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
    public int finalTime;
    private int finaltime;
    private int finalAcorns;
    private int finalSecrets;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Acorns.gameObject.SetActive(true);
        secrets.gameObject.SetActive(true);
        time.gameObject.SetActive(true);
        endingScreen.SetActive(true);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("End Level"))
        {
            finaltime = timeToBeat;
            timeToBeat = 0;
            finalAcorns = numcorns;
            finalSecrets = numofsecretsfound;
            Acorns.text = "Acorns: " + finalAcorns;
            secrets.text = "Secrets found: " + finalSecrets;
            time.text = "Time: " + finaltime;
        }
    }

    // Update is called once per frame
    void Update()
    {
            timeToBeat = (int)(Time.realtimeSinceStartup);
            numcorns = collect.numAcorns + BigAcorns.numberAcorns;
            numofsecretsfound = SecretCounter.numberOfSecretsFound;
            Acorns.text = "Acorns: " + numcorns;
            secrets.text = "Secrets found: " + numofsecretsfound;
            time.text = "Time: " + timeToBeat;
    }
}
