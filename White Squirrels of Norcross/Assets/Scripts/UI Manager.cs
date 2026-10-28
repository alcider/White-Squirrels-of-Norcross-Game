using UnityEngine;

public class UIManager : MonoBehaviour
{
    public GameObject mainScreen;
    void Start()
    {
        
    }

    void Update()
    {
        
    }
    public void RemoveMainScreen()
    {
        mainScreen.gameObject.SetActive(false);
    }
}
