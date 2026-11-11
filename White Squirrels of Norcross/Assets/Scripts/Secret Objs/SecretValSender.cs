using UnityEngine;
using System;
public class SecretValSender : MonoBehaviour
{
    //C# events, used to indicate when secret found.
    public static event Action OnSecretFoundLaunch;
    void Start()
    {
        OnSecretFoundLaunch?.Invoke();
    }
    /*The purpose of the valsender script is to tally
     * how many secrets are in the level
     */
}
