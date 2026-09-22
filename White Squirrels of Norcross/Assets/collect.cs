using UnityEngine;

public class collect : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }
    void OnCollisionEnter(Collision collision) 
	{
		if(collision.gameObject.CompareTag("Player"))
		{
			Destroy(this.gameObject);
		}
	}

    // Update is called once per frame
    void Update()
    {
        
    }
}
