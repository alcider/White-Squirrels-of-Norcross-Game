using UnityEngine;
using UnityEngine.SceneManagement;

public class TotalSetter : MonoBehaviour
{
    private int BuildIndex;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.CompareTag("Player"))
        {
            Scene scene = SceneManager.GetActiveScene();
            BuildIndex = scene.buildIndex;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (BuildIndex == 1)
        {
            End_Of_Level.y = 5;
            End_Of_Level.x = 314;
        }
        if (BuildIndex == 2)
        {
            End_Of_Level.y = 5;
            End_Of_Level.x = 215;
        }
        Destroy(gameObject);
    }
}