using UnityEngine;
using System;
public class AcornValSender : MonoBehaviour
{
    //C# event which sends acorn vals to whomever is subscribed
    public static event Action<int> OnAcornInitialVals;
    private AcornCollect acornScript;

    void Start()
    {
        acornScript = GetComponent<AcornCollect>();
        int Initialval = acornScript.AcornVal;
        OnAcornInitialVals?.Invoke(Initialval);
    }
    /*The purpose of the valsender script is to tally
     * how many acorns are in the level
     */
}
