using UnityEngine;
using System;
public class AcornCollect : MonoBehaviour
{
    //C# event OnAcornPickUp, used to send int values to anything subscirbed.
    public static event Action<int> OnAcornPickUp;

    //int variable which holds current Acorn value.
    [SerializeField] int AcornValue;

    /*This method checks if whatever objects which enters the trigger, has the Player Tag. If so, the 
    OnAcornPickUp C# event is invoked, sending AcornValue with it, and deleting the current game object. RIP :(
    */
    //AKA, if the player touches the acorn, the AcornValue is sent to who wants it, while the object disappears. 
    void OnTriggerEnter2D(Collider2D col)
    {
        if(col.gameObject.CompareTag("Player"))
        {
            OnAcornPickUp?.Invoke(AcornValue);
            Destroy(gameObject);
        }
    }
        
}
