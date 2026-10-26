using UnityEngine;
using System;
public class ScoreManager : MonoBehaviour
{
    //C# events, used to send int values to anything subscirbed.
    public static event Action<int> OnAcornGet;
    public static event Action<int> OnSecretFound;
    //Variable which is normally PRIVATE, used to hold player collectables and score.
    public int TotalAcorns;
    public int TotalSecretsFound;

    //OnEnable and OnDisable method, used to subscribe and unsubscribe to certain C# events.
    void OnEnable()
    {
        AcornCollect.OnAcornPickUp += UpdateTotalAcornAmt;
        SecretWall.OnSecretWallFound += UpdateTotalSecretsFound;
    }
    void OnDisable()
    {
        AcornCollect.OnAcornPickUp -= UpdateTotalAcornAmt;
        SecretWall.OnSecretWallFound -= UpdateTotalSecretsFound;
    }


    void Start()
    {
        
    }

    void Update()
    {
        
    }

    /*This method adds to  the TotalAcorns variable with the int AmtOfAcorns, and invokes
    the c# event OnAcornGet, sending TotalAcorns.
    */
    //AKA, this methods adds AmtOfAcorns to the total acorns the player has, and sends that to whoever is subscirbed.
    private void UpdateTotalAcornAmt(int AmtOfAcorns)
    {
        TotalAcorns += AmtOfAcorns;
        OnAcornGet?.Invoke(TotalAcorns);
    }
    private void UpdateTotalSecretsFound()
    {
        TotalSecretsFound += 1;
        OnSecretFound?.Invoke(TotalSecretsFound);
    }
}
