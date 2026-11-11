using UnityEngine;

public class RotationScript : MonoBehaviour
{
    [SerializeField] int RotationSpeed;
    void Update()
    {
        transform.Rotate(0, 0, RotationSpeed * Time.deltaTime);
    }
}
