using UnityEngine;
using System;
using System.Collections;
public class ScoreManager : MonoBehaviour
{
    //C# events, used to send int values to anything subscirbed.
    public static event Action<int> OnAcornGet;
    public static event Action<int> OnSecretFound;
    public static event Action<int> OnAcornIntialGet;
    public static event Action<int> OnSecretIntialGet;
    //Variable which is normally PRIVATE, used to hold player collectables and score.
    public int TotalAcornsCollected;
    public int TotalSecretsFound;

    [Header("---Values Already Found---")]
    public int TotalAcornsInital;
    public int TotalSecrets;

    //OnEnable and OnDisable method, used to subscribe and unsubscribe to certain C# events.
    void OnEnable()
    {
        AcornCollect.OnAcornPickUp += UpdateTotalAcornAmtCollected;
        SecretWall.OnSecretWallFound += UpdateTotalSecretsFound;
        AcornValSender.OnAcornInitalVals += UpdateTotalAcornAmt;
        SecretValSender.OnSecretFoundInital += UpdateTotalSecrets;
    }
    void OnDisable()
    {
        AcornCollect.OnAcornPickUp -= UpdateTotalAcornAmtCollected;
        SecretWall.OnSecretWallFound -= UpdateTotalSecretsFound;
        AcornValSender.OnAcornInitalVals -= UpdateTotalAcornAmt;
        SecretValSender.OnSecretFoundInital -= UpdateTotalSecrets;
    }


    void Start()
    {
        StartCoroutine(InitalInfoUpdate());

    }

    void Update()
    {

    }

    /*This method adds to  the TotalAcorns variable with the int AmtOfAcorns, and invokes
    the c# event OnAcornGet, sending TotalAcorns.
    */
    //AKA, this methods adds AmtOfAcorns to the total acorns the player has, and sends that to whoever is subscirbed.
    private void UpdateTotalAcornAmtCollected(int AmtOfAcorns)
    {
        TotalAcornsCollected += AmtOfAcorns;
        OnAcornGet?.Invoke(TotalAcornsCollected);
    }
    private void UpdateTotalSecretsFound()
    {
        TotalSecretsFound += 1;
        OnSecretFound?.Invoke(TotalSecretsFound);
    }
    private void UpdateTotalAcornAmt(int AmtOfAcorns)
    {
        TotalAcornsInital += AmtOfAcorns;
    }
    private void UpdateTotalSecrets()
    {
        TotalSecrets += 1;
    }
    private IEnumerator InitalInfoUpdate()
    {
        yield return new WaitForSeconds(1f);
        OnAcornIntialGet?.Invoke(TotalAcornsInital);
        OnSecretIntialGet?.Invoke(TotalSecrets);

    }
}
