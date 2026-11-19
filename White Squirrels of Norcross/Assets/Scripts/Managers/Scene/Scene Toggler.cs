using UnityEngine;
using System;
public class SceneToggler : MonoBehaviour
{
    public static event Action<String> OnSceneLoad;
    [SerializeField] string SceneToLoad;

    public void SendSceneString()
    {
        OnSceneLoad?.Invoke(SceneToLoad);
    }
}
