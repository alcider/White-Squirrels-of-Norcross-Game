using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class End_Of_Level : MonoBehaviour
{
    public TextMeshPro Acorns;
    public TextMeshPro secrets;
    public TextMeshPro time;
    public int timeToBeat;
    public int numcorns;
    public int numofsecretsfound;
    public GameObject endingScreen;
    private int finalAcorns;
    private int finalSecrets;
    private int minutes;
    private int seconds;
    private int finalMinutes;
    private int finalSeconds;
    Scene scene;
    public static int x;
    public static int y;
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
        if (collision.gameObject.CompareTag("End level"))
        {
            finalMinutes = minutes;
            finalSeconds = seconds;
            timeToBeat = 0;
            finalAcorns = numcorns;
            finalSecrets = numofsecretsfound;
            Acorns.text = "Acorns: " + finalAcorns;
            secrets.text = "Secrets: " + finalSecrets;
            if (seconds.ToString().Length == 1)
            {
                time.text = "Time: " + finalMinutes + ":0" + finalSeconds;
            }
            else
            {
                time.text = "Time: " + finalMinutes + ":" + finalSeconds;
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
            timeToBeat = (int)(Time.realtimeSinceStartup);
            if (timeToBeat >= 60)
            {
                minutes = timeToBeat / 60;
            }
            seconds = timeToBeat % 60;
            numcorns = collect.numAcorns + BigAcorns.numberAcorns;
            numofsecretsfound = SecretCounter.numberOfSecretsFound;
            Acorns.text = "Acorns: " + numcorns + "/" + x;
            secrets.text = "Secrets: " + numofsecretsfound + "/" + y;
            if (seconds.ToString().Length == 1)
            {
                time.text = "Time: " + minutes + ":0" + seconds;
            }
            else
            {
                time.text = "Time: " + minutes + ":" + seconds;
            }
    }
}