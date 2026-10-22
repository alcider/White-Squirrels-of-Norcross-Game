using UnityEngine;
using TMPro;
public class UIManager : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI AcornCounterUI;
    void Start()
    {
        
    }

    void Update()
    {
        
    }

    private void UpdateAcornCounterText(int NewAcornCount)
    {
        AcornCounterUI.text = "Acorns:" + NewAcornCount;
        
    }
}
