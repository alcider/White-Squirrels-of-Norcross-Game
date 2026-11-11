using UnityEngine;

public class EnemyFollow : MonoBehaviour
{
    GameObject PlayerObj;
    [SerializeField] GameObject EnemyUpperBody;
    [SerializeField] float EnemySpeed;
    bool isPlayerNear;


    private void OnEnable()
    {
        PlayerValSender.OnPlayerLaunch += SetPlayerObj;
    }
    private void OnDisable()
    {
        PlayerValSender.OnPlayerLaunch += SetPlayerObj;
    }

    void Start()
    {
        
    }

    
    void Update()
    {
        if (isPlayerNear)
        {
            FollowPlayer();
        }
    }
    void SetPlayerObj(GameObject playerobj){
        PlayerObj = playerobj;}

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            isPlayerNear = true;
        }
    }
    void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            isPlayerNear = false;
        }
    }

    void FollowPlayer()
    {
        EnemyUpperBody.transform.position = Vector2.MoveTowards(this.transform.position, PlayerObj.transform.position, EnemySpeed * Time.deltaTime);
    }


}
