using UnityEngine;

public class EnemyFollow : MonoBehaviour
{
    GameObject PlayerObj; //GameObject variable which holds reference to player prefab.
    [SerializeField] GameObject EnemyUpperBody; //Another GameObject variable which holds reference to parent GameObject.
    [SerializeField] float EnemySpeed; //Float variable to hold ideal player speed
    bool isPlayerNear; //Bool to know if player is in radius

    //Subscription to certain c# events.
    private void OnEnable()
    {
        PlayerValSender.OnPlayerLaunch += SetPlayerObj;
    }
    private void OnDisable()
    {
        PlayerValSender.OnPlayerLaunch -= SetPlayerObj;
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

    // Method is subscribed to OnPlayerLaunch, to get reference to player on the get go.
    void SetPlayerObj(GameObject playerobj){
        PlayerObj = playerobj;}


    /* Both OnTriggerEnter and Exit are used to toggle
     * the isPlayerNear bool, to invoke movement
     */
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
