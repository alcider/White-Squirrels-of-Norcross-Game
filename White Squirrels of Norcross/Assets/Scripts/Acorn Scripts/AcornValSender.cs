using UnityEngine;
using System;
public class AcornValSender : MonoBehaviour
{
    public static event Action<int> OnAcornInitalVals;
    private AcornCollect acornScript;
    void Start()
    {
        acornScript = GetComponent<AcornCollect>();
        int intialval = acornScript.AcornVal;
        OnAcornInitalVals?.Invoke(intialval);
    }
}
