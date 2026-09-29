using TMPro;
using UnityEngine;

public class collect : MonoBehaviour
{
    public TextMeshPro acornCounter;
    public static int numAcorns;
    public int NumberAcorns;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }
    void OnCollisionEnter2D(Collision2D collision) 
	{
		if(collision.gameObject.CompareTag("Player"))
		{
            numAcorns += 1;
			Destroy(gameObject);
		}
	}

    // Update is called once per frame
    void Update()
    {
        NumberAcorns = numAcorns + BigAcorns.numberAcorns;
        acornCounter.text = "Acorns: " + NumberAcorns;
    }
}
