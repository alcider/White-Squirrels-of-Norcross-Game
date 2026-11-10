using UnityEngine;
using System;
using System.Collections;
public class ScoreManager : MonoBehaviour
{
    //C# events, used to send int values to anything subscribed.
    public static event Action<int> OnAcornGet;
    public static event Action<int> OnSecretFound;
    public static event Action<int> OnAcornLaunchGet;
    public static event Action<int> OnSecretLaunchGet;
    //Variable which is normally PRIVATE, used to hold player collectables and score.
    public int TotalAcornsCollected;
    public int TotalSecretsFound;

    [Header("---Values Already Found---")]
    public int TotalAcornsInitial;
    public int TotalSecrets;

    //OnEnable and OnDisable method, used to subscribe and unsubscribe to certain C# events.
    void OnEnable()
    {
        AcornCollect.OnAcornPickUp += UpdateAcornAmtCollected;
        SecretWall.OnSecretWallFound += UpdateSecretsFound;
        AcornValSender.OnAcornInitialVals += UpdateLaunchAcornAmt;
        SecretValSender.OnSecretFoundLaunch += UpdateLaunchSecrets;
    }
    void OnDisable()
    {
        AcornCollect.OnAcornPickUp -= UpdateAcornAmtCollected;
        SecretWall.OnSecretWallFound -= UpdateSecretsFound;
        AcornValSender.OnAcornInitialVals -= UpdateLaunchAcornAmt;
        SecretValSender.OnSecretFoundLaunch -= UpdateLaunchSecrets;
    }


    void Start()
    {
        StartCoroutine(InitialInfoUpdate());
    }


    /*This method adds to  the TotalAcorns variable with the int AmtOfAcorns, and invokes
    the c# event OnAcornGet, sending TotalAcorns.
    */
    //AKA, this methods adds AmtOfAcorns to the total acorns the player has, and sends that to whoever is subscirbed.
    private void UpdateAcornAmtCollected(int AmtOfAcorns)
    {
        TotalAcornsCollected += AmtOfAcorns;
        OnAcornGet?.Invoke(TotalAcornsCollected);
    }
    //Method does simialr to UpdateTotalAcornAmtCollected, just with secrets
    private void UpdateSecretsFound()
    {
        TotalSecretsFound += 1;
        OnSecretFound?.Invoke(TotalSecretsFound);
    }
    //-----------

    /*This method updates the total acorns within the level at launch,
     * and stores them within the script.
     */
    private void UpdateLaunchAcornAmt(int AmtOfAcorns)
    {
        TotalAcornsInitial += AmtOfAcorns;
    }
    //This method does simialr to UpdateTotalAcornsAmt, just for secrets at launch.
    private void UpdateLaunchSecrets()
    {
        TotalSecrets += 1;
    }

    /* This method is used to very lazily combat race condition.
     * As much as I want to send the total acorns and secrets at launch at start, some values may be lost
     * within a frame, so I delay sending the values for a second. lamo
     */
    private IEnumerator InitialInfoUpdate()
    {
        yield return new WaitForSeconds(1f);
        OnAcornLaunchGet?.Invoke(TotalAcornsInitial);
        OnSecretLaunchGet?.Invoke(TotalSecrets);

    }
}
