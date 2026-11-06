using TMPro;
using UnityEngine;
using System;
public class InfoWallHandler : MonoBehaviour
{
    [SerializeField] TextMeshPro SecretText;
    [SerializeField] TextMeshPro AcornText;
    [SerializeField] TextMeshPro TimeText;
    private float ElapsedTime = 0f;
    float InitalAcorns;
    float InitalSecrets;
    float FoundAcorns;
    float FoundSecrets;

    private void OnEnable()
    {
        ScoreManager.OnSecretIntialGet += UpdateInitalSecretsAmt;
        ScoreManager.OnAcornIntialGet += UpdateInitalAcornAmt;
        ScoreManager.OnAcornGet += UpdateFoundAcornAmt;
        ScoreManager.OnSecretFound += UpdateFoundSecretsAmt;
    }
    private void OnDisable()
    {
        ScoreManager.OnSecretIntialGet -= UpdateInitalSecretsAmt;
        ScoreManager.OnAcornIntialGet -= UpdateInitalAcornAmt;
        ScoreManager.OnAcornGet -= UpdateFoundAcornAmt;
        ScoreManager.OnSecretFound -= UpdateFoundSecretsAmt;
    }
    void Start()
    {
        
    }

    void Update()
    {
        UpdateTimer();
        SecretText.text = "Secrets Found: " + FoundSecrets + " / " + InitalSecrets;
        AcornText.text = "Acorns Found: " + FoundAcorns + " / " + InitalAcorns;
    }

    private void UpdateTimer()
    {
        ElapsedTime += Time.deltaTime;
        TimeSpan time = TimeSpan.FromSeconds(ElapsedTime);
        TimeText.text = "Time: " + $"{time.Minutes:00}:{time.Seconds:00}";
    }

    private void UpdateInitalAcornAmt(int IntialAmt)
    { 
        InitalAcorns += IntialAmt;
    }
    private void UpdateInitalSecretsAmt(int IntialAmt)
    {
        InitalSecrets += IntialAmt;
    }
    private void UpdateFoundAcornAmt(int IntialAmt)
    {
        FoundAcorns = IntialAmt;
    }
    private void UpdateFoundSecretsAmt(int IntialAmt)
    {
        FoundSecrets = IntialAmt;
    }
}
