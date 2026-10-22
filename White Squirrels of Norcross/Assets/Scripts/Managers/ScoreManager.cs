using UnityEngine;
using System;
public class ScoreManager : MonoBehaviour
{
    //C# event OnAcornGet, used to send int values to anything subscirbed.
    public static event Action<int> OnAcornGet;
    //Variable which is normally PRIVATE, used to hold players current TotalAcorn Value.
    public int TotalAcorns;

    //OnEnable and OnDisable method, used to subscribe and unsubscribe to certain C# events.
    void OnEnable()
    {
        AcornCollect.OnAcornPickUp += UpdateTotalAcornAmt;
    }
    void OnDisable()
    {
        AcornCollect.OnAcornPickUp -= UpdateTotalAcornAmt;
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
    //AKA, this methods adds AmtOfAcorns to the total acorns the player has, and sending that to whoever is subscirbed.
    private void UpdateTotalAcornAmt(int AmtOfAcorns)
    {
        TotalAcorns += AmtOfAcorns;
        OnAcornGet?.Invoke(TotalAcorns);
    }
}
