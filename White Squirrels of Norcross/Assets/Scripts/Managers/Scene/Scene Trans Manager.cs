using UnityEngine;
using UnityEngine.SceneManagement;
public class SceneTransManager : MonoBehaviour
{
    private void OnEnable()
    {
        SceneToggler.OnSceneLoad += TransitionScene;
    }

    private void OnDisable()
    {
        SceneToggler.OnSceneLoad -= TransitionScene;
    }
    void Start()
    {
        
    }

    void Update()
    {
        
    }

    void TransitionScene(string SceneToTransition)
    {
        Debug.Log("yo");
        SceneManager.LoadScene(SceneToTransition);
    }
}
