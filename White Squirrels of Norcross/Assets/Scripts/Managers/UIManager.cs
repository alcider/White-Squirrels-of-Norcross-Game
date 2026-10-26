using UnityEngine;
using TMPro;
public class UIManager : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI AcornCounterUI;
    
    void OnEnable()
    {
        ScoreManager.OnAcornGet += UpdateAcornCounterText;
    }
    void OnDisable()
    {
        ScoreManager.OnAcornGet -= UpdateAcornCounterText;
    }

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
