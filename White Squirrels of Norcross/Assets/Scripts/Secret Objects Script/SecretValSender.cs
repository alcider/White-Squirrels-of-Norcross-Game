using UnityEngine;
using System;
public class SecretValSender : MonoBehaviour
{
    public static event Action OnSecretFoundInital;
    void Start()
    {
        OnSecretFoundInital?.Invoke();
    }
}
