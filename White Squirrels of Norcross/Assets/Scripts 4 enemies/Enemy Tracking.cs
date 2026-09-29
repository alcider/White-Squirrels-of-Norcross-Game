using UnityEngine;
using System.Collections;
public class EnemyTracking : MonoBehaviour
{
    public GameObject player;
    public int speed;
    void Start()
    {
        speed = 3;
        StartCoroutine(Info());
    }
    IEnumerator Info()
    {
        while(true)
        {
            Debug.Log(speed);
            yield return new WaitForSeconds(0.5f);
        }
    }
    void Update()
    {
        transform.position = Vector2.MoveTowards(this.transform.position, player.transform.position, speed * Time.deltaTime);
    }
    void OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            speed = 0;
        }
    }
    void OnCollisionExit2D(Collision2D other)
    {
        speed = 3;
    }
}
