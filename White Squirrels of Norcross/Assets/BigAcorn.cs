using TMPro;
using UnityEngine;

public class BigAcorns : MonoBehaviour
{
    public static int numberAcorns;
    public int NumberOfAcorns;
    public TextMeshPro acorncollectioncounter;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            numberAcorns += 15;
            Destroy(gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
        NumberOfAcorns = numberAcorns + collect.numAcorns;
        acorncollectioncounter.text = "Acorns: " + NumberOfAcorns;
    }
}
