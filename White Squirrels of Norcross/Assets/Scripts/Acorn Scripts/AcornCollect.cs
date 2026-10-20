using UnityEngine;
using Sytem;
public class AcornCollect : MonoBehaviour
{
    
    public static event Action<int> OnAcornPickUp;

    [serializefield] int AcornValue;

    void Start()
    {
        
    }

    void Update()
    {
        
    }
}
