using TMPro;
using UnityEngine;
using System;
public class InfoWallHandler : MonoBehaviour
{
    //Variables which hold the text gameobjects to adjust
    [SerializeField] TextMeshPro SecretText;
    [SerializeField] TextMeshPro AcornText;
    [SerializeField] TextMeshPro TimeText;
    //Float variable held to time the infowall
    private float ElapsedTime = 0f;
    /*Variables which hold the initial acorns and secrets which are found 
     * when script 1st starts, and the acorns and secrets found by the player
     */
    float InitialAcorns;
    float InitialSecrets;
    float FoundAcorns;
    float FoundSecrets;

    //C# events in which the script is subscribed to 
    private void OnEnable()
    {
        ScoreManager.OnSecretLaunchGet += UpdateLaunchSecretsAmt;
        ScoreManager.OnAcornLaunchGet += UpdateLaunchAcornAmt;
        ScoreManager.OnAcornGet += UpdateFoundAcornAmt;
        ScoreManager.OnSecretFound += UpdateFoundSecretsAmt;
    }
    private void OnDisable()
    {
        ScoreManager.OnSecretLaunchGet -= UpdateLaunchSecretsAmt;
        ScoreManager.OnAcornLaunchGet -= UpdateLaunchAcornAmt;
        ScoreManager.OnAcornGet -= UpdateFoundAcornAmt;
        ScoreManager.OnSecretFound -= UpdateFoundSecretsAmt;
    }

    /* Update holds the UpdateTimer() method and updates the secret and acorn text 
     * every frame.
     */
    void Update()
    {
        UpdateTimer();
        SecretText.text = "Secrets Found: " + FoundSecrets + " / " + InitialSecrets;
        AcornText.text = "Acorns Found: " + FoundAcorns + " / " + InitialAcorns;
    }

    //This method counts how much time has past for the player.
    //Aka, thats it
    private void UpdateTimer()
    {
        ElapsedTime += Time.deltaTime;
        TimeSpan time = TimeSpan.FromSeconds(ElapsedTime);
        TimeText.text = "Time: " + $"{time.Minutes:00}:{time.Seconds:00}";
    }

    // These 2 methods are used to update the acorns and secrets found at launch of the script.
    private void UpdateLaunchAcornAmt(int InitialAmt)
    { 
        InitialAcorns += InitialAmt;
    }
    private void UpdateLaunchSecretsAmt(int InitialAmt)
    {
        InitialSecrets += InitialAmt;
    }
    //--------
    /*These 2 scripts are used to update the acorns that are found by the
     * player while playing.
     */
    private void UpdateFoundAcornAmt(int InitialAmt)
    {
        FoundAcorns = InitialAmt;
    }
    private void UpdateFoundSecretsAmt(int InitialAmt)
    {
        FoundSecrets = InitialAmt;
    }
}
