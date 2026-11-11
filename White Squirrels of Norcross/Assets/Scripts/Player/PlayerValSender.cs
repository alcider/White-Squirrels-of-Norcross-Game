using UnityEngine;
using System;
public class PlayerValSender : MonoBehaviour
{
    //C# to send Player gameObject
    public static event Action<GameObject> OnPlayerLaunch;

    void Start()
    {
        OnPlayerLaunch?.Invoke(gameObject);
    }
    //point of script is for player to send reference of itself.
}
